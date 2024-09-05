import 'package:json_annotation/json_annotation.dart';

part 'tip_predavanja.g.dart';

@JsonSerializable()
class TipPredavanja {
  int? id;
  String? naziv;

  TipPredavanja();

  factory TipPredavanja.fromJson(Map<String, dynamic> json) =>
      _$TipPredavanjaFromJson(json);

  Map<String, dynamic> toJson() => _$TipPredavanjaToJson(this);
}
