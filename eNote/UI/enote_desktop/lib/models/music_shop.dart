import 'package:enote_desktop/models/adresa.dart';
import 'package:enote_desktop/models/uloge.dart';
import 'package:json_annotation/json_annotation.dart';

part 'music_shop.g.dart';

@JsonSerializable()
class MusicShop {
  int? id;
  String? korisnickoIme;
  String? naziv;
  String? status;
  String? email;
  String? telefon;
  Adresa? adresa;
  Uloge? uloga;

  MusicShop();

  factory MusicShop.fromJson(Map<String, dynamic> json) =>
      _$MusicShopFromJson(json);

  Map<String, dynamic> toJson() => _$MusicShopToJson(this);
}
