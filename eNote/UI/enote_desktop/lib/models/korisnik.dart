import 'package:enote_desktop/models/adresa.dart';
import 'package:enote_desktop/models/uloge.dart';
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
  Adresa? adresa;
  Uloge? uloga;

  Korisnik();

  factory Korisnik.fromJson(Map<String, dynamic> json) =>
      _$KorisnikFromJson(json);

  Map<String, dynamic> toJson() => _$KorisnikToJson(this);
}
