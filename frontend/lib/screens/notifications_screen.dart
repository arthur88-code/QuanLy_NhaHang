import 'package:flutter/material.dart';

import '../api_client.dart';
import '../widgets/common.dart';

class NotificationsScreen extends StatelessWidget {
  const NotificationsScreen({super.key, required this.isAdmin});

  final bool isAdmin;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<List<dynamic>>(
      future: () async => await api.get('/notifications') as List<dynamic>,
      builder: (context, notifications, refresh) {
        return AppScreen(
          title: 'Thông báo',
          action: isAdmin
              ? Semantics(
                  label: 'action-create-notification',
                  button: true,
                  child: FilledButton.icon(
                    onPressed: () => _showDialog(context, api, refresh),
                    icon: const Icon(Icons.add),
                    label: const Text('Tạo'),
                  ),
                )
              : null,
          child: Column(
            children: notifications.isEmpty
                ? [const EmptyState(text: 'Chưa có thông báo')]
                : notifications.map((item) {
                    final map = asMap(item);
                    return Padding(
                      padding: const EdgeInsets.only(bottom: 10),
                      child: Semantics(
                        label: 'notification-row-${map['id']}-${map['title']}',
                        child: Card(
                          child: ListTile(
                            leading: const Icon(Icons.notifications_outlined),
                            title: Text(map['title']?.toString() ?? ''),
                            subtitle: Text(
                              '${map['body']}\n${shortDate(map['createdAt'])}',
                            ),
                            isThreeLine: true,
                            trailing: isAdmin
                                ? Semantics(
                                    label: 'notification-delete-${map['id']}',
                                    button: true,
                                    child: IconButton(
                                      onPressed: () =>
                                          runAction(context, () async {
                                            await api.delete(
                                              '/notifications/${map['id']}',
                                            );
                                            await refresh();
                                          }),
                                      icon: const Icon(Icons.delete_outline),
                                    ),
                                  )
                                : null,
                          ),
                        ),
                      ),
                    );
                  }).toList(),
          ),
        );
      },
    );
  }

  Future<void> _showDialog(
    BuildContext context,
    ApiClient api,
    Future<void> Function() refresh,
  ) async {
    final title = TextEditingController();
    final body = TextEditingController();
    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('Tạo thông báo'),
        content: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextField(
              controller: title,
              decoration: const InputDecoration(labelText: 'Tiêu đề'),
            ),
            const SizedBox(height: 10),
            TextField(
              controller: body,
              maxLines: 3,
              decoration: const InputDecoration(labelText: 'Nội dung'),
            ),
          ],
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Hủy'),
          ),
          FilledButton(
            onPressed: () => runAction(context, () async {
              await api.post('/notifications', {
                'title': title.text.trim(),
                'body': body.text.trim(),
                'audience': 'all',
              });
              if (context.mounted) Navigator.pop(context);
              await refresh();
            }),
            child: const Text('Gửi'),
          ),
        ],
      ),
    );
  }
}
