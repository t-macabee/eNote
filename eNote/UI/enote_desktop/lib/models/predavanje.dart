import 'package:json_annotation/json_annotation.dart';

part 'predavanje.g.dart';

@JsonSerializable()
class Predavanje {
  int? id;
  String? naziv;
  String? lokacija;
  String? datumVrijemePredavanja;
  int? trajanjeMinute;
  String? stanjePredavanja;
  int? kursId;
  String? kurs;
  String? tipPredavanjaId;
  String? tipPredavanja;

  Predavanje();

  factory Predavanje.fromJson(Map<String, dynamic> json) =>
      _$PredavanjeFromJson(json);

  Map<String, dynamic> toJson() => _$PredavanjeToJson(this);
}
