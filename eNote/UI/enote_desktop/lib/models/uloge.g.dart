// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'uloge.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Uloge _$UlogeFromJson(Map<String, dynamic> json) => Uloge()
  ..id = (json['id'] as num?)?.toInt()
  ..naziv = json['naziv'] as String?;

Map<String, dynamic> _$UlogeToJson(Uloge instance) => <String, dynamic>{
      'id': instance.id,
      'naziv': instance.naziv,
    };
