// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'adresa.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Adresa _$AdresaFromJson(Map<String, dynamic> json) => Adresa()
  ..id = (json['id'] as num?)?.toInt()
  ..grad = json['grad'] as String?
  ..ulica = json['ulica'] as String?
  ..broj = json['broj'] as String?;

Map<String, dynamic> _$AdresaToJson(Adresa instance) => <String, dynamic>{
      'id': instance.id,
      'grad': instance.grad,
      'ulica': instance.ulica,
      'broj': instance.broj,
    };
