import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/session.dart';
import '../widgets/common.dart';

class InvoicesScreen extends StatefulWidget {
  const InvoicesScreen({
    super.key,
    required this.session,
    required this.onChanged,
  });

  final AppSession session;
  final VoidCallback onChanged;

  @override
  State<InvoicesScreen> createState() => _InvoicesScreenState();
}

class _InvoicesScreenState extends State<InvoicesScreen> {
  String _filter = 'all';
  int _version = 0;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    final query = _filter == 'all' ? '' : '?status=$_filter';
    return FutureLoader<List<dynamic>>(
      key: ValueKey('orders-$_filter-$_version'),
      future: () async => await api.get('/orders$query') as List<dynamic>,
      builder: (context, orders, refresh) {
        return RefreshIndicator(
          onRefresh: refresh,
          child: AppScreen(
            title: 'Hoa don',
            action: IconButton(
              onPressed: () {
                setState(() => _version++);
                refresh();
              },
              icon: const Icon(Icons.refresh),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                SingleChildScrollView(
                  scrollDirection: Axis.horizontal,
                  child: SegmentedButton<String>(
                    segments: const [
                      ButtonSegment(value: 'all', label: Text('Tat ca')),
                      ButtonSegment(value: 'paid', label: Text('Da tra')),
                      ButtonSegment(value: 'open', label: Text('Dang dung')),
                    ],
                    selected: {_filter},
                    onSelectionChanged: (value) =>
                        setState(() => _filter = value.first),
                  ),
                ),
                const SizedBox(height: 14),
                if (orders.isEmpty)
                  const EmptyState(text: 'Chua co hoa don')
                else
                  ...orders.map(
                    (order) => _InvoiceCard(
                      order: asMap(order),
                      session: widget.session,
                      refresh: () async {
                        widget.onChanged();
                        setState(() => _version++);
                        await refresh();
                      },
                    ),
                  ),
              ],
            ),
          ),
        );
      },
    );
  }
}

class _InvoiceCard extends StatelessWidget {
  const _InvoiceCard({
    required this.order,
    required this.session,
    required this.refresh,
  });

  final JsonMap order;
  final AppSession session;
  final Future<void> Function() refresh;

  @override
  Widget build(BuildContext context) {
    final batches = order['batches'] as List? ?? [];
    final customerName = order['customerName']?.toString() ?? '';
    return Padding(
      padding: const EdgeInsets.only(bottom: 10),
      child: Semantics(
        label:
            'invoice-card-${order['id']}-${order['tableName']}-${order['status']}',
        button: true,
        child: Card(
          child: ExpansionTile(
            title: Text('${order['tableName']} - HD #${order['id']}'),
            subtitle: Text(
              '${_statusLabel(order['status'])} - ${formatMoney(order['total'])}',
            ),
            childrenPadding: const EdgeInsets.fromLTRB(16, 0, 16, 14),
            children: [
              Align(
                alignment: Alignment.centerLeft,
                child: Text(
                  customerName.isEmpty
                      ? 'Khach: khong lien ket tai khoan khach'
                      : 'Khach: $customerName - ${order['customerPhone'] ?? ''}',
                ),
              ),
              const SizedBox(height: 8),
              if (batches.isEmpty)
                const EmptyState(text: 'Hoa don chua co mon')
              else
                ...batches.map((batch) => _InvoiceBatch(batch: asMap(batch))),
              const Divider(),
              Row(
                children: [
                  Expanded(
                    child: Text('Nhan vien: ${order['staffName'] ?? ''}'),
                  ),
                  Text(
                    formatMoney(order['total']),
                    style: const TextStyle(fontWeight: FontWeight.w900),
                  ),
                ],
              ),
              if (order['status'] == 'open' && session.canCollect) ...[
                const SizedBox(height: 12),
                Row(
                  children: [
                    Expanded(
                      child: Semantics(
                        label: 'invoice-pay-${order['id']}',
                        button: true,
                        child: FilledButton.icon(
                          onPressed: () => _pay(context),
                          icon: const Icon(Icons.done_all),
                          label: const Text('Da tra'),
                        ),
                      ),
                    ),
                    const SizedBox(width: 10),
                    Expanded(
                      child: Semantics(
                        label: 'invoice-debt-${order['id']}',
                        button: true,
                        child: OutlinedButton.icon(
                          onPressed: () => _debt(context),
                          icon: const Icon(
                            Icons.account_balance_wallet_outlined,
                          ),
                          label: const Text('Ghi no'),
                        ),
                      ),
                    ),
                  ],
                ),
              ],
            ],
          ),
        ),
      ),
    );
  }

  String _statusLabel(Object? status) {
    return switch (status?.toString()) {
      'paid' => 'Da tra',
      'open' => 'Dang dung',
      'debt' => 'Ghi no',
      _ => status?.toString() ?? '',
    };
  }

  Future<void> _pay(BuildContext context) async {
    final api = ApiClient();
    final discount = TextEditingController(text: '0');
    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('Xac nhan thanh toan'),
        content: TextField(
          controller: discount,
          keyboardType: TextInputType.number,
          decoration: const InputDecoration(labelText: 'Giam gia'),
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Huy'),
          ),
          FilledButton(
            onPressed: () => runAction(context, () async {
              await api.post('/orders/${order['id']}/pay', {
                'role': session.role,
                'userName': session.name,
                'discount': int.tryParse(discount.text) ?? 0,
              });
              if (context.mounted) Navigator.pop(context);
              await refresh();
            }),
            child: const Text('Da tra'),
          ),
        ],
      ),
    );
  }

  Future<void> _debt(BuildContext context) async {
    final api = ApiClient();
    final name = TextEditingController();
    final phone = TextEditingController();
    final note = TextEditingController();
    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('Ghi cong no'),
        content: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextField(
              controller: name,
              decoration: const InputDecoration(labelText: 'Ten khach'),
            ),
            const SizedBox(height: 10),
            TextField(
              controller: phone,
              decoration: const InputDecoration(labelText: 'So dien thoai'),
            ),
            const SizedBox(height: 10),
            TextField(
              controller: note,
              decoration: const InputDecoration(labelText: 'Ghi chu'),
            ),
          ],
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Huy'),
          ),
          FilledButton(
            onPressed: () => runAction(context, () async {
              await api.post('/orders/${order['id']}/debt', {
                'role': session.role,
                'customerName': name.text.trim(),
                'customerPhone': phone.text.trim(),
                'note': note.text.trim(),
              });
              if (context.mounted) Navigator.pop(context);
              await refresh();
            }),
            child: const Text('Luu no'),
          ),
        ],
      ),
    );
  }
}

class _InvoiceBatch extends StatelessWidget {
  const _InvoiceBatch({required this.batch});

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
