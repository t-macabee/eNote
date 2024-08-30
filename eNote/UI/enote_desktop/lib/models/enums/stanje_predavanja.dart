// ignore_for_file: constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

part 'stanje_predavanja.g.dart';

@JsonEnum(alwaysCreate: true)
enum StanjePredavanja { NaCekanju, UToku, Zavrseno, Otkazano }
