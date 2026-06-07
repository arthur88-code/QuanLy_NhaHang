import 'package:flutter/material.dart';

import '../api_client.dart';
import '../widgets/common.dart';

class EmployeesScreen extends StatelessWidget {
  const EmployeesScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final api = ApiClient();
    return FutureLoader<List<dynamic>>(
      future: () async => await api.get('/employees') as List<dynamic>,
      builder: (context, employees, refresh) {
        return AppScreen(
          title: 'Quan ly nhan vien',
          action: Semantics(
            label: 'action-add-employee',
            button: true,
            child: FilledButton.icon(
              onPressed: () => _showEmployeeDialog(context, api, refresh),
              icon: const Icon(Icons.add),
              label: const Text('Them'),
            ),
          ),
          child: Column(
            children: employees.map((employee) {
              final map = asMap(employee);
              final account = map['account'] is Map
                  ? asMap(map['account'])
                  : <String, dynamic>{};
              final isActive = map['active'] != false;
              return Padding(
                padding: const EdgeInsets.only(bottom: 10),
                child: Semantics(
                  label:
                      'employee-row-${map['id']}-${map['name']}-${isActive ? 'active' : 'locked'}',
                  child: Card(
                    child: ListTile(
                      leading: Icon(
                        isActive
                            ? Icons.badge_outlined
                            : Icons.person_off_outlined,
                      ),
                      title: Text(map['name']?.toString() ?? ''),
                      subtitle: Text(
                        '${map['role']} - ${map['phone']} - ${formatMoney(map['salaryPerDay'])}/ngay\nTai khoan: ${account['username'] ?? 'chua co'} - ${account['role'] ?? 'staff'}',
                      ),
                      isThreeLine: true,
                      trailing: Wrap(
                        children: [
                          Semantics(
                            label: 'employee-edit-${map['id']}',
                            button: true,
                            child: IconButton(
                              tooltip: 'Sua nhan vien va tai khoan',
                              onPressed: () => _showEmployeeDialog(
                                context,
                                api,
                                refresh,
                                employee: map,
                              ),
                              icon: const Icon(Icons.edit_outlined),
                            ),
                          ),
                          Semantics(
                            label: 'employee-lock-${map['id']}',
                            button: true,
                            child: IconButton(
                              tooltip: 'Khoa tai khoan',
                              onPressed: () => runAction(context, () async {
                                await api.delete('/employees/${map['id']}');
                                await refresh();
                              }),
                              icon: const Icon(Icons.lock_outline),
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
        );
      },
    );
  }

  Future<void> _showEmployeeDialog(
    BuildContext context,
    ApiClient api,
    Future<void> Function() refresh, {
    JsonMap? employee,
  }) async {
    final account = employee?['account'] is Map
        ? asMap(employee?['account'])
        : <String, dynamic>{};
    final name = TextEditingController(
      text: employee?['name']?.toString() ?? '',
    );
    final role = TextEditingController(
      text: employee?['role']?.toString() ?? 'Phuc vu',
    );
    final phone = TextEditingController(
      text: employee?['phone']?.toString() ?? '',
    );
    final salary = TextEditingController(
      text: employee?['salaryPerDay']?.toString() ?? '300000',
    );
    final username = TextEditingController(
      text: account['username']?.toString() ?? '',
    );
    final password = TextEditingController(text: employee == null ? '123' : '');
    var accountRole = account['role']?.toString() == 'admin'
        ? 'admin'
        : 'staff';

    await showDialog<void>(
      context: context,
      builder: (context) => AlertDialog(
        title: Text(employee == null ? 'Them nhan vien' : 'Sua nhan vien'),
        content: SingleChildScrollView(
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextField(
                controller: name,
                decoration: const InputDecoration(labelText: 'Ho ten'),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: role,
                decoration: const InputDecoration(labelText: 'Chuc vu'),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: phone,
                decoration: const InputDecoration(labelText: 'SDT'),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: salary,
                keyboardType: TextInputType.number,
                decoration: const InputDecoration(labelText: 'Luong/ngay'),
              ),
              const SizedBox(height: 16),
              TextField(
                controller: username,
                decoration: const InputDecoration(
                  labelText: 'Tai khoan dang nhap',
                  prefixIcon: Icon(Icons.person_outline),
                ),
              ),
              const SizedBox(height: 10),
              TextField(
                controller: password,
                obscureText: true,
                decoration: InputDecoration(
                  labelText: employee == null
                      ? 'Mat khau'
                      : 'Mat khau moi neu can doi',
                  prefixIcon: const Icon(Icons.lock_outline),
                ),
              ),
              const SizedBox(height: 10),
              StatefulBuilder(
                builder: (context, setLocal) => DropdownButtonFormField<String>(
                  initialValue: accountRole,
                  decoration: const InputDecoration(labelText: 'Quyen'),
                  items: const [
                    DropdownMenuItem(value: 'staff', child: Text('Nhan vien')),
                    DropdownMenuItem(value: 'admin', child: Text('Admin')),
                  ],
                  onChanged: (value) =>
                      setLocal(() => accountRole = value ?? accountRole),
                ),
              ),
            ],
          ),
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Huy'),
          ),
          FilledButton(
            onPressed: () => runAction(context, () async {
              final Map<String, dynamic> body = {
                'name': name.text.trim(),
                'role': role.text.trim(),
                'phone': phone.text.trim(),
                'salaryPerDay': int.tryParse(salary.text) ?? 300000,
                'username': username.text.trim(),
                'password': password.text.trim().isEmpty
                    ? null
                    : password.text.trim(),
                'accountRole': accountRole,
              };
              if (employee == null) {
                await api.post('/employees', body);
              } else {
                await api.put('/employees/${employee['id']}', body);
              }
              if (context.mounted) Navigator.pop(context);
              await refresh();
            }),
            child: const Text('Luu'),
          ),
        ],
      ),
    );
  }
}
