import 'package:json_annotation/json_annotation.dart';

part 'adresa.g.dart';

@JsonSerializable()
class Adresa {
  int? id;
  String? grad;
  String? ulica;
  String? broj;

  Adresa();

  factory Adresa.fromJson(Map<String, dynamic> json) => _$AdresaFromJson(json);

  Map<String, dynamic> toJson() => _$AdresaToJson(this);
}
