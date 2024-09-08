import 'package:json_annotation/json_annotation.dart';

part 'kurs.g.dart';

@JsonSerializable()
class Kurs {
  int? id;
  String? naziv;
  String? opis;
  double? cijena;
  int? brojUpisanih;
  String? datumPocetka;
  String? datumZavrsetka;
  int? instruktorId;
  String? instruktorIme;

  Kurs();

  factory Kurs.fromJson(Map<String, dynamic> json) => _$KursFromJson(json);

  Map<String, dynamic> toJson() => _$KursToJson(this);
}
