import 'package:enote_desktop/models/instrumenti.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class InstrumentiProvider extends BaseProvider<Instrumenti> {
  InstrumentiProvider() : super("Instrumenti");

  @override
  Instrumenti fromJson(data) {
    return Instrumenti.fromJson(data);
  }
}
