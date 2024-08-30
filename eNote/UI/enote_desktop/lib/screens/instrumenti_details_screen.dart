import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/enums/vrsta_instrumenta.dart';
import 'package:enote_desktop/models/instrumenti.dart';
import 'package:enote_desktop/providers/enum_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';

class InstrumentiDetailsScreen extends StatefulWidget {
  final Instrumenti? instrument;

  const InstrumentiDetailsScreen({super.key, this.instrument});

  @override
  State<InstrumentiDetailsScreen> createState() =>
      _InstrumentiDetailsScreenState();
}

class _InstrumentiDetailsScreenState extends State<InstrumentiDetailsScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  final Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen("Detalji", Column(children: [_buildForm(), _save()]));
  }

  Widget _buildForm() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(
            children: [
              Row(
                children: [
                  Expanded(
                      child: FormBuilderTextField(
                          decoration: const InputDecoration(labelText: "Model"),
                          name: 'model')),
                  const SizedBox(width: 10),
                  Expanded(
                      child: FormBuilderTextField(
                    decoration: const InputDecoration(labelText: "Proizvođač"),
                    name: 'proizvodjac',
                  )),
                  const SizedBox(width: 10),
                  Expanded(
                      child: FormBuilderTextField(
                    decoration: const InputDecoration(labelText: "Opis"),
                    name: 'opis',
                  )),
                  const SizedBox(width: 10),
                  Expanded(
                      child: FormBuilderDropdown<VrstaInstrumenta>(
                    decoration:
                        const InputDecoration(labelText: "Vrsta Instrumenta"),
                    name: 'vrstaInstrumenta',
                    items: VrstaInstrumenta.values
                        .map((vrsta) => DropdownMenuItem(
                              value: vrsta,
                              child: Text(vrstaInstrumenta(vrsta)),
                            ))
                        .toList(),
                  ))
                ],
              )
            ],
          )),
    );
  }

  Widget _save() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          ElevatedButton(
              onPressed: () {
                _formKey.currentState?.saveAndValidate();
                debugPrint(_formKey.currentState?.value.toString());
              },
              child: const Text("Sačuvaj"))
        ],
      ),
    );
  }
}
