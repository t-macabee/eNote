import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:flutter/material.dart';

class InstrumentiListScreen extends StatelessWidget {
  const InstrumentiListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Lista instrumenata",
        Column(
          children: [
            const Text("Lista instrumenata placeholder"),
            const SizedBox(height: 8),
            ElevatedButton(
                onPressed: () {
                  Navigator.pop(context);
                },
                child: const Text("Back"))
          ],
        ));
  }
}
