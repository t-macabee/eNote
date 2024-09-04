// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'kurs.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Kurs _$KursFromJson(Map<String, dynamic> json) => Kurs()
  ..id = (json['id'] as num?)?.toInt()
  ..naziv = json['naziv'] as String?
  ..opis = json['opis'] as String?
  ..cijena = (json['cijena'] as num?)?.toDouble()
  ..brojUpisanih = (json['brojUpisanih'] as num?)?.toInt()
  ..datumPocetka = json['datumPocetka'] as String?
  ..datumZavrsetka = json['datumZavrsetka'] as String?
  ..instruktorIme = json['instruktorIme'] as String?;

Map<String, dynamic> _$KursToJson(Kurs instance) => <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
      'opis': instance.opis,
      'cijena': instance.cijena,
      'brojUpisanih': instance.brojUpisanih,
      'datumPocetka': instance.datumPocetka,
      'datumZavrsetka': instance.datumZavrsetka,
      'instruktorIme': instance.instruktorIme,
    };
