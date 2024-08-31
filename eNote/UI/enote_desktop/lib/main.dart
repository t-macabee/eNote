import 'package:enote_desktop/providers/instrumenti_provider.dart';
import 'package:enote_desktop/screens/login_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(providers: [
    ChangeNotifierProvider(create: (_) => InstrumentiProvider()),
  ], child: const MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'eNote',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: const Color.fromARGB(255, 114, 23, 16),
            primary: const Color.fromARGB(255, 114, 23, 16)),
        useMaterial3: true,
      ),
      home: const LoginScreen(),
    );
  }
}
