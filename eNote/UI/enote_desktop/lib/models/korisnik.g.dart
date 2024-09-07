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
  ..slika = json['slika'] as String?
  ..adresaId = (json['adresaId'] as num?)?.toInt()
  ..adresa = json['adresa'] as String?
  ..ulogaId = (json['ulogaId'] as num?)?.toInt()
  ..uloga = json['uloga'] as String?;

Map<String, dynamic> _$KorisnikToJson(Korisnik instance) => <String, dynamic>{
      'id': instance.id,
      'korisnickoIme': instance.korisnickoIme,
      'status': instance.status,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'datumRodjenja': instance.datumRodjenja,
      'email': instance.email,
      'telefon': instance.telefon,
      'slika': instance.slika,
      'adresaId': instance.adresaId,
      'adresa': instance.adresa,
      'ulogaId': instance.ulogaId,
      'uloga': instance.uloga,
    };
