// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'instrumenti.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Instrumenti _$InstrumentiFromJson(Map<String, dynamic> json) => Instrumenti()
  ..id = (json['id'] as num?)?.toInt()
  ..model = json['model'] as String?
  ..proizvodjac = json['proizvodjac'] as String?
  ..opis = json['opis'] as String?
  ..slika = json['slika'] as String?
  ..dostupan = json['dostupan'] as bool?
  ..vrstaInstrumentaId = (json['vrstaInstrumentaId'] as num?)?.toInt()
  ..vrstaInstrumenta = json['vrstaInstrumenta'] as String?
  ..musicShopId = (json['musicShopId'] as num?)?.toInt()
  ..musicShop = json['musicShop'] as String?;

Map<String, dynamic> _$InstrumentiToJson(Instrumenti instance) =>
    <String, dynamic>{
      'id': instance.id,
      'model': instance.model,
      'proizvodjac': instance.proizvodjac,
      'opis': instance.opis,
      'slika': instance.slika,
      'dostupan': instance.dostupan,
      'vrstaInstrumentaId': instance.vrstaInstrumentaId,
      'vrstaInstrumenta': instance.vrstaInstrumenta,
      'musicShopId': instance.musicShopId,
      'musicShop': instance.musicShop,
    };
