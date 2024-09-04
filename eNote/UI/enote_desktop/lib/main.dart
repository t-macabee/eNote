import 'package:enote_desktop/providers/instrumenti_provider.dart';
import 'package:enote_desktop/providers/korisnici_provider.dart';
import 'package:enote_desktop/screens/login_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(providers: [
    ChangeNotifierProvider<InstrumentiProvider>(
        create: (_) => InstrumentiProvider()),
    ChangeNotifierProvider<KorisniciProvider>(
        create: (_) => KorisniciProvider()),
  ], child: const MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'eNote',
      theme: ThemeData(
        useMaterial3: true,
      ),
      home: const LoginScreen(),
    );
  }
}
