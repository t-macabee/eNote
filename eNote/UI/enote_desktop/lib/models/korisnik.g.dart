// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnik.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Korisnik _$KorisnikFromJson(Map<String, dynamic> json) => Korisnik()
  ..id = (json['id'] as num?)?.toInt()
  ..korisnickoIme = json['korisnickoIme'] as String?
  ..status = json['status'] as String?
  ..ime = json['ime'] as String?
  ..prezime = json['prezime'] as String?
  ..datumRodjenja = json['datumRodjenja'] as String?
  ..email = json['email'] as String?
  ..telefon = json['telefon'] as String?
  ..adresa = json['adresa'] == null
      ? null
      : Adresa.fromJson(json['adresa'] as Map<String, dynamic>)
  ..uloga = json['uloga'] == null
      ? null
      : Uloge.fromJson(json['uloga'] as Map<String, dynamic>);

Map<String, dynamic> _$KorisnikToJson(Korisnik instance) => <String, dynamic>{
      'id': instance.id,
      'korisnickoIme': instance.korisnickoIme,
      'status': instance.status,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'datumRodjenja': instance.datumRodjenja,
      'email': instance.email,
      'telefon': instance.telefon,
      'adresa': instance.adresa,
      'uloga': instance.uloga,
    };
