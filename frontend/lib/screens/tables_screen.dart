import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/app_theme.dart';
import '../core/session.dart';
import '../widgets/common.dart';
import 'order_entry_screen.dart';

class TablesScreen extends StatelessWidget {
  const TablesScreen({
    super.key,
    required this.session,
    required this.onChanged,
  });

  final AppSession session;
  final VoidCallback onChanged;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<List<dynamic>>(
      future: () async => await api.get('/tables') as List<dynamic>,
      builder: (context, tables, refresh) {
        return RefreshIndicator(
          onRefresh: refresh,
          child: AppScreen(
            title: 'Quản lý bàn',
            action: FilledButton.icon(
              onPressed: () => _showTableDialog(context, api, refresh),
              icon: const Icon(Icons.add),
              label: const Text('Thêm bàn'),
            ),
            child: LayoutBuilder(
              builder: (context, constraints) {
                final columns = constraints.maxWidth > 1100
                    ? 5
                    : constraints.maxWidth > 820
                    ? 4
                    : constraints.maxWidth > 560
                    ? 3
                    : 2;
                return GridView.builder(
                  shrinkWrap: true,
                  physics: const NeverScrollableScrollPhysics(),
                  itemCount: tables.length,
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: columns,
                    crossAxisSpacing: 12,
                    mainAxisSpacing: 12,
                    mainAxisExtent: constraints.maxWidth < 560 ? 224 : 190,
                  ),
                  itemBuilder: (context, index) {
                    final table = asMap(tables[index]);
                    return _TableCard(
                      table: table,
                      onTap: () async {
                        await Navigator.push(
                          context,
                          MaterialPageRoute(
                            builder: (_) => OrderEntryScreen(
                              table: table,
                              session: session,
                            ),
                          ),
                        );
                        onChanged();
                        await refresh();
                      },
                      onLongPress: () =>
                          _showTableActions(context, api, refresh, table),
                    );
                  },
                );
              },
            ),
          ),
        );
      },
    );
  }

  Future<void> _showTableActions(
    BuildContext context,
    ApiClient api,
    Future<void> Function() refresh,
    JsonMap table,
  ) {
    return showModalBottomSheet<void>(
      context: context,
      builder: (context) => SafeArea(
        child: Wrap(
          children: [
            ListTile(
              leading: const Icon(Icons.add),
              title: const Text('Thêm bàn mới'),
              onTap: () {
                Navigator.pop(context);
                _showTableDialog(context, api, refresh);
              },
            ),
            ListTile(
              leading: const Icon(Icons.edit_outlined),
              title: const Text('Sửa bàn này'),
              onTap: () {
                Navigator.pop(context);
                _showTableDialog(context, api, refresh, table: table);
              },
            ),
            ListTile(
              leading: const Icon(Icons.delete_outline),
              title: const Text('Xóa bàn này'),
              onTap: () => runAction(context, () async {
                await api.delete('/tables/${table['id']}');
                if (context.mounted) Navigator.pop(context);
                onChanged();
                await refresh();
              }),
            ),
          ],
        ),
      ),
    );
  }

  Future<void> _showTableDialog(
    BuildContext context,
    ApiClient api,
    Future<void> Function() refresh, {
    JsonMap? table,
  }) async {
    final name = TextEditingController(text: table?['name']?.toString() ?? '');
    final seats = TextEditingController(
      text: table?['seats']?.toString() ?? '4',
    );
    final area = TextEditingController(
      text: table?['area']?.toString() ?? 'Tầng 1',
    );
    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text(table == null ? 'Thêm bàn' : 'Sửa bàn'),
        content: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextField(
              controller: name,
              decoration: const InputDecoration(labelText: 'Tên bàn'),
            ),
            const SizedBox(height: 10),
            TextField(
              controller: seats,
              keyboardType: TextInputType.number,
              decoration: const InputDecoration(labelText: 'Số ghế'),
            ),
            const SizedBox(height: 10),
            TextField(
              controller: area,
              decoration: const InputDecoration(labelText: 'Khu vực'),
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
              final body = {
                'name': name.text.trim(),
                'seats': int.tryParse(seats.text.trim()) ?? 4,
                'area': area.text.trim(),
              };
              if (table == null) {
                await api.post('/tables', body);
              } else {
                await api.patch('/tables/${table['id']}', body);
              }
              if (context.mounted) Navigator.pop(context);
              onChanged();
              await refresh();
            }),
            child: const Text('Lưu'),
          ),
        ],
      ),
    );
  }
}

class _TableCard extends StatelessWidget {
  const _TableCard({
    required this.table,
    required this.onTap,
    required this.onLongPress,
  });

  final JsonMap table;
  final VoidCallback onTap;
  final VoidCallback onLongPress;

  @override
  Widget build(BuildContext context) {
    final status = table['status']?.toString() ?? 'available';
    final color = switch (status) {
      'occupied' => Colors.red,
      'reserved' => brandOrange,
      _ => brandGreen,
    };
    final label = switch (status) {
      'occupied' => 'Đang dùng',
      'reserved' => 'Đặt trước',
      _ => 'Trống',
    };
    return InkWell(
      borderRadius: BorderRadius.circular(8),
      onTap: onTap,
      onLongPress: onLongPress,
      child: Card(
        child: Padding(
          padding: const EdgeInsets.all(14),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Row(
                children: [
                  Icon(Icons.table_bar, color: color),
                  const SizedBox(width: 8),
                  Expanded(
                    child: Text(
                      table['name']?.toString() ?? '',
                      maxLines: 1,
                      overflow: TextOverflow.ellipsis,
                      style: Theme.of(context).textTheme.titleMedium?.copyWith(
                        fontWeight: FontWeight.w900,
                      ),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 8),
              Text('${table['area']} - ${table['seats']} ghế'),
              const SizedBox(height: 8),
              const Spacer(),
              Wrap(
                spacing: 8,
                runSpacing: 8,
                children: [
                  Chip(
                    visualDensity: VisualDensity.compact,
                    label: Text(label),
                    backgroundColor: color.withValues(alpha: 0.12),
                    side: BorderSide(color: color.withValues(alpha: 0.35)),
                    labelStyle: TextStyle(
                      color: color,
                      fontWeight: FontWeight.w800,
                    ),
                  ),
                  ActionChip(
                    visualDensity: VisualDensity.compact,
                    avatar: const Icon(Icons.touch_app_outlined, size: 16),
                    label: const Text('Gọi món'),
                    onPressed: onTap,
                  ),
                ],
              ),
              const SizedBox(height: 2),
              Text(
                'Nhấn giữ để sửa/xóa',
                maxLines: 1,
                overflow: TextOverflow.ellipsis,
                style: Theme.of(
                  context,
                ).textTheme.bodySmall?.copyWith(color: const Color(0xFF64748B)),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
