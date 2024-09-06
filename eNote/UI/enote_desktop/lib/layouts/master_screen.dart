import 'package:enote_desktop/providers/auth_provider.dart';
import 'package:enote_desktop/screens/korisnici_list_screen.dart';
import 'package:enote_desktop/screens/login_screen.dart';
import 'package:enote_desktop/screens/music_shop_list_screen.dart';
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
            style: const TextStyle(
              color: Colors.white,
              fontWeight: FontWeight.bold,
            ),
          ),
          iconTheme: const IconThemeData(color: Colors.white),
          backgroundColor: const Color.fromARGB(213, 26, 89, 105),
          elevation: 0,
          flexibleSpace: Container(
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
          ),
        ),
        drawer: Drawer(
          backgroundColor: const Color.fromARGB(255, 26, 89, 105),
          child: Stack(
            children: [
              Column(
                children: [
                  UserAccountsDrawerHeader(
                    decoration: const BoxDecoration(
                      color: Color.fromARGB(213, 26, 89, 105),
                    ),
                    accountName: Text(
                      AuthProvider.currentUser?.korisnickoIme ?? '',
                      style: const TextStyle(
                        color: Colors.white,
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    accountEmail: Text(
                      AuthProvider.currentUser?.email ?? '',
                      style: const TextStyle(
                        color: Colors.white,
                      ),
                    ),
                    currentAccountPicture: const CircleAvatar(
                      backgroundImage:
                          AssetImage('assets/images/user.png') as ImageProvider,
                      backgroundColor: Colors.white,
                    ),
                  ),
                  Expanded(
                    child: ListView(
                      padding: EdgeInsets.zero,
                      children: [
                        const SizedBox(height: 20),
                        _buildDrawerItem(
                          icon: Icons.people,
                          text: "Korisnici",
                          onTap: () {
                            Navigator.of(context).pushReplacement(
                                MaterialPageRoute(
                                    builder: (context) =>
                                        const KorisniciListScreen()));
                          },
                        ),
                        const SizedBox(height: 20),
                        _buildDrawerItem(
                          icon: Icons.store,
                          text: "Music Shop",
                          onTap: () {
                            Navigator.of(context).pushReplacement(
                                MaterialPageRoute(
                                    builder: (context) =>
                                        const MusicShopListScreen()));
                          },
                        ),
                      ],
                    ),
                  ),
                ],
              ),
              Positioned(
                top: 20,
                right: 10,
                child: IconButton(
                  icon: const Icon(Icons.logout, color: Colors.white),
                  onPressed: () => _logout(context),
                ),
              ),
            ],
          ),
        ),
        body: Container(
          decoration: const BoxDecoration(
            gradient: LinearGradient(
              colors: [
                Color.fromARGB(170, 26, 89, 105),
                Color.fromARGB(170, 114, 23, 16),
              ],
              begin: Alignment.topLeft,
              end: Alignment.bottomRight,
            ),
          ),
          child: Center(
            child: Padding(
              padding: const EdgeInsets.all(12.0),
              child: widget.child,
            ),
          ),
        ));
  }

  Widget _buildDrawerItem({
    required IconData icon,
    required String text,
    required VoidCallback onTap,
  }) {
    return ListTile(
      leading: Icon(icon, color: Colors.white),
      title: Text(
        text,
        style: const TextStyle(color: Colors.white, fontSize: 16),
      ),
      onTap: onTap,
    );
  }
}
