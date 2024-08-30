import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/enums/vrsta_instrumenta.dart';
import 'package:enote_desktop/models/instrumenti.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/providers/enum_provider.dart';
import 'package:enote_desktop/providers/instrumenti_provider.dart';
import 'package:enote_desktop/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class InstrumentiListScreen extends StatefulWidget {
  const InstrumentiListScreen({super.key});

  @override
  State<InstrumentiListScreen> createState() => _InstrumentiListScreenState();
}

class _InstrumentiListScreenState extends State<InstrumentiListScreen> {
  late InstrumentiProvider provider;
  late SearchResult<Instrumenti> result = SearchResult<Instrumenti>();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    provider = context.read<InstrumentiProvider>();
  }

  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    final screenHeight = MediaQuery.of(context).size.height;
    final horizontalPadding = screenWidth * 0.03;
    final verticalPadding = screenHeight * 0.03;

    return MasterScreen(
      "Instrumenti",
      Padding(
        padding: EdgeInsets.symmetric(horizontal: horizontalPadding)
            .copyWith(top: verticalPadding),
        child: Row(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Expanded(
              flex: 3,
              child: _buildResult(),
            ),
            const SizedBox(width: 32),
            Expanded(
              flex: 1,
              child: Padding(
                padding: const EdgeInsets.only(right: 8.0),
                child: _buildSearch(),
              ),
            ),
          ],
        ),
      ),
    );
  }

  final TextEditingController _modelSearch = TextEditingController();
  final TextEditingController _proizvodjacSearch = TextEditingController();
  VrstaInstrumenta? _vrstaInstrumenta;
  bool? _dostupan;

  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          SizedBox(
            width: MediaQuery.of(context).size.width / 3,
            child: TextField(
              controller: _modelSearch,
              decoration: const InputDecoration(labelText: "Model"),
            ),
          ),
          const SizedBox(height: 16),
          SizedBox(
            width: MediaQuery.of(context).size.width / 3,
            child: TextField(
              controller: _proizvodjacSearch,
              decoration: const InputDecoration(labelText: "Proizvođač"),
            ),
          ),
          const SizedBox(height: 16),
          SizedBox(
            width: MediaQuery.of(context).size.width / 3,
            child: DropdownButton<VrstaInstrumenta?>(
              value: _vrstaInstrumenta,
              hint: const Text("Vrsta Instrumenta"),
              onChanged: (VrstaInstrumenta? newValue) {
                setState(() {
                  _vrstaInstrumenta = newValue;
                });
              },
              isExpanded: true,
              items: [
                const DropdownMenuItem<VrstaInstrumenta?>(
                  value: null,
                  child: Text("Svi instrumenti"),
                ),
                ...VrstaInstrumenta.values.map((VrstaInstrumenta value) {
                  return DropdownMenuItem<VrstaInstrumenta>(
                    value: value,
                    child: Text(vrstaInstrumenta(value)),
                  );
                }),
              ],
            ),
          ),
          const SizedBox(height: 16),
          Row(
            children: [
              Checkbox(
                value: _dostupan ?? false,
                onChanged: (bool? value) {
                  setState(() {
                    _dostupan = value;
                  });
                },
              ),
              const Text("Dostupan"),
            ],
          ),
          const SizedBox(height: 16),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              ElevatedButton(
                onPressed: () async {
                  var filter = {
                    "model": _modelSearch.text,
                    "proizvodjac": _proizvodjacSearch.text,
                    "vrstaInstrumenta":
                        _vrstaInstrumenta?.toString().split('.').last,
                    "dostupan": _dostupan
                  };

                  if (_vrstaInstrumenta == null) {
                    filter.remove("vrstaInstrumenta");
                  }

                  result = await provider.get(filter: filter);

                  setState(() {});
                },
                child: const Text("Pretraga"),
              ),
              ElevatedButton(
                onPressed: () async {
                  setState(() {});
                },
                child: const Text("Reset filtera"),
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _buildResult() {
    return Padding(
      padding: const EdgeInsets.only(top: 10.0),
      child: GridView.builder(
        padding: const EdgeInsets.only(right: 20.0),
        gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
          crossAxisCount: 4,
          crossAxisSpacing: 12.0,
          mainAxisSpacing: 12.0,
          childAspectRatio: 1.5,
        ),
        itemCount: result.result.length,
        itemBuilder: (context, index) {
          final e = result.result[index];
          return SizedBox(
            child: Card(
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: <Widget>[
                  ListTile(
                    leading: e.slika != null
                        ? SizedBox(
                            width: 30,
                            height: 30,
                            child: imageFromString(e.slika!),
                          )
                        : const Icon(Icons.forest),
                    title: Text(
                      e.model ?? "",
                      style: const TextStyle(fontSize: 12),
                    ),
                    subtitle: Text(
                      e.proizvodjac ?? "",
                      style: const TextStyle(fontSize: 10),
                    ),
                  ),
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}
