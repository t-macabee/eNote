import 'package:enote_desktop/models/tip_predavanja.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class TipPredavanjaProvider extends BaseProvider<TipPredavanja> {
  TipPredavanjaProvider() : super("TipPredavanja");

  @override
  TipPredavanja fromJson(data) {
    return TipPredavanja.fromJson(data);
  }
}
