class AppSession {
  const AppSession({required this.user});

  final Map<String, dynamic> user;

  String get role => user['role']?.toString() ?? 'staff';
  String get name => user['name']?.toString() ?? 'Nhan vien';
  int? get employeeId {
    final value = user['employeeId'];
    if (value is int) return value;
    return int.tryParse(value?.toString() ?? '');
  }

  bool get isAdmin => role == 'admin';
  bool get canCollect => role == 'admin' || role == 'staff';
}
