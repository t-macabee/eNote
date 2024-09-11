import 'package:enote_desktop/extensions/text_styling_extension.dart';
import 'package:flutter/material.dart';

extension ListTileStyling on ListTile {
  static ListTile styledDrawerItem({
    required IconData icon,
    required String text,
    required VoidCallback onTap,
  }) {
    return ListTile(
      leading: Icon(icon, color: Colors.white),
      title: Text(
        text,
        style: TextStyling.drawerItemStyle(),
      ),
      onTap: onTap,
    );
  }
}
