import 'package:flutter_test/flutter_test.dart';
import 'package:restaurant_manager/main.dart';

void main() {
  testWidgets('Login screen opens', (WidgetTester tester) async {
    await tester.pumpWidget(const RestaurantManagerApp());

    expect(find.text('Quản Lý Nhà Hàng'), findsOneWidget);
    expect(find.text('Đăng nhập'), findsOneWidget);
  });
}
