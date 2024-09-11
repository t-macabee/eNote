import 'package:enote_desktop/extensions/elevated_button_extension.dart';
import 'package:enote_desktop/extensions/text_field_extension.dart';
import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/predavanje.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/providers/predavanje_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class PredavanjaListScreen extends StatefulWidget {
  final int? kursId;
  final String? kursNaziv;

  const PredavanjaListScreen({super.key, this.kursId, this.kursNaziv});

  @override
  State<PredavanjaListScreen> createState() => _PredavanjaListScreenState();
}

class _PredavanjaListScreenState extends State<PredavanjaListScreen> {
  late PredavanjeProvider predavanjeProvider;

  SearchResult<Predavanje>? predavanjeResult;

  final TextEditingController _nazivSearch = TextEditingController();

  @override
  void initState() {
    super.initState();
    predavanjeProvider = context.read<PredavanjeProvider>();

    _loadPredavanja();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  Future<void> _loadPredavanja({Map<String, String>? filter}) async {
    var extendedFilter = {
      'kursId': widget.kursId,
      ...?filter,
    };

    predavanjeResult = await predavanjeProvider.get(filter: extendedFilter);
    setState(() {});
  }

  void _applyFilters() async {
    var filter = {'naziv': _nazivSearch.text};

    filter.removeWhere((key, value) {
      return value.isEmpty;
    });

    var validFilter = filter.cast<String, String>();
    await _loadPredavanja(filter: validFilter);
  }

  void _resetFilters() {
    _nazivSearch.clear();
    _loadPredavanja();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        widget.kursNaziv!,
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
              child: _nazivSearch.buildStyledTextField(
                labelText: "Naziv",
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
              child: 'Novo predavanje'.buildStyledButton(
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
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: SingleChildScrollView(
          scrollDirection: Axis.vertical,
          child: Center(
            child: Padding(
                padding: const EdgeInsets.all(24.0),
                child: DataTable(
                  columnSpacing: 64.0,
                  headingRowColor: WidgetStateProperty.resolveWith(
                    (states) => Colors.blueGrey[900] ?? Colors.blueGrey,
                  ),
                  dataRowColor: WidgetStateProperty.resolveWith(
                    (states) => Colors.blueGrey[800] ?? Colors.blueGrey,
                  ),
                  headingTextStyle: const TextStyle(
                    color: Colors.white,
                    fontSize: 16.0,
                    fontWeight: FontWeight.bold,
                  ),
                  dataTextStyle: const TextStyle(
                    color: Colors.white,
                    fontSize: 14.0,
                  ),
                  columns: const [
                    DataColumn(label: Text("Naziv", textAlign: TextAlign.left)),
                    DataColumn(
                        label: Text("Datum i vrijeme",
                            textAlign: TextAlign.center)),
                    DataColumn(
                        label: Text("Lokacija", textAlign: TextAlign.center)),
                    DataColumn(
                        label: Text("Trajanje", textAlign: TextAlign.center)),
                    DataColumn(
                        label: Text("Tip predavanja",
                            textAlign: TextAlign.center)),
                    DataColumn(
                        label: Text(
                      "",
                    )),
                  ],
                  rows: predavanjeResult?.result
                          .map((x) => DataRow(cells: [
                                DataCell(Text(x.naziv ?? "",
                                    textAlign: TextAlign.center)),
                                DataCell(Text(x.datumVrijemePredavanja ?? "",
                                    textAlign: TextAlign.center)),
                                DataCell(Text(x.lokacija ?? "",
                                    textAlign: TextAlign.center)),
                                DataCell(Text(x.trajanjeMinute.toString(),
                                    textAlign: TextAlign.center)),
                                DataCell(Text(x.tipPredavanja ?? "",
                                    textAlign: TextAlign.center)),
                                DataCell(
                                  ElevatedButton(
                                    onPressed: () {},
                                    style: ElevatedButton.styleFrom(
                                      foregroundColor: Colors.white,
                                      backgroundColor: Colors.blueGrey[
                                          600], // Text color of the button
                                    ),
                                    child: const Text(
                                        "Napomena"), // Text on the button
                                  ),
                                ),
                              ]))
                          .toList()
                          .cast<DataRow>() ??
                      [],
                )),
          ),
        ),
      ),
    );
  }
}
