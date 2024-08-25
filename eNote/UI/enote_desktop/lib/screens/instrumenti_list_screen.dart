import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/instrumenti.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/providers/instrumenti_provider.dart';
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
    return MasterScreen(
        "Instrumenti",
        Column(
          children: [_buildSearch(), _buildResult()],
        ));
  }

  final TextEditingController _modelSearch = TextEditingController();
  final TextEditingController _proizvodjacSearch = TextEditingController();
  Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          Expanded(
              child: TextField(
                  controller: _modelSearch,
                  decoration: const InputDecoration(labelText: "Model"))),
          const SizedBox(width: 8),
          Expanded(
              child: TextField(
                  controller: _proizvodjacSearch,
                  decoration: const InputDecoration(labelText: "Proizvođač"))),
          const SizedBox(width: 8),
          const Expanded(
              child: TextField(
                  decoration: InputDecoration(labelText: "Na stanju"))),
          ElevatedButton(
              onPressed: () async {
                var filter = {
                  "model": _modelSearch.text,
                  "proizvodjac": _proizvodjacSearch.text,
                };
                result = await provider.get(filter: filter);

                setState(() {});
              },
              child: const Text("Pretraga")),
          const SizedBox(width: 8),
          ElevatedButton(
              onPressed: () async {}, child: const Text("Novi instrument")),
        ],
      ),
    );
  }

  Widget _buildResult() {
    if (result.result.isEmpty) {
      return const Text("No data found");
    } else {
      return Expanded(
        child: SingleChildScrollView(
          child: DataTable(
            columns: const [DataColumn(label: Text("Model"))],
            rows: result.result
                .map((e) => DataRow(cells: [DataCell(Text(e.model ?? ""))]))
                .toList(),
          ),
        ),
      );
    }
  }
}
