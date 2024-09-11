import 'package:flutter/material.dart';

extension TextStyling on Text {
  static TextStyle masterScreenTitleStyle() {
    return const TextStyle(
      color: Colors.white,
      fontWeight: FontWeight.bold,
    );
  }

  static TextStyle drawerAccountNameStyle() {
    return const TextStyle(
      color: Colors.white,
      fontSize: 20,
      fontWeight: FontWeight.bold,
    );
  }

  static TextStyle drawerAccountEmailStyle() {
    return const TextStyle(
      color: Colors.white,
    );
  }

  static TextStyle drawerItemStyle() {
    return const TextStyle(
      color: Colors.white,
      fontSize: 16,
    );
  }
}
