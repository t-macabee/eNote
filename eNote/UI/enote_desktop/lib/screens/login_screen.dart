// ignore_for_file: use_build_context_synchronously
import 'package:enote_desktop/extensions/elevated_button_extension.dart';
import 'package:enote_desktop/extensions/error_dialog_extension.dart';
import 'package:enote_desktop/extensions/text_field_extension.dart';
import 'package:enote_desktop/providers/auth_provider.dart';
import 'package:enote_desktop/screens/kurs_list_screen.dart';
import 'package:flutter/material.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  @override
  void dispose() {
    _usernameController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  void _login(BuildContext context) async {
    String username = _usernameController.text.trim();
    String password = _passwordController.text.trim();

    if (username.isEmpty || password.isEmpty) {
      showErrorDialog(context, "Unesite korisničko ime i lozinku.");
      return;
    }

    try {
      bool success = await AuthProvider.login(username, password);
      if (success) {
        Navigator.of(context).push(
          MaterialPageRoute(
            builder: (context) => const KursListScreen(),
          ),
        );
      } else {
        showErrorDialog(context, "Pogrešno korisničko ime ili lozinka.");
      }
    } catch (e) {
      showErrorDialog(context, e.toString());
    }
  }

  @override
  Widget build(BuildContext context) {
    const Color borderColor = Colors.white;
    const TextStyle whiteTextStyle = TextStyle(color: Colors.white);

    return Scaffold(
      body: Container(
        decoration: const BoxDecoration(
          gradient: LinearGradient(
            colors: [
              Color.fromARGB(213, 26, 89, 105),
              Color.fromARGB(255, 114, 23, 16)
            ],
            begin: Alignment.topLeft,
            end: Alignment.bottomRight,
          ),
        ),
        child: Center(
          child: Container(
            constraints: const BoxConstraints(
              maxWidth: 500,
              maxHeight: 500,
            ),
            child: Card(
              color: const Color.fromARGB(213, 26, 89, 105),
              elevation: 8,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(32.0),
                side: const BorderSide(
                  color: borderColor,
                  width: 2.0,
                ),
              ),
              child: SingleChildScrollView(
                child: Padding(
                  padding: const EdgeInsets.all(32.0),
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      const SizedBox(height: 30),
                      const Text(
                        'Dobrodošli u eNote',
                        style: TextStyle(
                          fontSize: 28,
                          fontWeight: FontWeight.bold,
                          color: Colors.white,
                        ),
                        textAlign: TextAlign.center,
                      ),
                      const SizedBox(height: 60),
                      SizedBox(
                        width: 350,
                        child: _usernameController.buildStyledTextField(
                          labelText: "Username",
                          borderColor: borderColor,
                          textStyle: whiteTextStyle,
                          icon: Icons.person,
                        ),
                      ),
                      const SizedBox(height: 40),
                      SizedBox(
                        width: 350,
                        child: _passwordController.buildStyledTextField(
                          labelText: "Password",
                          borderColor: borderColor,
                          textStyle: whiteTextStyle,
                          icon: Icons.lock,
                          obscureText: true,
                        ),
                      ),
                      const SizedBox(height: 70),
                      Padding(
                          padding: const EdgeInsets.symmetric(horizontal: 16.0),
                          child: 'Login'.buildStyledButton(
                              onPressed: () {
                                _login(context);
                              },
                              padding: const EdgeInsets.symmetric(
                                  horizontal: 50, vertical: 15))),
                      const SizedBox(height: 60)
                    ],
                  ),
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
