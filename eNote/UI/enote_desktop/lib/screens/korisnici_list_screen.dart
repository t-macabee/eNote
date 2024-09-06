import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/korisnik.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/models/uloge.dart';
import 'package:enote_desktop/providers/korisnici_provider.dart';
import 'package:enote_desktop/providers/uloge_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class KorisniciListScreen extends StatefulWidget {
  const KorisniciListScreen({super.key});

  @override
  State<KorisniciListScreen> createState() => _KorisniciListScreenState();
}

class _KorisniciListScreenState extends State<KorisniciListScreen> {
  late KorisniciProvider korisniciProvider;
  late UlogeProvider ulogeProvider;

  SearchResult<Korisnik>? korisniciResult;
  SearchResult<Uloge>? ulogeResult;

  final TextEditingController _imePrezimeSearch = TextEditingController();
  final TextEditingController _korisnickoImeSearch = TextEditingController();
  Uloge? _selectedUloga;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    korisniciProvider = context.read<KorisniciProvider>();
    ulogeProvider = context.read<UlogeProvider>();
    _loadKorisnici();
    _loadUloge();
  }

  Future<void> _loadKorisnici({Map<String, String>? filter}) async {
    korisniciResult = await korisniciProvider.get(filter: filter);
    setState(() {});
  }

  Future<void> _loadUloge() async {
    ulogeResult = await ulogeProvider.get();
    setState(() {});
  }

  void _applyFilters() async {
    var filter = {
      'imePrezime': _imePrezimeSearch.text,
      'korisnickoIme': _korisnickoImeSearch.text,
      'uloga': _selectedUloga?.id.toString()
    };

    filter.removeWhere((key, value) {
      if (value == null) return true;
      return value.isEmpty;
    });

    var validFilter = filter.cast<String, String>();
    await _loadKorisnici(filter: validFilter);
  }

  void _resetFilters() {
    _imePrezimeSearch.clear();
    _korisnickoImeSearch.clear();
    _selectedUloga = null;
    _loadKorisnici();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Korisnici",
        Column(
          children: [
            _buildSearch(),
            const SizedBox(
              height: 50,
            ),
            _buildResult()
          ],
        ));
  }

  Widget _buildSearch() {
    const double padding = 10.0;
    const double space = 25.0;

    return Padding(
      padding: const EdgeInsets.all(padding),
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            SizedBox(
              width: 200,
              child: buildStyledTextField(
                controller: _imePrezimeSearch,
                labelText: "Ime ili prezime",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: buildStyledTextField(
                controller: _korisnickoImeSearch,
                labelText: "Korisničko ime",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: DropdownButtonFormField<Uloge>(
                decoration: InputDecoration(
                  labelText: "Uloge",
                  labelStyle: const TextStyle(color: Colors.white),
                  border: OutlineInputBorder(
                    borderSide:
                        const BorderSide(width: 2.0, color: Colors.white),
                    borderRadius: BorderRadius.circular(12.0),
                  ),
                  enabledBorder: OutlineInputBorder(
                    borderSide:
                        const BorderSide(width: 1.0, color: Colors.white),
                    borderRadius: BorderRadius.circular(12.0),
                  ),
                  focusedBorder: OutlineInputBorder(
                    borderSide:
                        const BorderSide(width: 2.0, color: Colors.white),
                    borderRadius: BorderRadius.circular(12.0),
                  ),
                ),
                value: _selectedUloga,
                items: [
                  const DropdownMenuItem<Uloge>(
                    value: null,
                    child: Text('Svi korisnici',
                        style: TextStyle(color: Colors.white)),
                  ),
                  ...?ulogeResult?.result.map((Uloge option) {
                    return DropdownMenuItem<Uloge>(
                      value: option,
                      child: Text(option.naziv ?? "",
                          style: const TextStyle(color: Colors.white)),
                    );
                  }),
                ],
                onChanged: (value) {
                  setState(() {
                    _selectedUloga = value;
                  });
                },
                style: const TextStyle(color: Colors.white),
                dropdownColor: const Color.fromARGB(255, 49, 53, 61),
              ),
            ),
            const SizedBox(width: 40.0),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.transparent,
                side: const BorderSide(color: Colors.white, width: 2),
                padding:
                    const EdgeInsets.symmetric(horizontal: 50, vertical: 12),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 4,
              ),
              onPressed: _applyFilters,
              child: const Text('Pretraga'),
            ),
            const SizedBox(width: space),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.transparent,
                side: const BorderSide(color: Colors.white, width: 2),
                padding:
                    const EdgeInsets.symmetric(horizontal: 50, vertical: 12),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 4,
              ),
              onPressed: _resetFilters,
              child: const Text('Reset filtera'),
            ),
            const SizedBox(width: space),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.transparent,
                side: const BorderSide(color: Colors.white, width: 2),
                padding:
                    const EdgeInsets.symmetric(horizontal: 50, vertical: 12),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 4,
              ),
              onPressed: () {},
              child: const Text('Novi korisnik'),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildResult() {
    return Expanded(
      child: LayoutBuilder(
        builder: (context, constraints) {
          double cardWidth = (constraints.maxWidth / 6) - 8.0;
          double cardHeight = cardWidth * 1.5;

          return SingleChildScrollView(
            child: GridView.builder(
              shrinkWrap: true,
              physics: const NeverScrollableScrollPhysics(),
              gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 7,
                childAspectRatio: 1.5,
                mainAxisSpacing: 24.0,
                crossAxisSpacing: 24.0,
              ),
              itemCount: korisniciResult?.result.length ?? 0,
              itemBuilder: (context, index) {
                final korisnik = korisniciResult!.result[index];
                bool isHovered = false;

                return StatefulBuilder(
                  builder: (context, setState) {
                    return MouseRegion(
                      cursor: SystemMouseCursors.click,
                      onEnter: (_) => setState(() => isHovered = true),
                      onExit: (_) => setState(() => isHovered = false),
                      child: Card(
                        margin: EdgeInsets.zero,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(16.0),
                        ),
                        clipBehavior: Clip.antiAlias,
                        child: Stack(
                          children: [
                            Image.asset(
                              'assets/images/user.png',
                              width: cardWidth,
                              height: cardHeight,
                              fit: BoxFit.cover,
                            ),
                            Positioned.fill(
                              child: AnimatedOpacity(
                                opacity: isHovered ? 1.0 : 0.0,
                                duration: const Duration(milliseconds: 200),
                                child: Container(
                                  color: Colors.black54,
                                  child: Center(
                                    child: Column(
                                      mainAxisAlignment:
                                          MainAxisAlignment.center,
                                      crossAxisAlignment:
                                          CrossAxisAlignment.center,
                                      children: [
                                        Text(
                                          '${korisnik.ime ?? ""} ${korisnik.prezime ?? ""}'
                                              .trim(),
                                          style: const TextStyle(
                                            color: Colors.white,
                                            fontSize: 16.0,
                                          ),
                                          textAlign: TextAlign.center,
                                        ),
                                        Text(
                                          korisnik.uloga ?? "",
                                          style: const TextStyle(
                                            color: Colors.white,
                                            fontSize: 14.0,
                                          ),
                                          textAlign: TextAlign.center,
                                        ),
                                      ],
                                    ),
                                  ),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                    );
                  },
                );
              },
            ),
          );
        },
      ),
    );
  }

  Widget buildStyledTextField({
    required TextEditingController controller,
    required String labelText,
  }) {
    return TextField(
      controller: controller,
      style: const TextStyle(color: Colors.white),
      cursorColor: Colors.white,
      decoration: InputDecoration(
        border: OutlineInputBorder(
          borderSide: const BorderSide(width: 2.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        enabledBorder: OutlineInputBorder(
          borderSide: const BorderSide(width: 1.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        focusedBorder: OutlineInputBorder(
          borderSide: const BorderSide(width: 2.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        floatingLabelBehavior: FloatingLabelBehavior.auto,
        labelText: labelText,
        labelStyle: const TextStyle(color: Colors.white),
      ),
    );
  }
}
