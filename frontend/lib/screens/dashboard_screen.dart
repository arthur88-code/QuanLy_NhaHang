import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/app_theme.dart';
import '../core/session.dart';
import '../widgets/common.dart';

class DashboardScreen extends StatelessWidget {
  const DashboardScreen({super.key, required this.session});

  final AppSession session;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<JsonMap>(
      future: () async => asMap(await api.get('/dashboard')),
      builder: (context, data, refresh) {
        final recentOrders = data['recentOrders'] as List? ?? [];
        final notifications = data['notifications'] as List? ?? [];
        return RefreshIndicator(
          onRefresh: refresh,
          child: AppScreen(
            title: 'Tổng quan',
            action: IconButton(
              onPressed: refresh,
              icon: const Icon(Icons.refresh),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                ClipRRect(
                  borderRadius: BorderRadius.circular(10),
                  child: Stack(
                    children: [
                      Image.network(
                        data['heroImageUrl']?.toString() ?? restaurantHeroImage,
                        height: 150,
                        width: double.infinity,
                        fit: BoxFit.cover,
                      ),
                      Container(
                        height: 150,
                        color: Colors.black.withValues(alpha: 0.42),
                      ),
                      Positioned(
                        left: 16,
                        right: 16,
                        bottom: 16,
                        child: Text(
                          'Xin chào, ${session.name}',
                          style: Theme.of(context).textTheme.headlineSmall
                              ?.copyWith(
                                color: Colors.white,
                                fontWeight: FontWeight.w900,
                              ),
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(height: 14),
                Wrap(
                  spacing: 12,
                  runSpacing: 12,
                  children: [
                    MetricCard(
                      icon: Icons.table_bar,
                      label: 'Tổng bàn',
                      value: '${data['tableCount']}',
                    ),
                    MetricCard(
                      icon: Icons.event_available,
                      label: 'Bàn trống',
                      value: '${data['availableTables']}',
                      color: brandGreen,
                    ),
                    MetricCard(
                      icon: Icons.event_seat,
                      label: 'Da dat',
                      value: '${data['reservedTables']}',
                      color: brandOrange,
                    ),
                    MetricCard(
                      icon: Icons.restaurant,
                      label: 'Dang dung',
                      value: '${data['occupiedTables']}',
                      color: Colors.red,
                    ),
                    MetricCard(
                      icon: Icons.receipt_long,
                      label: 'Đơn mở',
                      value: '${data['openOrders']}',
                    ),
                    MetricCard(
                      icon: Icons.groups,
                      label: 'Khach hang',
                      value: '${data['customerCount']}',
                    ),
                    MetricCard(
                      icon: Icons.account_balance_wallet,
                      label: 'Công nợ',
                      value: formatMoney(data['openDebtAmount']),
                      color: brandOrange,
                    ),
                    MetricCard(
                      icon: Icons.payments,
                      label: 'Doanh thu hôm nay',
                      value: formatMoney(data['revenueToday']),
                      color: brandDark,
                    ),
                  ],
                ),
                const SizedBox(height: 18),
                Text(
                  'Thông báo mới',
                  style: Theme.of(
                    context,
                  ).textTheme.titleLarge?.copyWith(fontWeight: FontWeight.w800),
                ),
                const SizedBox(height: 8),
                if (notifications.isEmpty)
                  const EmptyState(text: 'Chưa có thông báo')
                else
                  ...notifications.map(
                    (item) => _NotificationTile(item: asMap(item)),
                  ),
                const SizedBox(height: 18),
                Text(
                  'Hóa đơn gần đây',
                  style: Theme.of(
                    context,
                  ).textTheme.titleLarge?.copyWith(fontWeight: FontWeight.w800),
                ),
                const SizedBox(height: 8),
                if (recentOrders.isEmpty)
                  const EmptyState(text: 'Chưa có hóa đơn')
                else
                  ...recentOrders.map(
                    (order) => _OrderTile(order: asMap(order)),
                  ),
              ],
            ),
          ),
        );
      },
    );
  }
}

class _NotificationTile extends StatelessWidget {
  const _NotificationTile({required this.item});

  final JsonMap item;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8),
      child: Card(
        child: ListTile(
          leading: const Icon(Icons.notifications_outlined, color: brandBlue),
          title: Text(item['title']?.toString() ?? ''),
          subtitle: Text(item['body']?.toString() ?? ''),
        ),
      ),
    );
  }
}

class _OrderTile extends StatelessWidget {
  const _OrderTile({required this.order});

  final JsonMap order;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.only(bottom: 8),
      child: Card(
        child: ListTile(
          leading: const Icon(Icons.receipt_long_outlined),
          title: Text('${order['tableName']} - HĐ #${order['id']}'),
          subtitle: Text(order['status']?.toString() ?? ''),
          trailing: Text(
            formatMoney(order['total']),
            style: const TextStyle(fontWeight: FontWeight.w800),
          ),
        ),
      ),
    );
  }
}
