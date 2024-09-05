import 'package:enote_desktop/models/vrsta_instrumenta.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class VrstaInstrumentaProvider extends BaseProvider<VrstaInstrumenta> {
  VrstaInstrumentaProvider() : super("VrstaInstrumenta");

  @override
  VrstaInstrumenta fromJson(data) {
    return VrstaInstrumenta.fromJson(data);
  }
}
