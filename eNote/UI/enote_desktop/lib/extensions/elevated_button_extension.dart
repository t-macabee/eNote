import 'package:flutter/material.dart';

extension ButtonExtensions on String {
  ElevatedButton buildStyledButton({
    required VoidCallback onPressed,
    Color foregroundColor = Colors.white,
    Color backgroundColor = Colors.transparent,
    BorderSide side = const BorderSide(color: Colors.white, width: 2),
    EdgeInsetsGeometry padding =
        const EdgeInsets.symmetric(horizontal: 50, vertical: 12),
    OutlinedBorder? shape,
    double elevation = 4,
    Widget? child,
  }) {
    shape ??= RoundedRectangleBorder(borderRadius: BorderRadius.circular(8.0));

    return ElevatedButton(
      style: ElevatedButton.styleFrom(
        foregroundColor: foregroundColor,
        backgroundColor: backgroundColor,
        side: side,
        padding: padding,
        shape: shape,
        elevation: elevation,
      ),
      onPressed: onPressed,
      child: child ?? Text(this),
    );
  }
}
