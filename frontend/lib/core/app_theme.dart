import 'package:flutter/material.dart';

const brandName = 'Quản Lý Nhà Hàng';
const brandBlue = Color(0xFF0284C7);
const brandDark = Color(0xFF111827);
const brandInk = Color(0xFF0F172A);
const brandSurface = Color(0xFFF8FAFC);
const brandGreen = Color(0xFF16A34A);
const brandOrange = Color(0xFFF59E0B);
const restaurantHeroImage =
    'https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?auto=format&fit=crop&w=1400&q=75';

ThemeData buildAppTheme() {
  return ThemeData(
    useMaterial3: true,
    colorScheme: ColorScheme.fromSeed(seedColor: brandBlue).copyWith(
      primary: brandBlue,
      secondary: const Color(0xFF0EA5E9),
      tertiary: brandOrange,
      surface: Colors.white,
    ),
    scaffoldBackgroundColor: brandSurface,
    appBarTheme: const AppBarTheme(
      centerTitle: false,
      backgroundColor: Colors.white,
      foregroundColor: brandInk,
      surfaceTintColor: Colors.transparent,
      elevation: 0,
    ),
    filledButtonTheme: FilledButtonThemeData(
      style: FilledButton.styleFrom(
        backgroundColor: brandBlue,
        foregroundColor: Colors.white,
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(8)),
      ),
    ),
    inputDecorationTheme: InputDecorationTheme(
      filled: true,
      fillColor: Colors.white,
      border: OutlineInputBorder(borderRadius: BorderRadius.circular(8)),
    ),
    cardTheme: const CardThemeData(
      elevation: 0,
      margin: EdgeInsets.zero,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.all(Radius.circular(8)),
        side: BorderSide(color: Color(0xFFE3E7EA)),
      ),
    ),
  );
}

class BrandLogo extends StatelessWidget {
  const BrandLogo({super.key, this.size = 72, this.framed = true});

  final double size;
  final bool framed;

  @override
  Widget build(BuildContext context) {
    final logo = CustomPaint(
      painter: _BrandLogoPainter(),
      size: Size.square(size),
    );
    if (!framed) return logo;
    return Container(
      width: size,
      height: size,
      padding: EdgeInsets.all(size * 0.08),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(12),
        border: Border.all(color: const Color(0xFFE2E8F0)),
        boxShadow: const [
          BoxShadow(
            color: Color(0x1A0284C7),
            blurRadius: 24,
            offset: Offset(0, 10),
          ),
        ],
      ),
      child: SizedBox.expand(child: CustomPaint(painter: _BrandLogoPainter())),
    );
  }
}

class _BrandLogoPainter extends CustomPainter {
  @override
  void paint(Canvas canvas, Size size) {
    final scale = size.shortestSide / 108;
    canvas
      ..save()
      ..scale(scale, scale);
    final black = Paint()..color = brandDark;
    final blue = Paint()..color = brandBlue;

    canvas.drawPath(
      (Path()..fillType = PathFillType.evenOdd)
        ..moveTo(45, 12)
        ..lineTo(63, 22)
        ..lineTo(63, 88)
        ..lineTo(56, 92)
        ..lineTo(56, 102)
        ..lineTo(52, 102)
        ..lineTo(52, 92)
        ..lineTo(45, 88)
        ..close()
        ..moveTo(51, 30)
        ..lineTo(51, 80)
        ..lineTo(57, 80)
        ..lineTo(57, 30)
        ..lineTo(54, 27)
        ..close(),
      black,
    );
    canvas.drawPath(
      Path()
        ..moveTo(15, 34)
        ..lineTo(42, 18)
        ..lineTo(42, 30)
        ..lineTo(24, 41)
        ..lineTo(24, 54)
        ..lineTo(40, 45)
        ..lineTo(40, 57)
        ..lineTo(24, 66)
        ..lineTo(24, 78)
        ..lineTo(42, 89)
        ..lineTo(42, 101)
        ..lineTo(15, 85)
        ..close(),
      black,
    );
    canvas.drawPath(
      Path()
        ..moveTo(66, 26)
        ..lineTo(84, 36)
        ..lineTo(84, 54)
        ..lineTo(93, 59)
        ..lineTo(93, 31)
        ..lineTo(101, 36)
        ..lineTo(101, 80)
        ..lineTo(93, 85)
        ..lineTo(93, 67)
        ..lineTo(84, 62)
        ..lineTo(84, 83)
        ..lineTo(66, 93)
        ..close(),
      black,
    );
    canvas.drawRect(const Rect.fromLTWH(48, 82, 12, 4), blue);
    canvas.restore();
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) => false;
}
