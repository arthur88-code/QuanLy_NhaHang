import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/session.dart';
import '../widgets/common.dart';

class DebtsScreen extends StatelessWidget {
  const DebtsScreen({super.key, required this.session});

  final AppSession session;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<List<dynamic>>(
      future: () async => await api.get('/debts') as List<dynamic>,
      builder: (context, debts, refresh) {
        return RefreshIndicator(
          onRefresh: refresh,
          child: AppScreen(
            title: 'Công nợ',
            action: IconButton(
              onPressed: refresh,
              icon: const Icon(Icons.refresh),
            ),
            child: Column(
              children: debts.isEmpty
                  ? [const EmptyState(text: 'Chưa có công nợ')]
                  : debts.map((debt) {
                      final map = asMap(debt);
                      final remaining =
                          toInt(map['amount']) - toInt(map['paidAmount']);
                      return Padding(
                        padding: const EdgeInsets.only(bottom: 10),
                        child: Semantics(
                          label:
                              'debt-row-${map['id']}-${map['customerName']}-${map['status']}',
                          child: Card(
                            child: ListTile(
                              leading: Icon(
                                map['status'] == 'paid'
                                    ? Icons.check_circle
                                    : Icons.account_balance_wallet_outlined,
                              ),
                              title: Text(
                                map['customerName']?.toString() ?? '',
                              ),
                              subtitle: Text(
                                'HĐ #${map['orderId']} - còn ${formatMoney(remaining)}',
                              ),
                              trailing:
                                  map['status'] == 'open' && session.canCollect
                                  ? Semantics(
                                      label: 'debt-pay-${map['id']}',
                                      button: true,
                                      child: FilledButton(
                                        onPressed: () =>
                                            runAction(context, () async {
                                              await api.patch(
                                                '/debts/${map['id']}/pay',
                                                {
                                                  'role': session.role,
                                                  'amount': remaining,
                                                },
                                              );
                                              await refresh();
                                            }),
                                        child: const Text('Thu đủ'),
                                      ),
                                    )
                                  : const Text('Đã xong'),
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
}
