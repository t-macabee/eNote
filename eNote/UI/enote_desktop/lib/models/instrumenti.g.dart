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
  ..musicShop = json['musicShop'] as String?
  ..vrstaInstrumenta =
      $enumDecodeNullable(_$VrstaInstrumentaEnumMap, json['vrstaInstrumenta'])
  ..slika = json['slika'] as String?
  ..dostupan = json['dostupan'] as bool?;

Map<String, dynamic> _$InstrumentiToJson(Instrumenti instance) =>
    <String, dynamic>{
      'id': instance.id,
      'model': instance.model,
      'proizvodjac': instance.proizvodjac,
      'opis': instance.opis,
      'musicShop': instance.musicShop,
      'vrstaInstrumenta': _$VrstaInstrumentaEnumMap[instance.vrstaInstrumenta],
      'slika': instance.slika,
      'dostupan': instance.dostupan,
    };

const _$VrstaInstrumentaEnumMap = {
  VrstaInstrumenta.Zicani: 'Zicani',
  VrstaInstrumenta.Limeni: 'Limeni',
  VrstaInstrumenta.Udaraljke: 'Udaraljke',
  VrstaInstrumenta.Tipke: 'Tipke',
  VrstaInstrumenta.Elektronicki: 'Elektronicki',
};
