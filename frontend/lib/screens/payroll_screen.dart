import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/app_theme.dart';
import '../widgets/common.dart';

class PayrollScreen extends StatefulWidget {
  const PayrollScreen({super.key});

  @override
  State<PayrollScreen> createState() => _PayrollScreenState();
}

class _PayrollScreenState extends State<PayrollScreen> {
  String _month = DateTime.now().toIso8601String().slice(0, 7);

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<JsonMap>(
      key: ValueKey(_month),
      future: () async => asMap(await api.get('/payroll?month=$_month')),
      builder: (context, data, refresh) {
        final rows = data['rows'] as List? ?? [];
        return AppScreen(
          title: 'Tính tiền nhân viên',
          action: OutlinedButton.icon(
            onPressed: () => _pickMonth(context),
            icon: const Icon(Icons.calendar_month),
            label: Text(_month),
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              MetricCard(
                icon: Icons.payments_outlined,
                label: 'Tổng lương',
                value: formatMoney(data['totalSalary']),
                color: brandGreen,
              ),
              const SizedBox(height: 12),
              ...rows.map((row) {
                final map = asMap(row);
                final employee = asMap(map['employee']);
                return Padding(
                  padding: const EdgeInsets.only(bottom: 10),
                  child: Card(
                    child: ListTile(
                      leading: const Icon(Icons.payments_outlined),
                      title: Text(employee['name']?.toString() ?? ''),
                      subtitle: Text(
                        '${map['days']} ngày - ${map['hours']} giờ',
                      ),
                      trailing: Text(
                        formatMoney(map['salary']),
                        style: const TextStyle(fontWeight: FontWeight.w900),
                      ),
                    ),
                  ),
                );
              }),
            ],
          ),
        );
      },
    );
  }

  Future<void> _pickMonth(BuildContext context) async {
    final controller = TextEditingController(text: _month);
    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('Chọn tháng'),
        content: TextField(
          controller: controller,
          decoration: const InputDecoration(labelText: 'YYYY-MM'),
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Hủy'),
          ),
          FilledButton(
            onPressed: () {
              setState(() => _month = controller.text.trim());
              Navigator.pop(context);
            },
            child: const Text('Xem'),
          ),
        ],
      ),
    );
  }
}

extension _StringSlice on String {
  String slice(int start, int end) => substring(start, end);
}
