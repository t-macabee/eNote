// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'music_shop.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MusicShop _$MusicShopFromJson(Map<String, dynamic> json) => MusicShop()
  ..id = (json['id'] as num?)?.toInt()
  ..korisnickoIme = json['korisnickoIme'] as String?
  ..naziv = json['naziv'] as String?
  ..status = json['status'] as String?
  ..email = json['email'] as String?
  ..telefon = json['telefon'] as String?
  ..slika = json['slika'] as String?
  ..adresaId = (json['adresaId'] as num?)?.toInt()
  ..adresa = json['adresa'] as String?
  ..ulogaId = (json['ulogaId'] as num?)?.toInt()
  ..uloga = json['uloga'] as String?;

Map<String, dynamic> _$MusicShopToJson(MusicShop instance) => <String, dynamic>{
      'id': instance.id,
      'korisnickoIme': instance.korisnickoIme,
      'naziv': instance.naziv,
      'status': instance.status,
      'email': instance.email,
      'telefon': instance.telefon,
      'slika': instance.slika,
      'adresaId': instance.adresaId,
      'adresa': instance.adresa,
      'ulogaId': instance.ulogaId,
      'uloga': instance.uloga,
    };
