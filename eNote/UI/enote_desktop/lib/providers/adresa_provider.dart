import 'package:enote_desktop/models/adresa.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class AdresaProvider extends BaseProvider<Adresa> {
  AdresaProvider() : super("Adresa");

  @override
  Adresa fromJson(data) {
    return Adresa.fromJson(data);
  }
}
