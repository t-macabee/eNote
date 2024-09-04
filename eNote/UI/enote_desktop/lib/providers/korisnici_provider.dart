import 'package:enote_desktop/models/korisnik.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class KorisniciProvider extends BaseProvider<Korisnik> {
  KorisniciProvider() : super("Korisnici");

  @override
  Korisnik fromJson(data) {
    return Korisnik.fromJson(data);
  }
}
