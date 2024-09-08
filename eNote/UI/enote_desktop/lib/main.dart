import 'package:enote_desktop/providers/adresa_provider.dart';
import 'package:enote_desktop/providers/instrumenti_provider.dart';
import 'package:enote_desktop/providers/korisnici_provider.dart';
import 'package:enote_desktop/providers/kurs_provider.dart';
import 'package:enote_desktop/providers/music_shop_provider.dart';
import 'package:enote_desktop/providers/predavanje_provider.dart';
import 'package:enote_desktop/providers/tip_predavanja_provider.dart';
import 'package:enote_desktop/providers/uloge_provider.dart';
import 'package:enote_desktop/providers/vrsta_instrumenta_provider.dart';
import 'package:enote_desktop/screens/login_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(providers: [
    ChangeNotifierProvider<InstrumentiProvider>(
        create: (_) => InstrumentiProvider()),
    ChangeNotifierProvider<KorisniciProvider>(
        create: (_) => KorisniciProvider()),
    ChangeNotifierProvider<VrstaInstrumentaProvider>(
        create: (_) => VrstaInstrumentaProvider()),
    ChangeNotifierProvider<UlogeProvider>(create: (_) => UlogeProvider()),
    ChangeNotifierProvider<AdresaProvider>(create: (_) => AdresaProvider()),
    ChangeNotifierProvider<MusicShopProvider>(
        create: (_) => MusicShopProvider()),
    ChangeNotifierProvider<KursProvider>(create: (_) => KursProvider()),
    ChangeNotifierProvider<PredavanjeProvider>(
        create: (_) => PredavanjeProvider()),
    ChangeNotifierProvider<TipPredavanjaProvider>(
        create: (_) => TipPredavanjaProvider()),
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
