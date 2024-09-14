import 'package:flutter/material.dart';

extension TextFieldExtensions on TextEditingController {
  Widget buildStyledTextField({
    required String labelText,
    Color borderColor = Colors.white,
    TextStyle textStyle = const TextStyle(color: Colors.white),
    IconData? icon,
    bool obscureText = false,
    bool enabled = true,
    Color fillColor = Colors.transparent,
  }) {
    return TextField(
      controller: this,
      style: textStyle,
      cursorColor: Colors.white,
      obscureText: obscureText,
      enabled: enabled,
      decoration: InputDecoration(
        filled: true,
        fillColor: fillColor,
        border: OutlineInputBorder(
          borderSide: const BorderSide(width: 2.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        enabledBorder: OutlineInputBorder(
          borderSide: const BorderSide(width: 1.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        focusedBorder: OutlineInputBorder(
          borderSide: const BorderSide(width: 2.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        disabledBorder: OutlineInputBorder(
          borderSide: const BorderSide(width: 1.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        floatingLabelBehavior: FloatingLabelBehavior.auto,
        labelText: labelText,
        labelStyle: textStyle,
        prefixIcon: icon != null ? Icon(icon, color: Colors.white) : null,
      ),
    );
  }
}
