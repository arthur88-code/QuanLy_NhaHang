import 'dart:convert';

import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/app_theme.dart';
import '../widgets/common.dart';

class WebAdminScreen extends StatelessWidget {
  const WebAdminScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<JsonMap>(
      future: () async {
        final health = await api.get('/admin/health');
        final stats = await api.get('/stats?period=month');
        final payroll = await api.get('/payroll');
        final export = await api.get('/admin/export');
        return {
          'health': health,
          'stats': stats,
          'payroll': payroll,
          'export': export,
        };
      },
      builder: (context, data, refresh) {
        final health = asMap(data['health']);
        final stats = asMap(data['stats']);
        final payroll = asMap(data['payroll']);
        final exportPreview = const JsonEncoder.withIndent(
          '  ',
        ).convert(data['export']);
        return AppScreen(
          title: 'Quản trị web',
          action: FilledButton.icon(
            onPressed: () => runAction(context, () async {
              await api.post('/admin/reset', {});
              await refresh();
            }),
            icon: const Icon(Icons.restore),
            label: const Text('Reset demo'),
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Wrap(
                spacing: 12,
                runSpacing: 12,
                children: [
                  MetricCard(
                    icon: Icons.cloud_done_outlined,
                    label: 'Server',
                    value: health['status']?.toString() ?? 'ok',
                    color: brandGreen,
                  ),
                  MetricCard(
                    icon: Icons.table_bar,
                    label: 'Bàn',
                    value: '${health['tables']}',
                  ),
                  MetricCard(
                    icon: Icons.ramen_dining,
                    label: 'Món',
                    value: '${health['menuItems']}',
                  ),
                  MetricCard(
                    icon: Icons.receipt_long,
                    label: 'Hóa đơn',
                    value: '${health['orders']}',
                  ),
                  MetricCard(
                    icon: Icons.payments,
                    label: 'Lương tháng',
                    value: formatMoney(payroll['totalSalary']),
                    color: brandOrange,
                  ),
                  MetricCard(
                    icon: Icons.trending_up,
                    label: 'Doanh thu tháng',
                    value: formatMoney(stats['revenue']),
                    color: brandDark,
                  ),
                ],
              ),
              const SizedBox(height: 18),
              Text(
                'Checklist vận hành',
                style: Theme.of(
                  context,
                ).textTheme.titleLarge?.copyWith(fontWeight: FontWeight.w900),
              ),
              const SizedBox(height: 8),
              const Card(
                child: Padding(
                  padding: EdgeInsets.all(14),
                  child: Column(
                    children: [
                      _ChecklistRow(
                        text: 'Kiểm tra bàn đang mở trước khi đóng ca',
                      ),
                      _ChecklistRow(
                        text: 'Đối chiếu công nợ và hóa đơn đã trả',
                      ),
                      _ChecklistRow(text: 'Xuất dữ liệu JSON cuối ngày'),
                      _ChecklistRow(text: 'Chốt chấm công nhân viên'),
                    ],
                  ),
                ),
              ),
              const SizedBox(height: 18),
              Text(
                'Xuất dữ liệu',
                style: Theme.of(
                  context,
                ).textTheme.titleLarge?.copyWith(fontWeight: FontWeight.w900),
              ),
              const SizedBox(height: 8),
              Card(
                child: Padding(
                  padding: const EdgeInsets.all(14),
                  child: SelectableText(
                    exportPreview,
                    maxLines: 18,
                    style: const TextStyle(
                      fontFamily: 'monospace',
                      fontSize: 12,
                    ),
                  ),
                ),
              ),
            ],
          ),
        );
      },
    );
  }
}

class _ChecklistRow extends StatelessWidget {
  const _ChecklistRow({required this.text});

  final String text;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 6),
      child: Row(
        children: [
          const Icon(Icons.check_circle, color: brandGreen),
          const SizedBox(width: 10),
          Expanded(child: Text(text)),
        ],
      ),
    );
  }
}
