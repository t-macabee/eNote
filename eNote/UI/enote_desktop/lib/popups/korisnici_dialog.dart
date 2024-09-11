import 'package:flutter/material.dart';

class KorisniciDialog extends StatelessWidget {
  const KorisniciDialog({super.key});

  @override
  Widget build(BuildContext context) {
    const borderColor = Color.fromARGB(255, 0, 150, 135);
    const textStyle = TextStyle(color: Colors.white);

    return AlertDialog(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(16.0),
        side: const BorderSide(color: borderColor, width: 2.0),
      ),
      title: const Padding(
        padding: EdgeInsets.all(16.0),
        child: Text(
          'Dialog Title',
          style: TextStyle(
            fontSize: 24,
            fontWeight: FontWeight.bold,
            color: Colors.white,
          ),
          textAlign: TextAlign.center,
        ),
      ),
      content: const SizedBox(
        width: 400,
        height: 300,
        child: Padding(
          padding: EdgeInsets.all(16.0),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Text(
                'This is the content of the dialog.',
                style: textStyle,
                textAlign: TextAlign.center,
              ),
            ],
          ),
        ),
      ),
      backgroundColor: const Color.fromARGB(255, 26, 89, 105),
      actionsPadding: const EdgeInsets.symmetric(horizontal: 16.0),
      actions: [
        SizedBox(
          width: 100,
          child: TextButton(
            onPressed: () {
              Navigator.of(context).pop();
            },
            style: TextButton.styleFrom(
              foregroundColor: Colors.white,
            ),
            child: const Text('Cancel'),
          ),
        ),
        SizedBox(
          width: 100,
          child: ElevatedButton(
            onPressed: () {
              Navigator.of(context).pop();
            },
            style: ElevatedButton.styleFrom(
              foregroundColor: Colors.white,
              backgroundColor: Colors.transparent,
              side: const BorderSide(color: borderColor, width: 2.0),
              padding:
                  const EdgeInsets.symmetric(horizontal: 24.0, vertical: 12.0),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(8.0),
              ),
              elevation: 4,
            ),
            child: const Text('OK'),
          ),
        ),
      ],
    );
  }
}
