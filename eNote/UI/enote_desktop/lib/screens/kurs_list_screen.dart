import 'package:enote_desktop/extensions/dropdown_button_extension.dart';
import 'package:enote_desktop/extensions/elevated_button_extension.dart';
import 'package:enote_desktop/extensions/text_field_extension.dart';
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

  final ValueNotifier<Korisnik?> _selectedKorisnik = ValueNotifier(null);

  @override
  void initState() {
    super.initState();
    kursProvider = context.read<KursProvider>();
    korisniciProvider = context.read<KorisniciProvider>();

    _loadKurs();
    _loadKorisnici();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
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
      'instruktorId': _selectedKorisnik.value?.id.toString()
    };

    filter.removeWhere((key, value) {
      return value == null || value.isEmpty;
    });

    var validFilter = filter.cast<String, String>();
    await _loadKurs(filter: validFilter);
  }

  void _resetFilters() {
    _nazivSearch.clear();
    _selectedKorisnik.value = null;
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
              child: _nazivSearch.buildStyledTextField(
                labelText: "Naziv",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: ValueListenableBuilder<Korisnik?>(
                valueListenable: _selectedKorisnik,
                builder: (context, selectedValue, child) {
                  return korisniciResult?.result
                          .where(
                              (Korisnik option) => option.uloga == "Instruktor")
                          .map((Korisnik option) {
                            return DropdownMenuItem<Korisnik>(
                              value: option,
                              child: Text(
                                  '${option.ime ?? ""} ${option.prezime ?? ""}',
                                  style: const TextStyle(color: Colors.white)),
                            );
                          })
                          .toList()
                          .buildStyledDropdown(
                            selectedValue: selectedValue,
                            onChanged: (Korisnik? value) {
                              _selectedKorisnik.value = value;
                            },
                            labelText: "Instruktori",
                          ) ??
                      const SizedBox.shrink();
                },
              ),
            ),
            const SizedBox(width: 40.0),
            SizedBox(
              width: 200,
              child: 'Pretraga'.buildStyledButton(
                onPressed: _applyFilters,
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: 'Reset filtera'.buildStyledButton(
                onPressed: _resetFilters,
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: 'Novi kurs'.buildStyledButton(
                onPressed: () async {},
              ),
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
                crossAxisCount: 5,
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
                                      child: ConstrainedBox(
                                        constraints: const BoxConstraints(
                                          maxHeight: 80.0,
                                        ),
                                        child: Wrap(
                                          spacing: 8.0,
                                          runSpacing: 8.0,
                                          alignment: WrapAlignment.center,
                                          children: [
                                            'Detalji'.buildStyledButton(
                                              onPressed: () {},
                                              padding:
                                                  const EdgeInsets.symmetric(
                                                      horizontal: 20,
                                                      vertical: 8),
                                            ),
                                            'Predavanja'.buildStyledButton(
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
                                              padding:
                                                  const EdgeInsets.symmetric(
                                                      horizontal: 20,
                                                      vertical: 8),
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
}
