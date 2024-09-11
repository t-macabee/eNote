import 'package:enote_desktop/models/instrumenti.dart';
import 'package:enote_desktop/models/music_shop.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/models/vrsta_instrumenta.dart';
import 'package:enote_desktop/providers/instrumenti_provider.dart';
import 'package:enote_desktop/providers/music_shop_provider.dart';
import 'package:enote_desktop/providers/vrsta_instrumenta_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class InstrumentiDialog extends StatefulWidget {
  final Instrumenti? instrument;

  const InstrumentiDialog({super.key, this.instrument});

  @override
  State<InstrumentiDialog> createState() => _InstrumentiDialogState();
}

class _InstrumentiDialogState extends State<InstrumentiDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  final Map<String, dynamic> _initialValue = {};

  SearchResult<VrstaInstrumenta>? vrstaInstrumentaResult;
  SearchResult<MusicShop>? musicShopResult;

  late InstrumentiProvider instrumentiProvider;
  late VrstaInstrumentaProvider vrstaInstrumentaProvider;
  late MusicShopProvider musicShopProvider;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  @override
  void initState() {
    musicShopProvider = context.read<MusicShopProvider>();
    vrstaInstrumentaProvider = context.read<VrstaInstrumentaProvider>();
    instrumentiProvider = context.read<InstrumentiProvider>();

    _loadVrstaInstrumenta();
    _loadMusicShops();

    super.initState();
  }

  Future<void> _loadVrstaInstrumenta() async {
    vrstaInstrumentaResult = await vrstaInstrumentaProvider.get();
    setState(() {});
  }

  Future<void> _loadMusicShops() async {
    musicShopResult = await musicShopProvider.get();
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    const borderColor = Color.fromARGB(255, 0, 150, 135);

    return AlertDialog(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(16.0),
        side: const BorderSide(color: borderColor, width: 2.0),
      ),
      content: SizedBox(
        width: 400,
        child: SingleChildScrollView(
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [_buildForm(), const SizedBox(height: 10.0)],
          ),
        ),
      ),
      backgroundColor: const Color.fromARGB(255, 26, 89, 105),
      actionsPadding:
          const EdgeInsets.symmetric(horizontal: 32.0, vertical: 16.0),
      actions: [
        SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          child: Row(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              SizedBox(
                width: 100,
                child: TextButton(
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                  style: TextButton.styleFrom(
                    foregroundColor: Colors.white,
                  ),
                  child: const Text('Cancel'),
                ),
              ),
              const SizedBox(width: 8.0),
              customElevatedButton(
                text: 'Save',
                onPressed: () async {
                  if (_formKey.currentState?.saveAndValidate() ?? false) {
                    await instrumentiProvider
                        .insert(_formKey.currentState?.value);
                    // ignore: use_build_context_synchronously
                    Navigator.of(context).pop(true);
                  } else {
                    debugPrint('Form validation failed.');
                  }
                },
                borderColor: Colors.white,
              ),
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            customFormBuilderTextField(
              name: 'model',
              labelText: 'Model',
            ),
            const SizedBox(height: 16.0),
            customFormBuilderTextField(
              name: 'proizvodjac',
              labelText: 'Proizvođač',
            ),
            const SizedBox(height: 16.0),
            customFormBuilderTextField(
              name: 'opis',
              labelText: 'Opis',
            ),
            const SizedBox(height: 16.0),
            customFormBuilderDropdown(
              name: "vrstaInstrumentaId",
              labelText: "Vrsta instrumenta",
              items: vrstaInstrumentaResult?.result
                      .map<DropdownMenuItem<String>>(
                          (x) => DropdownMenuItem<String>(
                                value: x.id.toString(),
                                child: Text(x.naziv ?? ""),
                              ))
                      .toList() ??
                  [],
            ),
            const SizedBox(height: 16.0),
            customFormBuilderDropdown(
              name: "musicShopId",
              labelText: "Music shop",
              items: musicShopResult?.result
                      .map<DropdownMenuItem<String>>(
                          (x) => DropdownMenuItem<String>(
                                value: x.id.toString(),
                                child: Text(x.naziv ?? ""),
                              ))
                      .toList() ??
                  [],
            ),
          ],
        ),
      ),
    );
  }

  Widget customFormBuilderTextField({
    required String name,
    required String labelText,
  }) {
    return FormBuilderTextField(
      name: name,
      decoration: InputDecoration(
        labelText: labelText,
        labelStyle: const TextStyle(color: Colors.white),
        hintStyle: const TextStyle(color: Colors.white70),
        enabledBorder: const UnderlineInputBorder(
          borderSide: BorderSide(color: Colors.white),
        ),
        focusedBorder: const UnderlineInputBorder(
          borderSide: BorderSide(color: Colors.white),
        ),
      ),
      style: const TextStyle(color: Colors.white),
    );
  }

  Widget customElevatedButton({
    required String text,
    required VoidCallback onPressed,
    required Color borderColor,
  }) {
    return SizedBox(
      width: 100,
      child: ElevatedButton(
        onPressed: onPressed,
        style: ElevatedButton.styleFrom(
          foregroundColor: Colors.white,
          backgroundColor: Colors.transparent,
          side: BorderSide(color: borderColor, width: 2.0),
          padding: const EdgeInsets.symmetric(horizontal: 24.0, vertical: 12.0),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(8.0),
          ),
          elevation: 4,
        ),
        child: Text(text),
      ),
    );
  }

  Widget customFormBuilderDropdown({
    required String name,
    required String labelText,
    required List<DropdownMenuItem<String>> items,
  }) {
    return FormBuilderDropdown<String>(
      name: name,
      decoration: InputDecoration(
        labelText: labelText,
        labelStyle: const TextStyle(color: Colors.white),
        enabledBorder: const UnderlineInputBorder(
          borderSide: BorderSide(color: Colors.white),
        ),
        focusedBorder: const UnderlineInputBorder(
          borderSide: BorderSide(color: Colors.white),
        ),
      ),
      style: const TextStyle(color: Colors.white),
      items: items,
      dropdownColor: const Color.fromARGB(255, 49, 53, 61),
    );
  }
}
