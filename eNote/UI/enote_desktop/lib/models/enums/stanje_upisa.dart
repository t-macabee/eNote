// ignore_for_file: constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

part 'stanje_upisa.g.dart';

@JsonEnum(alwaysCreate: true)
enum StanjeUpisa { NaCekanju, Potvrdjeno, Aktivno, Otkazano, Odustao }
