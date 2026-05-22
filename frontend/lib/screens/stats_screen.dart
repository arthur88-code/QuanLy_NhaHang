import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/app_theme.dart';
import '../widgets/common.dart';

class StatsScreen extends StatefulWidget {
  const StatsScreen({super.key});

  @override
  State<StatsScreen> createState() => _StatsScreenState();
}

class _StatsScreenState extends State<StatsScreen> {
  String _period = 'day';
  DateTime _anchorDate = DateTime.now();
  int _version = 0;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    final date = Uri.encodeComponent(_anchorDate.toIso8601String());
    return FutureLoader<JsonMap>(
      key: ValueKey('stats-$_period-$date-$_version'),
      future: () async =>
          asMap(await api.get('/stats?period=$_period&date=$date')),
      builder: (context, data, refresh) {
        final topItems = data['topItems'] as List? ?? [];
        return AppScreen(
          title: 'Thong ke',
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
              Wrap(
                spacing: 10,
                runSpacing: 10,
                crossAxisAlignment: WrapCrossAlignment.center,
                children: [
                  SegmentedButton<String>(
                    segments: const [
                      ButtonSegment(value: 'day', label: Text('Ngay')),
                      ButtonSegment(value: 'month', label: Text('Thang')),
                      ButtonSegment(value: 'year', label: Text('Nam')),
                    ],
                    selected: {_period},
                    onSelectionChanged: (value) => setState(() {
                      _period = value.first;
                      _version++;
                    }),
                  ),
                  OutlinedButton.icon(
                    onPressed: () => _moveAnchor(-1),
                    icon: const Icon(Icons.chevron_left),
                    label: const Text('Truoc'),
                  ),
                  FilledButton.tonalIcon(
                    onPressed: _pickDate,
                    icon: const Icon(Icons.calendar_month),
                    label: Text(_periodLabel),
                  ),
                  OutlinedButton.icon(
                    onPressed: () => _moveAnchor(1),
                    icon: const Icon(Icons.chevron_right),
                    label: const Text('Sau'),
                  ),
                ],
              ),
              const SizedBox(height: 14),
              Wrap(
                spacing: 12,
                runSpacing: 12,
                children: [
                  MetricCard(
                    icon: Icons.receipt,
                    label: 'So hoa don',
                    value: '${data['orderCount']}',
                  ),
                  MetricCard(
                    icon: Icons.payments,
                    label: 'Doanh thu',
                    value: formatMoney(data['revenue']),
                    color: brandGreen,
                  ),
                  MetricCard(
                    icon: Icons.account_balance_wallet,
                    label: 'No phat sinh',
                    value: formatMoney(data['debtCreated']),
                    color: brandOrange,
                  ),
                  MetricCard(
                    icon: Icons.warning_amber,
                    label: 'No con mo',
                    value: formatMoney(data['debtOpen']),
                    color: Colors.red,
                  ),
                ],
              ),
              const SizedBox(height: 18),
              Text(
                'Mon ban chay',
                style: Theme.of(
                  context,
                ).textTheme.titleLarge?.copyWith(fontWeight: FontWeight.w900),
              ),
              const SizedBox(height: 8),
              if (topItems.isEmpty)
                const EmptyState(text: 'Chua co du lieu')
              else
                ...topItems.map((item) {
                  final map = asMap(item);
                  return Card(
                    child: ListTile(
                      leading: const Icon(Icons.star_outline),
                      title: Text(map['name']?.toString() ?? ''),
                      subtitle: Text('So luong: ${map['quantity']}'),
                      trailing: Text(formatMoney(map['revenue'])),
                    ),
                  );
                }),
            ],
          ),
        );
      },
    );
  }

  String get _periodLabel {
    if (_period == 'year') return '${_anchorDate.year}';
    if (_period == 'month') {
      return '${_anchorDate.month.toString().padLeft(2, '0')}/${_anchorDate.year}';
    }
    return '${_anchorDate.day.toString().padLeft(2, '0')}/${_anchorDate.month.toString().padLeft(2, '0')}/${_anchorDate.year}';
  }

  void _moveAnchor(int direction) {
    setState(() {
      _anchorDate = switch (_period) {
        'year' => DateTime(_anchorDate.year + direction, 1, 1),
        'month' => DateTime(_anchorDate.year, _anchorDate.month + direction, 1),
        _ => _anchorDate.add(Duration(days: direction)),
      };
      _version++;
    });
  }

  Future<void> _pickDate() async {
    final picked = await showDatePicker(
      context: context,
      initialDate: _anchorDate,
      firstDate: DateTime(2020),
      lastDate: DateTime(2035),
    );
    if (picked == null) return;
    setState(() {
      _anchorDate = picked;
      _version++;
    });
  }
}
