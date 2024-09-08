import 'package:enote_desktop/models/kurs.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class KursProvider extends BaseProvider<Kurs> {
  KursProvider() : super("Kurs");

  @override
  Kurs fromJson(data) {
    return Kurs.fromJson(data);
  }
}
