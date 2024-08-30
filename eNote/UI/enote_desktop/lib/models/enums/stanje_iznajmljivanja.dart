// ignore_for_file: constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

part 'stanje_iznajmljivanja.g.dart';

@JsonEnum(alwaysCreate: true)
enum StanjeIznajmljivanja { NaCekanju, Potvrdjeno, Zavrseno, Odbijeno }
