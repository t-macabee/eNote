import 'package:enote_desktop/models/enums/vrsta_instrumenta.dart';
import 'package:json_annotation/json_annotation.dart';

part 'instrumenti.g.dart';

@JsonSerializable()
class Instrumenti {
  int? id;
  String? model;
  String? proizvodjac;
  String? opis;
  String? musicShop;
  VrstaInstrumenta? vrstaInstrumenta; // Enum type
  String? slika;
  bool? dostupan;

  Instrumenti();

  factory Instrumenti.fromJson(Map<String, dynamic> json) =>
      _$InstrumentiFromJson(json);

  Map<String, dynamic> toJson() => _$InstrumentiToJson(this);
}
