import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/music_shop.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/providers/music_shop_provider.dart';
import 'package:enote_desktop/screens/instrumenti_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class MusicShopListScreen extends StatefulWidget {
  const MusicShopListScreen({super.key});

  @override
  State<MusicShopListScreen> createState() => _MusicShopListScreenState();
}

class _MusicShopListScreenState extends State<MusicShopListScreen> {
  late MusicShopProvider musicShopProvider;

  SearchResult<MusicShop>? musicShopResult;

  final TextEditingController _nazivSearch = TextEditingController();
  final TextEditingController _gradSearch = TextEditingController();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    musicShopProvider = context.read<MusicShopProvider>();

    _loadShops();
  }

  Future<void> _loadShops({Map<String, String>? filter}) async {
    musicShopResult = await musicShopProvider.get(filter: filter);

    setState(() {});
  }

  void _applyFilters() async {
    var filter = {
      'naziv': _nazivSearch.text,
      'adresa.grad': _gradSearch.text,
    };

    filter.removeWhere((key, value) {
      return value.isEmpty;
    });

    var validFilter = filter.cast<String, String>();
    await _loadShops(filter: validFilter);
  }

  void _resetFilters() {
    _nazivSearch.clear();
    _gradSearch.clear();
    _loadShops();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Music Shops",
        Column(
          children: [
            _buildSearch(),
            const SizedBox(
              height: 50,
            ),
            _buildResult()
          ],
        ));
  }

  Widget _buildSearch() {
    const double padding = 10.0;
    const double space = 25.0;

    return Padding(
      padding: const EdgeInsets.all(padding),
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: Row(
          children: [
            SizedBox(
              width: 200,
              child: buildStyledTextField(
                controller: _nazivSearch,
                labelText: "Naziv",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: buildStyledTextField(
                controller: _gradSearch,
                labelText: "Grad",
              ),
            ),
            const SizedBox(width: 40.0),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.transparent,
                side: const BorderSide(color: Colors.white, width: 2),
                padding:
                    const EdgeInsets.symmetric(horizontal: 50, vertical: 12),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 4,
              ),
              onPressed: _applyFilters,
              child: const Text('Pretraga'),
            ),
            const SizedBox(width: space),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.transparent,
                side: const BorderSide(color: Colors.white, width: 2),
                padding:
                    const EdgeInsets.symmetric(horizontal: 50, vertical: 12),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 4,
              ),
              onPressed: _resetFilters,
              child: const Text('Reset filtera'),
            ),
            const SizedBox(width: space),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                foregroundColor: Colors.white,
                backgroundColor: Colors.transparent,
                side: const BorderSide(color: Colors.white, width: 2),
                padding:
                    const EdgeInsets.symmetric(horizontal: 50, vertical: 12),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
                elevation: 4,
              ),
              onPressed: () async {},
              child: const Text('Novi shop'),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildResult() {
    return Expanded(
      child: LayoutBuilder(
        builder: (context, constraints) {
          double cardWidth = (constraints.maxWidth / 6) - 8.0;
          double cardHeight = cardWidth * 1.5;

          return SingleChildScrollView(
            child: GridView.builder(
              shrinkWrap: true,
              physics: const NeverScrollableScrollPhysics(),
              gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 7,
                childAspectRatio: 1.5,
                mainAxisSpacing: 24.0,
                crossAxisSpacing: 24.0,
              ),
              itemCount: musicShopResult?.result.length ?? 0,
              itemBuilder: (context, index) {
                final shop = musicShopResult!.result[index];
                bool isHovered = false;

                return StatefulBuilder(
                  builder: (context, setState) {
                    return GestureDetector(
                      child: MouseRegion(
                        onEnter: (_) => setState(() => isHovered = true),
                        onExit: (_) => setState(() => isHovered = false),
                        child: Card(
                          margin: EdgeInsets.zero,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(16.0),
                          ),
                          clipBehavior: Clip.antiAlias,
                          child: Stack(
                            children: [
                              Image.asset(
                                'assets/images/user.png',
                                width: cardWidth,
                                height: cardHeight,
                                fit: BoxFit.cover,
                              ),
                              Positioned.fill(
                                child: AnimatedOpacity(
                                  opacity: isHovered ? 1.0 : 0.0,
                                  duration: const Duration(milliseconds: 200),
                                  child: Container(
                                    decoration: const BoxDecoration(
                                      color: Colors.black54,
                                    ),
                                    child: Center(
                                      child: Column(
                                        mainAxisAlignment:
                                            MainAxisAlignment.center,
                                        crossAxisAlignment:
                                            CrossAxisAlignment.center,
                                        children: [
                                          Text(
                                            shop.naziv ?? "",
                                            style: const TextStyle(
                                              color: Colors.white,
                                              fontSize: 16.0,
                                            ),
                                            textAlign: TextAlign.center,
                                          ),
                                        ],
                                      ),
                                    ),
                                  ),
                                ),
                              ),
                              Positioned(
                                bottom: 10,
                                left: 0,
                                right: 0,
                                child: AnimatedOpacity(
                                  opacity: isHovered ? 1.0 : 0.0,
                                  duration: const Duration(milliseconds: 200),
                                  child: Center(
                                    child: Row(
                                      mainAxisSize: MainAxisSize.min,
                                      mainAxisAlignment:
                                          MainAxisAlignment.center,
                                      children: [
                                        Flexible(
                                          child: ElevatedButton(
                                            style: buildButtonStyleForCard(),
                                            onPressed: () {
                                              // Handle details button press
                                            },
                                            child: const Text('Detalji'),
                                          ),
                                        ),
                                        const SizedBox(width: 8.0),
                                        Flexible(
                                          child: ElevatedButton(
                                            style: buildButtonStyleForCard(),
                                            onPressed: () {
                                              Navigator.of(context).push(
                                                MaterialPageRoute(
                                                  builder: (context) =>
                                                      InstrumentiListScreen(
                                                          shopId: shop.id),
                                                ),
                                              );
                                            },
                                            child: const Text('Instrumenti'),
                                          ),
                                        ),
                                      ],
                                    ),
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                    );
                  },
                );
              },
            ),
          );
        },
      ),
    );
  }

  ButtonStyle buildButtonStyleForCard() {
    return ElevatedButton.styleFrom(
      foregroundColor: Colors.white,
      backgroundColor: Colors.transparent,
      side: const BorderSide(color: Colors.white, width: 2),
      padding: const EdgeInsets.symmetric(
          horizontal: 20, vertical: 8), // Adjusted padding
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(8.0),
      ),
      elevation: 4,
    );
  }

  Widget buildStyledTextField({
    required TextEditingController controller,
    required String labelText,
  }) {
    return TextField(
      controller: controller,
      style: const TextStyle(color: Colors.white),
      cursorColor: Colors.white,
      decoration: InputDecoration(
        border: OutlineInputBorder(
          borderSide: const BorderSide(width: 2.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        enabledBorder: OutlineInputBorder(
          borderSide: const BorderSide(width: 1.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        focusedBorder: OutlineInputBorder(
          borderSide: const BorderSide(width: 2.0, color: Colors.white),
          borderRadius: BorderRadius.circular(12.0),
        ),
        floatingLabelBehavior: FloatingLabelBehavior.auto,
        labelText: labelText,
        labelStyle: const TextStyle(color: Colors.white),
      ),
    );
  }

  ButtonStyle buildButtonStyle() {
    return ElevatedButton.styleFrom(
      foregroundColor: Colors.white,
      backgroundColor: Colors.transparent,
      side: const BorderSide(color: Colors.white, width: 2),
      padding: const EdgeInsets.symmetric(
          horizontal: 20, vertical: 8), // Adjusted padding
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(8.0),
      ),
      elevation: 4,
    );
  }
}
