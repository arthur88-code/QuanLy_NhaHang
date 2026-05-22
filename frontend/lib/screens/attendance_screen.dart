import 'package:flutter/material.dart';

import '../api_client.dart';
import '../core/session.dart';
import '../widgets/common.dart';

class AttendanceScreen extends StatelessWidget {
  const AttendanceScreen({super.key, required this.session});

  final AppSession session;

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<JsonMap>(
      future: () async {
        final attendance = await api.get('/attendance') as List<dynamic>;
        final employees = await api.get('/employees') as List<dynamic>;
        return {'attendance': attendance, 'employees': employees};
      },
      builder: (context, data, refresh) {
        final attendance = data['attendance'] as List<dynamic>;
        final employees = data['employees'] as List<dynamic>;
        return AppScreen(
          title: 'Danh sách nhân viên chấm công',
          action: FilledButton.icon(
            onPressed: () => _checkIn(context, api, employees, refresh),
            icon: const Icon(Icons.login),
            label: const Text('Vào ca'),
          ),
          child: Column(
            children: attendance.isEmpty
                ? [const EmptyState(text: 'Hôm nay chưa ai chấm công')]
                : attendance.map((row) {
                    final map = asMap(row);
                    final employee = asMap(map['employee']);
                    return Padding(
                      padding: const EdgeInsets.only(bottom: 10),
                      child: Card(
                        child: ListTile(
                          leading: const Icon(Icons.fact_check_outlined),
                          title: Text(employee['name']?.toString() ?? ''),
                          subtitle: Text(
                            'Vào: ${shortDate(map['checkIn'])} - Ra: ${map['checkOut'] == null ? 'chưa ra ca' : shortDate(map['checkOut'])}',
                          ),
                          trailing: map['checkOut'] == null
                              ? FilledButton(
                                  onPressed: () => runAction(context, () async {
                                    await api.patch(
                                      '/attendance/${map['id']}/check-out',
                                      {},
                                    );
                                    await refresh();
                                  }),
                                  child: const Text('Ra ca'),
                                )
                              : const Text('Xong'),
                        ),
                      ),
                    );
                  }).toList(),
          ),
        );
      },
    );
  }

  Future<void> _checkIn(
    BuildContext context,
    ApiClient api,
    List<dynamic> employees,
    Future<void> Function() refresh,
  ) async {
    int selected = session.employeeId ?? toInt(asMap(employees.first)['id']);
    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('Chấm công vào ca'),
        content: StatefulBuilder(
          builder: (context, setLocal) => DropdownButtonFormField<int>(
            initialValue: selected,
            items: employees.map((employee) {
              final map = asMap(employee);
              return DropdownMenuItem<int>(
                value: toInt(map['id']),
                child: Text(map['name']?.toString() ?? ''),
              );
            }).toList(),
            onChanged: (value) => setLocal(() => selected = value ?? selected),
          ),
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Hủy'),
          ),
          FilledButton(
            onPressed: () => runAction(context, () async {
              await api.post('/attendance/check-in', {'employeeId': selected});
              if (context.mounted) Navigator.pop(context);
              await refresh();
            }),
            child: const Text('Chấm công'),
          ),
        ],
      ),
    );
  }
}
