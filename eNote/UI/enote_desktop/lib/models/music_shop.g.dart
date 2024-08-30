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
  ..adresa = json['adresa'] == null
      ? null
      : Adresa.fromJson(json['adresa'] as Map<String, dynamic>)
  ..uloga = json['uloga'] == null
      ? null
      : Uloge.fromJson(json['uloga'] as Map<String, dynamic>);

Map<String, dynamic> _$MusicShopToJson(MusicShop instance) => <String, dynamic>{
      'id': instance.id,
      'korisnickoIme': instance.korisnickoIme,
      'naziv': instance.naziv,
      'status': instance.status,
      'email': instance.email,
      'telefon': instance.telefon,
      'adresa': instance.adresa,
      'uloga': instance.uloga,
    };
