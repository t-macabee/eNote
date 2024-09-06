import 'package:enote_desktop/models/music_shop.dart';
import 'package:enote_desktop/providers/base_provider.dart';

class MusicShopProvider extends BaseProvider<MusicShop> {
  MusicShopProvider() : super("MusicShop");

  @override
  MusicShop fromJson(data) {
    return MusicShop.fromJson(data);
  }
}
