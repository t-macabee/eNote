import 'package:json_annotation/json_annotation.dart';

part 'vrsta_instrumenta.g.dart';

@JsonSerializable()
class VrstaInstrumenta {
  int? id;
  String? naziv;

  VrstaInstrumenta();

  factory VrstaInstrumenta.fromJson(Map<String, dynamic> json) =>
      _$VrstaInstrumentaFromJson(json);

  Map<String, dynamic> toJson() => _$VrstaInstrumentaToJson(this);
}
