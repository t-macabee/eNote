import 'package:enote_desktop/providers/auth_provider.dart';
import 'package:enote_desktop/screens/instrumenti_list_screen.dart';
import 'package:enote_desktop/screens/korisnici_list_screen.dart';
import 'package:enote_desktop/screens/login_screen.dart';
import 'package:flutter/material.dart';

class MasterScreen extends StatefulWidget {
  const MasterScreen(this.title, this.child, {super.key});
  final String title;
  final Widget child;

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  void _logout(BuildContext context) {
    AuthProvider.logout();
    Navigator.of(context).pushReplacement(
        MaterialPageRoute(builder: (context) => const LoginScreen()));
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text(
            widget.title,
            style: const TextStyle(color: Colors.white),
          ),
          iconTheme: const IconThemeData(color: Colors.white),
          backgroundColor: const Color.fromARGB(255, 114, 23, 16),
          actions: [
            Padding(
              padding: const EdgeInsets.only(right: 20.0),
              child: IconButton(
                  icon: const Icon(Icons.logout),
                  onPressed: () => _logout(context)),
            )
          ],
        ),
        drawer: Drawer(
          child: Column(
            children: [
              SizedBox(
                height: 150,
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    ListTile(
                        title: const Text("Korisnici"),
                        onTap: () {
                          Navigator.of(context).push(MaterialPageRoute(
                              builder: (context) =>
                                  const KorisniciListScreen()));
                        }),
                    ListTile(
                        title: const Text("Instrumenti"),
                        onTap: () {
                          Navigator.of(context).push(MaterialPageRoute(
                              builder: (context) =>
                                  const InstrumentiListScreen()));
                        }),
                  ],
                ),
              ),
              Expanded(
                  child: Container()), // This will push the content to the top
            ],
          ),
        ),
        body: widget.child);
  }
}
