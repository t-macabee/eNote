import 'package:enote_desktop/providers/auth_provider.dart';
import 'package:enote_desktop/screens/instrumenti_list_screen.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'eNote',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.grey, primary: Colors.blueGrey),
        useMaterial3: true,
      ),
      home: LoginPage(),
    );
  }
}

class LoginPage extends StatelessWidget {
  LoginPage({super.key});

  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Login"),
      ),
      body: Center(
          child: Center(
              child: Container(
        constraints: const BoxConstraints(maxHeight: 400, maxWidth: 400),
        child: Card(
            child: Column(children: [
          Image.asset(
            'assets/images/logo.png',
            height: 130,
            width: 130,
          ),
          const SizedBox(
            height: 15,
          ),
          TextField(
              controller: _usernameController,
              decoration: const InputDecoration(
                  labelText: "Korisničko ime", prefixIcon: Icon(Icons.man_2))),
          const SizedBox(
            height: 15,
          ),
          TextField(
              controller: _passwordController,
              decoration: const InputDecoration(
                  labelText: "Lozinka", prefixIcon: Icon(Icons.password))),
          const SizedBox(
            height: 10,
          ),
          ElevatedButton(
              onPressed: () async {
                AuthProvider.username = _usernameController.text;
                AuthProvider.password = _passwordController.text;
                try {
                  Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) => const InstrumentiListScreen()));
                } on Exception catch (e) {
                  showDialog(
                      context: context,
                      builder: (context) => AlertDialog(
                          title: const Text("Error"),
                          actions: [
                            TextButton(
                                onPressed: () => Navigator.pop(context),
                                child: const Text("OK"))
                          ],
                          content: Text(e.toString())));
                }
              },
              child: const Text("Login")),
        ])),
      ))),
    );
  }
}
