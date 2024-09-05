// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'tip_predavanja.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TipPredavanja _$TipPredavanjaFromJson(Map<String, dynamic> json) =>
    TipPredavanja()
      ..id = (json['id'] as num?)?.toInt()
      ..naziv = json['naziv'] as String?;

Map<String, dynamic> _$TipPredavanjaToJson(TipPredavanja instance) =>
    <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
    };
