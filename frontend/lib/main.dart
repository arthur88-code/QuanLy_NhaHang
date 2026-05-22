import 'package:flutter/material.dart';

import 'core/app_theme.dart';
import 'screens/login_screen.dart';

void main() {
  runApp(const RestaurantManagerApp());
}

class RestaurantManagerApp extends StatelessWidget {
  const RestaurantManagerApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: brandName,
      debugShowCheckedModeBanner: false,
      theme: buildAppTheme(),
      home: const LoginScreen(),
    );
  }
}
