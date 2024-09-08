import 'package:enote_desktop/models/predavanje.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class PredavanjeProvider extends BaseProvider<Predavanje> {
  PredavanjeProvider() : super("Predavanje");

  @override
  Predavanje fromJson(data) {
    return Predavanje.fromJson(data);
  }
}
