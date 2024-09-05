import 'package:json_annotation/json_annotation.dart';

part 'korisnik.g.dart';

@JsonSerializable()
class Korisnik {
  int? id;
  String? korisnickoIme;
  String? status;
  String? ime;
  String? prezime;
  String? datumRodjenja;
  String? email;
  String? telefon;
  int? adresaId;
  String? adresa;
  int? ulogaId;
  String? uloga;

  Korisnik();

  factory Korisnik.fromJson(Map<String, dynamic> json) =>
      _$KorisnikFromJson(json);

  Map<String, dynamic> toJson() => _$KorisnikToJson(this);
}
