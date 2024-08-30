// ignore_for_file: constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

part 'vrsta_instrumenta.g.dart';

@JsonEnum(alwaysCreate: true)
enum VrstaInstrumenta { Zicani, Limeni, Udaraljke, Tipke, Elektronicki }
