import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/korisnik.dart';
import 'package:enote_desktop/models/kurs.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/providers/korisnici_provider.dart';
import 'package:enote_desktop/providers/kurs_provider.dart';
import 'package:enote_desktop/screens/predavanja_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class KursListScreen extends StatefulWidget {
  const KursListScreen({super.key});

  @override
  State<KursListScreen> createState() => _KursListScreenState();
}

class _KursListScreenState extends State<KursListScreen> {
  late KursProvider kursProvider;
  late KorisniciProvider korisniciProvider;

  SearchResult<Kurs>? kursResult;
  SearchResult<Korisnik>? korisniciResult;

  final TextEditingController _nazivSearch = TextEditingController();
  Korisnik? _selectedKorisnik;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    kursProvider = context.read<KursProvider>();
    korisniciProvider = context.read<KorisniciProvider>();

    _loadKurs();
    _loadKorisnici();
  }

  Future<void> _loadKurs({Map<String, String>? filter}) async {
    kursResult = await kursProvider.get(filter: filter);
    setState(() {});
  }

  Future<void> _loadKorisnici({Map<String, String>? filter}) async {
    korisniciResult = await korisniciProvider.get(filter: filter);
    setState(() {});
  }

  void _applyFilters() async {
    var filter = {
      'naziv': _nazivSearch.text,
      'instruktorId': _selectedKorisnik?.id.toString()
    };

    filter.removeWhere((key, value) {
      return value == null || value.isEmpty;
    });

    var validFilter = filter.cast<String, String>();
    await _loadKurs(filter: validFilter);
  }

  void _resetFilters() {
    _nazivSearch.clear();
    _selectedKorisnik = null;
    _loadKurs();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Kurs",
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
          children: [
            SizedBox(
              width: 200,
              child: buildStyledTextField(
                controller: _nazivSearch,
                labelText: "Naziv",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: DropdownButtonFormField<Korisnik>(
                decoration: InputDecoration(
                  labelText: "Instruktor",
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
                        const BorderSide(width: 1.0, color: Colors.white),
                    borderRadius: BorderRadius.circular(12.0),
                  ),
                ),
                value: _selectedKorisnik,
                items: [
                  const DropdownMenuItem<Korisnik>(
                    value: null,
                    child: Text('Svi instruktori',
                        style: TextStyle(color: Colors.white)),
                  ),
                  ...?korisniciResult?.result
                      .where((Korisnik option) => option.uloga == 'Instruktor')
                      .map((Korisnik option) {
                    return DropdownMenuItem<Korisnik>(
                      value: option,
                      child: Text(
                          '${option.ime ?? ""} ${option.prezime ?? ""}'.trim(),
                          style: const TextStyle(color: Colors.white)),
                    );
                  }),
                ],
                onChanged: (value) {
                  setState(() {
                    _selectedKorisnik = value;
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
              onPressed: () async {},
              child: const Text('Novi kurs'),
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
          double cardWidth = (constraints.maxWidth / 4) - 8.0;
          double cardHeight = cardWidth * 2.5;

          return SingleChildScrollView(
            child: GridView.builder(
              shrinkWrap: true,
              physics: const NeverScrollableScrollPhysics(),
              gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 4,
                childAspectRatio: 3.0,
                mainAxisSpacing: 24.0,
                crossAxisSpacing: 24.0,
              ),
              itemCount: kursResult?.result.length ?? 0,
              itemBuilder: (context, index) {
                final kurs = kursResult!.result[index];
                bool isHovered = false;

                return StatefulBuilder(
                  builder: (context, setState) {
                    return GestureDetector(
                      child: MouseRegion(
                        cursor: SystemMouseCursors.click,
                        onEnter: (_) => setState(() => isHovered = true),
                        onExit: (_) => setState(() => isHovered = false),
                        child: SizedBox(
                          width: cardWidth,
                          height: cardHeight,
                          child: Card(
                            margin: EdgeInsets.zero,
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(16.0),
                            ),
                            clipBehavior: Clip.antiAlias,
                            child: Stack(
                              children: [
                                Container(
                                  decoration: BoxDecoration(
                                    gradient: const LinearGradient(
                                      colors: [
                                        Color.fromARGB(213, 26, 89, 105),
                                        Color.fromARGB(255, 114, 23, 16)
                                      ],
                                      begin: Alignment.topLeft,
                                      end: Alignment.bottomRight,
                                    ),
                                    borderRadius: BorderRadius.circular(16.0),
                                  ),
                                  child: Center(
                                    child: Padding(
                                      padding:
                                          const EdgeInsets.only(bottom: 40.0),
                                      child: Text(
                                        kurs.naziv ?? "",
                                        style: const TextStyle(
                                          color: Colors.white,
                                          fontSize: 16.0,
                                          fontWeight: FontWeight.bold,
                                        ),
                                        textAlign: TextAlign.center,
                                      ),
                                    ),
                                  ),
                                ),
                                Positioned(
                                  bottom: 16,
                                  left: 0,
                                  right: 0,
                                  child: AnimatedOpacity(
                                    opacity: isHovered ? 1.0 : 0.0,
                                    duration: const Duration(milliseconds: 200),
                                    child: Padding(
                                      padding: const EdgeInsets.symmetric(
                                          horizontal: 16.0),
                                      child: Row(
                                        mainAxisSize: MainAxisSize.min,
                                        mainAxisAlignment:
                                            MainAxisAlignment.center,
                                        children: [
                                          ElevatedButton(
                                            style: buildButtonStyleForCard(),
                                            onPressed: () {},
                                            child: const Text('Detalji'),
                                          ),
                                          const SizedBox(width: 8.0),
                                          ElevatedButton(
                                            style: buildButtonStyleForCard(),
                                            onPressed: () {
                                              Navigator.of(context).push(
                                                MaterialPageRoute(
                                                  builder: (context) =>
                                                      PredavanjaListScreen(
                                                    kursId: kurs.id,
                                                    kursNaziv: kurs.naziv,
                                                  ),
                                                ),
                                              );
                                            },
                                            child: const Text('Predavanja'),
                                          ),
                                        ],
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
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

  ButtonStyle buildButtonStyleForCard() {
    return ElevatedButton.styleFrom(
      foregroundColor: Colors.white,
      backgroundColor: Colors.transparent,
      side: const BorderSide(color: Colors.white, width: 2),
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 8),
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(8.0),
      ),
      elevation: 4,
    );
  }
}
