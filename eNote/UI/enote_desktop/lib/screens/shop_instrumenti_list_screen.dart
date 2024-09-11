import 'dart:convert';
import 'package:enote_desktop/extensions/dropdown_button_extension.dart';
import 'package:enote_desktop/extensions/elevated_button_extension.dart';
import 'package:enote_desktop/extensions/text_field_extension.dart';
import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/instrumenti.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/models/vrsta_instrumenta.dart';
import 'package:enote_desktop/providers/instrumenti_provider.dart';
import 'package:enote_desktop/providers/vrsta_instrumenta_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ShopInstrumentiListScreen extends StatefulWidget {
  final int? shopId;
  final String? shopNaziv;

  const ShopInstrumentiListScreen({super.key, this.shopId, this.shopNaziv});

  @override
  State<ShopInstrumentiListScreen> createState() =>
      _InstrumentiListScreenState();
}

class _InstrumentiListScreenState extends State<ShopInstrumentiListScreen> {
  late InstrumentiProvider instrumentiProvider;
  late VrstaInstrumentaProvider vrstaInstrumentaProvider;

  SearchResult<Instrumenti>? instrumentiResult;
  SearchResult<VrstaInstrumenta>? vrstaInstrumentaResult;

  final TextEditingController _modelSearch = TextEditingController();
  final TextEditingController _proizvodjacSearch = TextEditingController();

  final ValueNotifier<VrstaInstrumenta?> _selectedVrstaInstrumenta =
      ValueNotifier(null);

  @override
  void initState() {
    super.initState();
    instrumentiProvider = context.read<InstrumentiProvider>();
    vrstaInstrumentaProvider = context.read<VrstaInstrumentaProvider>();

    _loadInstruments();
    _loadVrstaInstrumenta();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  Future<void> _loadInstruments({Map<String, String>? filter}) async {
    var extendedFilter = {
      'shopId': widget.shopId,
      ...?filter,
    };

    instrumentiResult = await instrumentiProvider.get(filter: extendedFilter);
    setState(() {});
  }

  Future<void> _loadVrstaInstrumenta() async {
    vrstaInstrumentaResult = await vrstaInstrumentaProvider.get();
    setState(() {});
  }

  void _applyFilters() async {
    var filter = {
      'model': _modelSearch.text,
      'proizvodjac': _proizvodjacSearch.text,
      'vrstaInstrumenta': _selectedVrstaInstrumenta.value?.id.toString(),
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
    _selectedVrstaInstrumenta.value = null;
    _loadInstruments();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        widget.shopNaziv!,
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
              style: 'Back'
                  .buildStyledButton(
                    onPressed: () {
                      Navigator.pop(context);
                    },
                    padding: const EdgeInsets.symmetric(
                        horizontal: 25, vertical: 12),
                    child: const Icon(Icons.arrow_back),
                  )
                  .style,
              onPressed: () {
                Navigator.pop(context);
              },
              child: const Icon(Icons.arrow_back),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: _modelSearch.buildStyledTextField(
                labelText: "Model",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: _proizvodjacSearch.buildStyledTextField(
                labelText: "Proizvođač",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: ValueListenableBuilder<VrstaInstrumenta?>(
                valueListenable: _selectedVrstaInstrumenta,
                builder: (context, selectedValue, child) {
                  return vrstaInstrumentaResult?.result
                          .map((VrstaInstrumenta option) {
                            return DropdownMenuItem<VrstaInstrumenta>(
                              value: option,
                              child: Text(option.naziv ?? "",
                                  style: const TextStyle(color: Colors.white)),
                            );
                          })
                          .toList()
                          .buildStyledDropdown(
                            selectedValue: selectedValue,
                            onChanged: (value) {
                              _selectedVrstaInstrumenta.value = value;
                            },
                            labelText: "Vrsta instrumenta",
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
              width: 210,
              child: 'Novi instrument'.buildStyledButton(
                onPressed: () async {},
              ),
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
                                          Expanded(
                                            child: Center(
                                              child: Text(
                                                instrument.model ?? "",
                                                style: const TextStyle(
                                                  color: Colors.white,
                                                  fontSize: 16.0,
                                                ),
                                                textAlign: TextAlign.center,
                                                overflow: TextOverflow.ellipsis,
                                              ),
                                            ),
                                          ),
                                          Expanded(
                                            child: Center(
                                              child: Text(
                                                instrument.proizvodjac ?? "",
                                                style: const TextStyle(
                                                  color: Colors.white,
                                                  fontSize: 14.0,
                                                ),
                                                textAlign: TextAlign.center,
                                                overflow: TextOverflow
                                                    .ellipsis, // Handle overflow
                                              ),
                                            ),
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
}
