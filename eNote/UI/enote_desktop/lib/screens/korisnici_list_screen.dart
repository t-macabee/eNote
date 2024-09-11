import 'dart:convert';
import 'package:enote_desktop/extensions/dropdown_button_extension.dart';
import 'package:enote_desktop/extensions/elevated_button_extension.dart';
import 'package:enote_desktop/extensions/text_field_extension.dart';
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

  final ValueNotifier<Uloge?> _selectedUloga = ValueNotifier(null);

  @override
  void initState() {
    super.initState();
    korisniciProvider = context.read<KorisniciProvider>();
    ulogeProvider = context.read<UlogeProvider>();

    _loadKorisnici();
    _loadUloge();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
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
      'uloga': _selectedUloga.value?.id.toString()
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
    _selectedUloga.value = null;
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
              child: _imePrezimeSearch.buildStyledTextField(
                labelText: "Ime ili prezime",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: _korisnickoImeSearch.buildStyledTextField(
                labelText: "Korisničko ime",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: ValueListenableBuilder<Uloge?>(
                valueListenable: _selectedUloga,
                builder: (context, selectedValue, child) {
                  return ulogeResult?.result
                          .where((Uloge option) => option.naziv != "Shop")
                          .map((Uloge option) {
                            return DropdownMenuItem<Uloge>(
                              value: option,
                              child: Text(option.naziv ?? "",
                                  style: const TextStyle(color: Colors.white)),
                            );
                          })
                          .toList()
                          .buildStyledDropdown(
                            selectedValue: selectedValue,
                            onChanged: (Uloge? value) {
                              _selectedUloga.value = value;
                            },
                            labelText: "Svi korisnici",
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
              child: 'Novi korisnik'.buildStyledButton(
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
          double cardWidth = (constraints.maxWidth / 6) - 8.0;
          double cardHeight = cardWidth * 1.0;

          return SingleChildScrollView(
            child: GridView.builder(
              shrinkWrap: true,
              physics: const NeverScrollableScrollPhysics(),
              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 7,
                childAspectRatio: cardWidth / cardHeight,
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
                            korisnik.slika != null && korisnik.slika!.isNotEmpty
                                ? Image.memory(
                                    base64Decode(korisnik.slika!),
                                    width: cardWidth,
                                    height: cardHeight,
                                    fit: BoxFit.cover,
                                  )
                                : Image.asset(
                                    'assets/images/stock-user.jpg',
                                    width: cardWidth,
                                    height: cardHeight,
                                    fit: BoxFit.cover,
                                  ),
                            Positioned(
                              top: 0.0,
                              left: 0,
                              right: 0,
                              child: Container(
                                padding: const EdgeInsets.symmetric(
                                    vertical: 6.0, horizontal: 8.0),
                                decoration: const BoxDecoration(
                                  gradient: LinearGradient(
                                    colors: [
                                      Color.fromARGB(213, 26, 89, 105),
                                      Color.fromARGB(255, 114, 23, 16),
                                    ],
                                    begin: Alignment.topLeft,
                                    end: Alignment.bottomRight,
                                  ),
                                  borderRadius: BorderRadius.vertical(
                                      top: Radius.circular(16.0)),
                                ),
                                child: Text(
                                  '${korisnik.ime ?? ""} ${korisnik.prezime ?? ""}'
                                      .trim(),
                                  style: const TextStyle(
                                    color: Colors.white,
                                    fontSize: 16.0,
                                  ),
                                  textAlign: TextAlign.center,
                                  overflow: TextOverflow.ellipsis,
                                ),
                              ),
                            ),
                            if (isHovered)
                              Positioned.fill(
                                child: AnimatedOpacity(
                                  opacity: isHovered ? 1.0 : 0.0,
                                  duration: const Duration(milliseconds: 200),
                                  child: Container(
                                    color: Colors.black54,
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
}
