// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vrsta_instrumenta.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

VrstaInstrumenta _$VrstaInstrumentaFromJson(Map<String, dynamic> json) =>
    VrstaInstrumenta()
      ..id = (json['id'] as num?)?.toInt()
      ..naziv = json['naziv'] as String?;

Map<String, dynamic> _$VrstaInstrumentaToJson(VrstaInstrumenta instance) =>
    <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
    };
