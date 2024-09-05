import 'package:json_annotation/json_annotation.dart';

part 'instrumenti.g.dart';

@JsonSerializable()
class Instrumenti {
  int? id;
  String? model;
  String? proizvodjac;
  String? opis;
  String? slika;
  bool? dostupan;
  int? vrstaInstrumentaId;
  String? vrstaInstrumenta;
  int? musicShopId;
  String? musicShop;

  Instrumenti();

  factory Instrumenti.fromJson(Map<String, dynamic> json) =>
      _$InstrumentiFromJson(json);

  Map<String, dynamic> toJson() => _$InstrumentiToJson(this);
}
