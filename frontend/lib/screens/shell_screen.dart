import 'package:flutter/material.dart';

import '../core/app_theme.dart';
import '../core/session.dart';
import 'attendance_screen.dart';
import 'dashboard_screen.dart';
import 'debts_screen.dart';
import 'employees_screen.dart';
import 'invoices_screen.dart';
import 'menu_screen.dart';
import 'notifications_screen.dart';
import 'payroll_screen.dart';
import 'stats_screen.dart';
import 'tables_screen.dart';
import 'web_admin_screen.dart';

class ShellScreen extends StatefulWidget {
  const ShellScreen({super.key, required this.session});

  final AppSession session;

  @override
  State<ShellScreen> createState() => _ShellScreenState();
}

class _ShellScreenState extends State<ShellScreen> {
  int _index = 0;
  int _version = 0;

  void _refreshAll() => setState(() => _version++);

  @override
  Widget build(BuildContext context) {
    final items = _items();
    final selected = items[_index.clamp(0, items.length - 1)];
    return LayoutBuilder(
      builder: (context, constraints) {
        final wide = constraints.maxWidth >= 980;
        return Scaffold(
          appBar: AppBar(
            title: const Row(
              mainAxisSize: MainAxisSize.min,
              children: [
                BrandLogo(size: 34, framed: false),
                SizedBox(width: 10),
                Text(brandName),
              ],
            ),
            actions: [
              Padding(
                padding: const EdgeInsets.only(right: 16),
                child: Center(child: Text(widget.session.name)),
              ),
            ],
          ),
          drawer: wide ? null : _buildDrawer(items),
          body: Row(
            children: [
              if (wide)
                _WebSidebar(
                  items: items,
                  selectedIndex: _index,
                  onSelect: (value) => setState(() => _index = value),
                ),
              Expanded(
                child: selected.builder(
                  ValueKey('${selected.label}-$_version'),
                ),
              ),
            ],
          ),
        );
      },
    );
  }

  Widget _buildDrawer(List<_NavItem> items) {
    return NavigationDrawer(
      selectedIndex: _index,
      onDestinationSelected: (value) {
        setState(() => _index = value);
        Navigator.pop(context);
      },
      children: [
        const Padding(
          padding: EdgeInsets.fromLTRB(24, 20, 24, 12),
          child: Row(
            children: [
              BrandLogo(size: 42),
              SizedBox(width: 12),
              Expanded(child: Text(brandName)),
            ],
          ),
        ),
        ...items.map(
          (item) => NavigationDrawerDestination(
            icon: Icon(item.icon),
            label: Text(item.label),
          ),
        ),
      ],
    );
  }

  List<_NavItem> _items() {
    final base = [
      _NavItem(
        'Tổng quan',
        Icons.dashboard_outlined,
        (key) => DashboardScreen(key: key, session: widget.session),
      ),
      _NavItem(
        'Bàn',
        Icons.table_bar_outlined,
        (key) => TablesScreen(
          key: key,
          session: widget.session,
          onChanged: _refreshAll,
        ),
      ),
      _NavItem(
        'Món ăn',
        Icons.ramen_dining_outlined,
        (key) => MenuScreen(key: key, isAdmin: widget.session.isAdmin),
      ),
      _NavItem(
        'Hóa đơn',
        Icons.receipt_long_outlined,
        (key) => InvoicesScreen(
          key: key,
          session: widget.session,
          onChanged: _refreshAll,
        ),
      ),
      _NavItem(
        'Công nợ',
        Icons.account_balance_wallet_outlined,
        (key) => DebtsScreen(key: key, session: widget.session),
      ),
      _NavItem(
        'Thống kê',
        Icons.bar_chart_outlined,
        (key) => StatsScreen(key: key),
      ),
      _NavItem(
        'Chấm công',
        Icons.fact_check_outlined,
        (key) => AttendanceScreen(key: key, session: widget.session),
      ),
    ];
    if (widget.session.isAdmin) {
      base.addAll([
        _NavItem(
          'Nhân viên',
          Icons.badge_outlined,
          (key) => EmployeesScreen(key: key),
        ),
        _NavItem(
          'Thông báo',
          Icons.notifications_outlined,
          (key) => NotificationsScreen(key: key, isAdmin: true),
        ),
        _NavItem(
          'Tính lương',
          Icons.payments_outlined,
          (key) => PayrollScreen(key: key),
        ),
        _NavItem(
          'Quản trị web',
          Icons.web_asset_outlined,
          (key) => WebAdminScreen(key: key),
        ),
      ]);
    } else {
      base.add(
        _NavItem(
          'Thông báo',
          Icons.notifications_outlined,
          (key) => NotificationsScreen(key: key, isAdmin: false),
        ),
      );
    }
    return base;
  }
}

class _NavItem {
  const _NavItem(this.label, this.icon, this.builder);

  final String label;
  final IconData icon;
  final Widget Function(Key key) builder;
}

class _WebSidebar extends StatelessWidget {
  const _WebSidebar({
    required this.items,
    required this.selectedIndex,
    required this.onSelect,
  });

  final List<_NavItem> items;
  final int selectedIndex;
  final ValueChanged<int> onSelect;

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 270,
      decoration: const BoxDecoration(
        color: Colors.white,
        border: Border(right: BorderSide(color: Color(0xFFE2E8F0))),
      ),
      child: ListView(
        padding: const EdgeInsets.fromLTRB(14, 18, 14, 18),
        children: [
          const Row(
            children: [
              BrandLogo(size: 46),
              SizedBox(width: 12),
              Expanded(
                child: Text(
                  brandName,
                  style: TextStyle(fontWeight: FontWeight.w900),
                ),
              ),
            ],
          ),
          const SizedBox(height: 18),
          for (var i = 0; i < items.length; i++)
            Padding(
              padding: const EdgeInsets.only(bottom: 6),
              child: ListTile(
                selected: i == selectedIndex,
                selectedTileColor: brandBlue.withValues(alpha: 0.10),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8),
                ),
                leading: Icon(items[i].icon),
                title: Text(items[i].label),
                onTap: () => onSelect(i),
              ),
            ),
        ],
      ),
    );
  }
}
