import 'dart:convert';

import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/instrumenti.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/models/vrsta_instrumenta.dart';
import 'package:enote_desktop/providers/instrumenti_provider.dart';
import 'package:enote_desktop/providers/music_shop_provider.dart';
import 'package:enote_desktop/providers/vrsta_instrumenta_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ShopInstrumentiListScreen extends StatefulWidget {
  final int? shopId;
  final String? shopName;

  const ShopInstrumentiListScreen({super.key, this.shopId, this.shopName});

  @override
  State<ShopInstrumentiListScreen> createState() =>
      _InstrumentiListScreenState();
}

class _InstrumentiListScreenState extends State<ShopInstrumentiListScreen> {
  late InstrumentiProvider instrumentiProvider;
  late VrstaInstrumentaProvider vrstaInstrumentaProvider;
  late MusicShopProvider musicShopProvider;

  SearchResult<Instrumenti>? instrumentiResult;
  SearchResult<VrstaInstrumenta>? vrstaInstrumentaResult;

  final TextEditingController _modelSearch = TextEditingController();
  final TextEditingController _proizvodjacSearch = TextEditingController();
  VrstaInstrumenta? _selectedVrstaInstrumenta;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    instrumentiProvider = context.read<InstrumentiProvider>();
    vrstaInstrumentaProvider = context.read<VrstaInstrumentaProvider>();
    musicShopProvider = context.read<MusicShopProvider>();

    _loadInstruments();
    _loadInstrumentTypes();
  }

  Future<void> _loadInstruments({Map<String, String>? filter}) async {
    var extendedFilter = {
      'shopId': widget.shopId,
      ...?filter,
    };

    instrumentiResult = await instrumentiProvider.get(filter: extendedFilter);
    setState(() {});
  }

  Future<void> _loadInstrumentTypes() async {
    vrstaInstrumentaResult = await vrstaInstrumentaProvider.get();
    setState(() {});
  }

  void _applyFilters() async {
    var filter = {
      'model': _modelSearch.text,
      'proizvodjac': _proizvodjacSearch.text,
      'vrstaInstrumenta': _selectedVrstaInstrumenta?.id.toString(),
    };

    filter.removeWhere((key, value) {
      if (value == null) return true;
      return value.isEmpty;
    });

    var validFilter = filter.cast<String, String>();
    await _loadInstruments(filter: validFilter);
  }

  void _resetFilters() {
    _modelSearch.clear();
    _proizvodjacSearch.clear();
    _selectedVrstaInstrumenta = null;
    _loadInstruments();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        widget.shopName!,
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
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.transparent,
                side: const BorderSide(color: Colors.white, width: 2),
                padding:
                    const EdgeInsets.symmetric(horizontal: 25, vertical: 12),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 4,
              ),
              onPressed: () {
                Navigator.pop(context);
              },
              child: const Icon(Icons.arrow_back),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: buildStyledTextField(
                controller: _modelSearch,
                labelText: "Model",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: buildStyledTextField(
                controller: _proizvodjacSearch,
                labelText: "Proizvođač",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: DropdownButtonFormField<VrstaInstrumenta>(
                decoration: InputDecoration(
                  labelText: "Vrsta instrumenta",
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
                value: _selectedVrstaInstrumenta,
                items: [
                  const DropdownMenuItem<VrstaInstrumenta>(
                    value: null,
                    child: Text('Svi instrumenti',
                        style: TextStyle(color: Colors.white)),
                  ),
                  ...?vrstaInstrumentaResult?.result
                      .map((VrstaInstrumenta option) {
                    return DropdownMenuItem<VrstaInstrumenta>(
                      value: option,
                      child: Text(option.naziv ?? "",
                          style: const TextStyle(color: Colors.white)),
                    );
                  }),
                ],
                onChanged: (value) {
                  setState(() {
                    _selectedVrstaInstrumenta = value;
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
              child: const Text('Novi instrument'),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildResult() {
    if (instrumentiResult == null) {
      return const Center(
        child: CircularProgressIndicator(),
      );
    } else if (instrumentiResult!.result.isEmpty) {
      return const Padding(
        padding: EdgeInsets.only(top: 40.0),
        child: Center(
          child: Text(
            'Shop trenutno nema instrumente',
            style: TextStyle(
                color: Colors.white, fontSize: 20, fontWeight: FontWeight.bold),
          ),
        ),
      );
    } else {
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
                itemCount: instrumentiResult!.result.length,
                itemBuilder: (context, index) {
                  final instrument = instrumentiResult!.result[index];
                  bool isHovered = false;

                  return StatefulBuilder(
                    builder: (context, setState) {
                      return MouseRegion(
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
                              Image.memory(
                                base64Decode(instrument.slika!),
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
                                            instrument.model ?? "",
                                            style: const TextStyle(
                                              color: Colors.white,
                                              fontSize: 16.0,
                                            ),
                                            textAlign: TextAlign.center,
                                          ),
                                          Text(
                                            instrument.proizvodjac ?? "",
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