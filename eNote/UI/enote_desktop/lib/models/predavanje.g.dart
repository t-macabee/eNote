// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'predavanje.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Predavanje _$PredavanjeFromJson(Map<String, dynamic> json) => Predavanje()
  ..id = (json['id'] as num?)?.toInt()
  ..naziv = json['naziv'] as String?
  ..lokacija = json['lokacija'] as String?
  ..datumVrijemePredavanja = json['datumVrijemePredavanja'] as String?
  ..trajanjeMinute = (json['trajanjeMinute'] as num?)?.toInt()
  ..stanjePredavanja = json['stanjePredavanja'] as String?
  ..kursId = (json['kursId'] as num?)?.toInt()
  ..kurs = json['kurs'] as String?
  ..tipPredavanjaId = json['tipPredavanjaId'] as String?
  ..tipPredavanja = json['tipPredavanja'] as String?;

Map<String, dynamic> _$PredavanjeToJson(Predavanje instance) =>
    <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
      'lokacija': instance.lokacija,
      'datumVrijemePredavanja': instance.datumVrijemePredavanja,
      'trajanjeMinute': instance.trajanjeMinute,
      'stanjePredavanja': instance.stanjePredavanja,
      'kursId': instance.kursId,
      'kurs': instance.kurs,
      'tipPredavanjaId': instance.tipPredavanjaId,
      'tipPredavanja': instance.tipPredavanja,
    };
