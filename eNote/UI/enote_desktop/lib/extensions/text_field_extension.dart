import 'package:flutter/material.dart';

extension TextFieldExtensions on TextEditingController {
  Widget buildStyledTextField({
    required String labelText,
    Color borderColor = Colors.white,
    TextStyle textStyle = const TextStyle(color: Colors.white),
    IconData? icon,
    bool obscureText = false,
  }) {
    return TextField(
      controller: this,
      style: textStyle,
      cursorColor: Colors.white,
      obscureText: obscureText,
      decoration: InputDecoration(
        border: OutlineInputBorder(
          borderSide: BorderSide(width: 2.0, color: borderColor),
          borderRadius: BorderRadius.circular(12.0),
        ),
        enabledBorder: OutlineInputBorder(
          borderSide: BorderSide(width: 1.0, color: borderColor),
          borderRadius: BorderRadius.circular(12.0),
        ),
        focusedBorder: OutlineInputBorder(
          borderSide: BorderSide(width: 2.0, color: borderColor),
          borderRadius: BorderRadius.circular(12.0),
        ),
        floatingLabelBehavior: FloatingLabelBehavior.auto,
        labelText: labelText,
        labelStyle: textStyle,
        prefixIcon: icon != null ? Icon(icon, color: borderColor) : null,
      ),
    );
  }
}
