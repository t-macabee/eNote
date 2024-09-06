import 'package:enote_desktop/models/uloge.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class UlogeProvider extends BaseProvider<Uloge> {
  UlogeProvider() : super("Uloge");

  @override
  Uloge fromJson(data) {
    return Uloge.fromJson(data);
  }
}
