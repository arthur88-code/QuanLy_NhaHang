import 'package:flutter/material.dart';

import '../api_client.dart';
import '../widgets/common.dart';

class MenuScreen extends StatelessWidget {
  const MenuScreen({super.key, required this.isAdmin});

  final bool isAdmin;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<List<dynamic>>(
      future: () async => await api.get('/menu') as List<dynamic>,
      builder: (context, menu, refresh) {
        return RefreshIndicator(
          onRefresh: refresh,
          child: AppScreen(
            title: 'Quản lý món ăn',
            action: Semantics(
              label: 'action-add-menu',
              button: true,
              child: FilledButton.icon(
                onPressed: () => _showMenuDialog(context, api, refresh),
                icon: const Icon(Icons.add),
                label: const Text('Thêm món'),
              ),
            ),
            child: Column(
              children: menu.map((item) {
                final map = asMap(item);
                return Padding(
                  padding: const EdgeInsets.only(bottom: 10),
                  child: Semantics(
                    label:
                        'menu-row-${map['id']}-${map['name']}-${map['available'] == true ? 'available' : 'hidden'}',
                    child: Card(
                      child: ListTile(
                        leading: ClipRRect(
                          borderRadius: BorderRadius.circular(8),
                          child: Image.network(
                            map['imageUrl']?.toString() ?? '',
                            width: 56,
                            height: 56,
                            fit: BoxFit.cover,
                            errorBuilder: (_, _, _) =>
                                const Icon(Icons.ramen_dining),
                          ),
                        ),
                        title: Text(map['name']?.toString() ?? ''),
                        subtitle: Text(
                          '${map['category']} - ${formatMoney(map['price'])}',
                        ),
                        trailing: Wrap(
                          children: [
                            Semantics(
                              label: 'menu-toggle-${map['id']}',
                              button: true,
                              child: IconButton(
                                tooltip: map['available'] == true
                                    ? 'Đang bán'
                                    : 'Tạm ẩn',
                                onPressed: () => runAction(context, () async {
                                  await api.put('/menu/${map['id']}', {
                                    ...map,
                                    'available': !(map['available'] == true),
                                  });
                                  await refresh();
                                }),
                                icon: Icon(
                                  map['available'] == true
                                      ? Icons.visibility
                                      : Icons.visibility_off,
                                ),
                              ),
                            ),
                            Semantics(
                              label: 'menu-edit-${map['id']}',
                              button: true,
                              child: IconButton(
                                tooltip: 'Sửa',
                                onPressed: () => _showMenuDialog(
                                  context,
                                  api,
                                  refresh,
                                  item: map,
                                ),
                                icon: const Icon(Icons.edit_outlined),
                              ),
                            ),
                            Semantics(
                              label: 'menu-delete-${map['id']}',
                              button: true,
                              child: IconButton(
                                tooltip: 'Xóa',
                                onPressed: () => runAction(context, () async {
                                  await api.delete('/menu/${map['id']}');
                                  await refresh();
                                }),
                                icon: const Icon(Icons.delete_outline),
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                  ),
                );
              }).toList(),
            ),
          ),
        );
      },
    );
  }

  Future<void> _showMenuDialog(
    BuildContext context,
    ApiClient api,
    Future<void> Function() refresh, {
    JsonMap? item,
  }) async {
    final name = TextEditingController(text: item?['name']?.toString() ?? '');
    final category = TextEditingController(
      text: item?['category']?.toString() ?? 'Món chính',
    );
    final price = TextEditingController(text: item?['price']?.toString() ?? '');
    final imageUrl = TextEditingController(
      text: item?['imageUrl']?.toString() ?? '',
    );
    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text(item == null ? 'Thêm món' : 'Sửa món'),
        content: SingleChildScrollView(
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextField(
                controller: name,
                decoration: const InputDecoration(labelText: 'Tên món'),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: category,
                decoration: const InputDecoration(labelText: 'Nhóm món'),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: price,
                keyboardType: TextInputType.number,
                decoration: const InputDecoration(labelText: 'Giá'),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: imageUrl,
                decoration: const InputDecoration(labelText: 'Link ảnh'),
              ),
            ],
          ),
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Hủy'),
          ),
          FilledButton(
            onPressed: () => runAction(context, () async {
              final body = {
                'name': name.text.trim(),
                'category': category.text.trim(),
                'price': int.tryParse(price.text.trim()) ?? 0,
                'imageUrl': imageUrl.text.trim(),
                'available': item?['available'] ?? true,
              };
              if (item == null) {
                await api.post('/menu', body);
              } else {
                await api.put('/menu/${item['id']}', body);
              }
              if (context.mounted) Navigator.pop(context);
              await refresh();
            }),
            child: const Text('Lưu'),
          ),
        ],
      ),
    );
  }
}
