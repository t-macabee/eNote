import 'package:enote_desktop/extensions/dropdown_button_extension.dart';
import 'package:enote_desktop/extensions/elevated_button_extension.dart';
import 'package:enote_desktop/extensions/text_field_extension.dart';
import 'package:enote_desktop/models/instrumenti.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';

class InstrumentiDialog extends StatefulWidget {
  final Instrumenti? instrument;
  final bool edit;
  const InstrumentiDialog({super.key, this.instrument, required this.edit});

  @override
  State<InstrumentiDialog> createState() => _InstrumentiDialogState();
}

class _InstrumentiDialogState extends State<InstrumentiDialog> {
  final _formKey = GlobalKey<FormBuilderState>();

  TextEditingController model = TextEditingController();
  TextEditingController proizvodjac = TextEditingController();
  TextEditingController opis = TextEditingController();
  TextEditingController vrstaInstrumenta = TextEditingController();
  TextEditingController musicShop = TextEditingController();

  bool editMode = false;
  String? selectedMusicShop;
  String? selectedInstrumentType;

  @override
  void initState() {
    super.initState();

    if (widget.edit == true && widget.instrument != null) {
      loadCurrent();
      editMode = false;
    } else {
      editMode = true;
    }
  }

  void loadCurrent() {
    model.text = widget.instrument!.model!;
    proizvodjac.text = widget.instrument!.proizvodjac!;
    opis.text = widget.instrument!.opis!;
    vrstaInstrumenta.text = widget.instrument!.vrstaInstrumenta!;
    musicShop.text = widget.instrument!.musicShop!;
  }

  String get dialogTitle {
    if (widget.instrument == null) {
      return "Novi instrument";
    } else if (editMode) {
      return "Ažuriranje";
    } else {
      return "Detalji";
    }
  }

  @override
  Widget build(BuildContext context) {
    const Color borderColor = Colors.white;
    const TextStyle textStyle = TextStyle(color: Colors.white);
    const Color lockedFieldColor = Color.fromARGB(255, 26, 89, 105);
    const Color editableFieldColor = Color.fromARGB(255, 107, 105, 105);

    return AlertDialog(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(16.0),
        side: const BorderSide(color: borderColor, width: 2.0),
      ),
      backgroundColor: const Color.fromARGB(255, 26, 89, 105),
      title: Padding(
        padding: const EdgeInsets.all(12.0),
        child: Text(dialogTitle,
            style: const TextStyle(
                fontSize: 24, fontWeight: FontWeight.bold, color: Colors.white),
            textAlign: TextAlign.center),
      ),
      content: SizedBox(
        height: 500,
        width: 500,
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: SingleChildScrollView(
            child: Form(
              key: _formKey,
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  model.buildStyledTextField(
                    labelText: "Model",
                    textStyle: textStyle,
                    enabled: editMode,
                    fillColor: editMode ? editableFieldColor : lockedFieldColor,
                  ),
                  const SizedBox(height: 32.0),
                  proizvodjac.buildStyledTextField(
                    labelText: "Proizvođač",
                    textStyle: textStyle,
                    enabled: editMode,
                    fillColor: editMode ? editableFieldColor : lockedFieldColor,
                  ),
                  const SizedBox(height: 32.0),
                  opis.buildStyledTextField(
                    labelText: "Opis",
                    textStyle: textStyle,
                    enabled: editMode,
                    fillColor: editMode ? editableFieldColor : lockedFieldColor,
                  ),
                  const SizedBox(height: 32.0),
                  if (widget.edit)
                    vrstaInstrumenta.buildStyledTextField(
                      labelText: "Vrsta instrumenta",
                      textStyle: textStyle,
                      enabled: false,
                    )
                  else
                    _buildInstrumentTypeDropdown(),
                  const SizedBox(height: 32.0),
                  if (widget.edit)
                    musicShop.buildStyledTextField(
                      labelText: "Music Shop",
                      textStyle: textStyle,
                      enabled: false,
                    )
                  else
                    _buildMusicShopDropdown(),
                  const SizedBox(height: 48.0),
                  Wrap(
                    spacing: 16.0,
                    alignment: WrapAlignment.end,
                    children: [
                      if (widget.edit)
                        "Uredi".buildStyledButton(
                          onPressed: () {
                            setState(() {
                              editMode = !editMode;
                            });
                          },
                          child: Text(editMode ? 'Spremi' : 'Uredi'),
                        )
                      else
                        "Spremi".buildStyledButton(
                          onPressed: () {},
                          child: const Text('Spremi'),
                        ),
                      "Otkaži".buildStyledButton(
                        onPressed: () {
                          Navigator.of(context).pop();
                        },
                        child: const Text('Otkaži'),
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildInstrumentTypeDropdown() {
    final instrumentTypes = ['Guitar', 'Piano', 'Drums', 'Violin'];
    return instrumentTypes
        .map((type) => DropdownMenuItem(value: type, child: Text(type)))
        .toList()
        .buildStyledDropdown(
          selectedValue: selectedInstrumentType,
          onChanged: (value) {
            setState(() {
              selectedInstrumentType = value;
            });
          },
          labelText: "Vrsta instrumenta",
          backgroundColor: const Color.fromARGB(255, 107, 105, 105),
        );
  }

  Widget _buildMusicShopDropdown() {
    final musicShops = ['Shop A', 'Shop B', 'Shop C'];
    return musicShops
        .map((shop) => DropdownMenuItem(value: shop, child: Text(shop)))
        .toList()
        .buildStyledDropdown(
          selectedValue: selectedMusicShop,
          onChanged: (value) {
            setState(() {
              selectedMusicShop = value;
            });
          },
          labelText: "Music Shop",
          backgroundColor: const Color.fromARGB(255, 107, 105, 105),
        );
  }
}
