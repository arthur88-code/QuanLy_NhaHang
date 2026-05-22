import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/session.dart';
import '../widgets/common.dart';

class OrderEntryScreen extends StatefulWidget {
  const OrderEntryScreen({
    super.key,
    required this.table,
    required this.session,
  });

  final JsonMap table;
  final AppSession session;

  @override
  State<OrderEntryScreen> createState() => _OrderEntryScreenState();
}

class _OrderEntryScreenState extends State<OrderEntryScreen> {
  final _api = ApiClient();
  final Map<int, JsonMap> _pending = {};
  JsonMap? _order;
  List<dynamic> _menu = [];
  bool _loading = true;

  @override
  void initState() {
    super.initState();
    _load();
  }

  Future<void> _load() async {
    setState(() => _loading = true);
    final order = await _api.get('/orders/table/${widget.table['id']}/open');
    final menu = await _api.get('/menu') as List<dynamic>;
    if (!mounted) return;
    setState(() {
      _order = order == null ? null : asMap(order);
      _menu = menu;
      _loading = false;
    });
  }

  Future<JsonMap> _ensureOrder() async {
    if (_order != null) return _order!;
    final created = await _api.post('/orders', {
      'tableId': widget.table['id'],
      'staffId': widget.session.employeeId,
      'staffName': widget.session.name,
    });
    _order = asMap(created);
    return _order!;
  }

  void _addPending(JsonMap item) {
    final id = toInt(item['id']);
    final existing = _pending[id];
    setState(() {
      _pending[id] = {
        ...item,
        'quantity': existing == null ? 1 : toInt(existing['quantity']) + 1,
      };
    });
  }

  void _changePending(int menuItemId, int delta) {
    final existing = _pending[menuItemId];
    if (existing == null) return;
    final nextQuantity = toInt(existing['quantity']) + delta;
    setState(() {
      if (nextQuantity <= 0) {
        _pending.remove(menuItemId);
      } else {
        _pending[menuItemId] = {...existing, 'quantity': nextQuantity};
      }
    });
  }

  Future<void> _confirmSelection() async {
    if (_pending.isEmpty) {
      showSnack(context, 'Chua chon mon de xac nhan');
      return;
    }
    await runAction(context, () async {
      final order = await _ensureOrder();
      final items = _pending.values
          .map(
            (item) => {
              'menuItemId': item['id'],
              'quantity': toInt(item['quantity']),
            },
          )
          .toList();
      final updated = await _api.post('/orders/${order['id']}/batches', {
        'items': items,
        'createdBy': widget.session.name,
      });
      setState(() {
        _order = asMap(updated);
        _pending.clear();
      });
    });
  }

  int get _pendingTotal => _pending.values.fold(
    0,
    (sum, item) => sum + toInt(item['price']) * toInt(item['quantity']),
  );

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('${widget.table['name']} - Goi mon'),
        actions: [
          if (_pending.isNotEmpty)
            TextButton.icon(
              onPressed: () => setState(_pending.clear),
              icon: const Icon(Icons.delete_sweep_outlined),
              label: const Text('Bo het danh sach mon chon'),
            ),
        ],
      ),
      body: _loading
          ? const Center(child: CircularProgressIndicator())
          : RefreshIndicator(
              onRefresh: _load,
              child: ListView(
                padding: const EdgeInsets.all(16),
                children: [
                  _OrderSummary(order: _order),
                  if (_pending.isNotEmpty) ...[
                    const SizedBox(height: 12),
                    _PendingSelection(
                      items: _pending.values.toList(),
                      total: _pendingTotal,
                      onChange: _changePending,
                      onCancel: () => setState(_pending.clear),
                      onConfirm: _confirmSelection,
                    ),
                  ],
                  const SizedBox(height: 16),
                  Text(
                    'Danh sach mon an',
                    style: Theme.of(context).textTheme.titleLarge?.copyWith(
                      fontWeight: FontWeight.w900,
                    ),
                  ),
                  const SizedBox(height: 10),
                  ..._menu.where((item) => asMap(item)['available'] == true).map((
                    item,
                  ) {
                    final map = asMap(item);
                    final selected = _pending[toInt(map['id'])];
                    return Padding(
                      padding: const EdgeInsets.only(bottom: 10),
                      child: Card(
                        child: ListTile(
                          leading: ClipRRect(
                            borderRadius: BorderRadius.circular(8),
                            child: Image.network(
                              map['imageUrl']?.toString() ?? '',
                              width: 58,
                              height: 58,
                              fit: BoxFit.cover,
                              errorBuilder: (_, _, _) =>
                                  const Icon(Icons.ramen_dining),
                            ),
                          ),
                          title: Text(map['name']?.toString() ?? ''),
                          subtitle: Text(
                            '${map['category']} - ${formatMoney(map['price'])}',
                          ),
                          trailing: selected == null
                              ? IconButton(
                                  tooltip: 'Chon mon',
                                  onPressed: () => _addPending(map),
                                  icon: const Icon(Icons.add_circle),
                                )
                              : FilledButton.tonalIcon(
                                  onPressed: () => _addPending(map),
                                  icon: const Icon(Icons.add),
                                  label: Text('x${selected['quantity']}'),
                                ),
                        ),
                      ),
                    );
                  }),
                ],
              ),
            ),
    );
  }
}

class _OrderSummary extends StatelessWidget {
  const _OrderSummary({required this.order});

  final JsonMap? order;

  @override
  Widget build(BuildContext context) {
    final batches = order?['batches'] as List? ?? [];
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(14),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              order == null ? 'Chua co hoa don' : 'Hoa don #${order!['id']}',
              style: Theme.of(
                context,
              ).textTheme.titleLarge?.copyWith(fontWeight: FontWeight.w900),
            ),
            const SizedBox(height: 8),
            if (batches.isEmpty)
              const Text('Chon mon ben duoi, sau do bam Xac nhan chon mon.')
            else
              ...batches.map((batch) => _OrderBatch(batch: asMap(batch))),
            const Divider(),
            Row(
              children: [
                const Expanded(
                  child: Text(
                    'Tong tien',
                    style: TextStyle(fontWeight: FontWeight.w800),
                  ),
                ),
                Text(
                  formatMoney(order?['total'] ?? 0),
                  style: const TextStyle(fontWeight: FontWeight.w900),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}

class _OrderBatch extends StatelessWidget {
  const _OrderBatch({required this.batch});

  final JsonMap batch;

  @override
  Widget build(BuildContext context) {
    final items = batch['items'] as List? ?? [];
    return Padding(
      padding: const EdgeInsets.only(top: 10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            displayBatchName(batch['name']),
            style: const TextStyle(fontWeight: FontWeight.w900),
          ),
          const SizedBox(height: 4),
          ...items.map((item) {
            final map = asMap(item);
            final quantity = toInt(map['quantity']);
            return Row(
              children: [
                Expanded(child: Text('${map['name']} x$quantity')),
                Text(formatMoney(toInt(map['price']) * quantity)),
              ],
            );
          }),
        ],
      ),
    );
  }
}

class _PendingSelection extends StatelessWidget {
  const _PendingSelection({
    required this.items,
    required this.total,
    required this.onChange,
    required this.onCancel,
    required this.onConfirm,
  });

  final List<JsonMap> items;
  final int total;
  final void Function(int, int) onChange;
  final VoidCallback onCancel;
  final VoidCallback onConfirm;

  @override
  Widget build(BuildContext context) {
    return Card(
      color: Theme.of(context).colorScheme.primaryContainer.withValues(
        alpha: 0.42,
      ),
      child: Padding(
        padding: const EdgeInsets.all(14),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Danh sach mon dang chon',
              style: Theme.of(
                context,
              ).textTheme.titleMedium?.copyWith(fontWeight: FontWeight.w900),
            ),
            const SizedBox(height: 8),
            ...items.map((item) {
              final id = toInt(item['id']);
              final quantity = toInt(item['quantity']);
              return Row(
                children: [
                  Expanded(child: Text('${item['name']} x$quantity')),
                  IconButton(
                    onPressed: () => onChange(id, -1),
                    icon: const Icon(Icons.remove_circle_outline),
                  ),
                  IconButton(
                    onPressed: () => onChange(id, 1),
                    icon: const Icon(Icons.add_circle_outline),
                  ),
                ],
              );
            }),
            const Divider(),
            Row(
              children: [
                Expanded(
                  child: Text(
                    formatMoney(total),
                    style: const TextStyle(fontWeight: FontWeight.w900),
                  ),
                ),
                OutlinedButton.icon(
                  onPressed: onCancel,
                  icon: const Icon(Icons.close),
                  label: const Text('Huy bo'),
                ),
                const SizedBox(width: 10),
                FilledButton.icon(
                  onPressed: onConfirm,
                  icon: const Icon(Icons.check),
                  label: const Text('Xac nhan chon mon'),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
