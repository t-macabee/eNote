import 'package:flutter/material.dart';

extension DropdownButtonExtensions<T> on List<DropdownMenuItem<T>> {
  Widget buildStyledDropdown({
    required T? selectedValue,
    required ValueChanged<T?> onChanged,
    required String labelText,
    Color textColor = Colors.white,
    Color borderColor = Colors.white,
    Color dropdownColor = const Color.fromARGB(255, 49, 53, 61),
    Color? backgroundColor,
  }) {
    return DropdownButtonFormField<T>(
      decoration: InputDecoration(
        labelText: labelText,
        labelStyle: TextStyle(color: textColor),
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
        filled: backgroundColor != null,
        fillColor: backgroundColor,
      ),
      value: selectedValue,
      items: this,
      onChanged: onChanged,
      style: TextStyle(color: textColor),
      dropdownColor: dropdownColor,
      icon: Icon(Icons.arrow_drop_down, color: textColor),
      iconEnabledColor: textColor,
      iconDisabledColor: textColor.withOpacity(0.5),
    );
  }
}
