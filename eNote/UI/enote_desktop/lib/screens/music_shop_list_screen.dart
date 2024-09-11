import 'dart:convert';
import 'package:enote_desktop/extensions/elevated_button_extension.dart';
import 'package:enote_desktop/extensions/text_field_extension.dart';
import 'package:enote_desktop/layouts/master_screen.dart';
import 'package:enote_desktop/models/music_shop.dart';
import 'package:enote_desktop/models/search_result.dart';
import 'package:enote_desktop/providers/music_shop_provider.dart';
import 'package:enote_desktop/screens/shop_instrumenti_list_screen.dart';
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
  void initState() {
    super.initState();
    musicShopProvider = context.read<MusicShopProvider>();

    _loadShops();
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  Future<void> _loadShops({Map<String, String>? filter}) async {
    musicShopResult = await musicShopProvider.get(filter: filter);
    setState(() {});
  }

  void _applyFilters() async {
    var filter = {'naziv': _nazivSearch.text, 'adresa': _gradSearch.text};

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
        "Prodavnice muzičke opreme",
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
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: _nazivSearch.buildStyledTextField(
                labelText: "Naziv",
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: _gradSearch.buildStyledTextField(
                labelText: "Grad",
              ),
            ),
            const SizedBox(width: 40.0),
            SizedBox(
              width: 200,
              child: 'Pretraga'.buildStyledButton(
                onPressed: _applyFilters,
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: 'Reset filtera'.buildStyledButton(
                onPressed: _resetFilters,
              ),
            ),
            const SizedBox(width: space),
            SizedBox(
              width: 200,
              child: 'Novi shop'.buildStyledButton(
                onPressed: () async {},
              ),
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
          double cardHeight = cardWidth * 1.0;

          return SingleChildScrollView(
            child: GridView.builder(
              shrinkWrap: true,
              physics: const NeverScrollableScrollPhysics(),
              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 7,
                childAspectRatio: cardWidth / cardHeight,
                mainAxisSpacing: 24.0,
                crossAxisSpacing: 24.0,
              ),
              itemCount: musicShopResult?.result.length ?? 0,
              itemBuilder: (context, index) {
                final shop = musicShopResult!.result[index];
                bool isHovered = false;

                return StatefulBuilder(
                  builder: (context, setState) {
                    return MouseRegion(
                      cursor: SystemMouseCursors.click,
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
                            shop.slika != null && shop.slika!.isNotEmpty
                                ? Image.memory(
                                    base64Decode(shop.slika!),
                                    width: cardWidth,
                                    height: cardHeight,
                                    fit: BoxFit.cover,
                                  )
                                : Image.asset(
                                    'assets/images/stock-user.jpg',
                                    width: cardWidth,
                                    height: cardHeight,
                                    fit: BoxFit.cover,
                                  ),
                            Positioned(
                              top: 0.0,
                              left: 0,
                              right: 0,
                              child: Container(
                                padding: const EdgeInsets.symmetric(
                                    vertical: 6.0, horizontal: 8.0),
                                decoration: const BoxDecoration(
                                  gradient: LinearGradient(
                                    colors: [
                                      Color.fromARGB(255, 114, 23, 16),
                                      Color.fromARGB(213, 26, 89, 105)
                                    ],
                                    begin: Alignment.topLeft,
                                    end: Alignment.bottomRight,
                                  ),
                                  borderRadius: BorderRadius.vertical(
                                      top: Radius.circular(16.0)),
                                ),
                                child: Text(
                                  shop.naziv ?? "",
                                  style: const TextStyle(
                                    color: Colors.white,
                                    fontSize: 16.0,
                                  ),
                                  textAlign: TextAlign.center,
                                  overflow: TextOverflow.ellipsis,
                                ),
                              ),
                            ),
                            if (isHovered)
                              Positioned.fill(
                                child: AnimatedOpacity(
                                  opacity: isHovered ? 1.0 : 0.0,
                                  duration: const Duration(milliseconds: 200),
                                  child: Container(
                                    color: Colors.black54,
                                    child: LayoutBuilder(
                                      builder: (context, constraints) {
                                        return Column(
                                          mainAxisAlignment:
                                              MainAxisAlignment.end,
                                          children: [
                                            Flexible(
                                              child: SingleChildScrollView(
                                                child: Padding(
                                                  padding: EdgeInsets.all(
                                                      constraints.maxHeight *
                                                          0.05),
                                                  child: Wrap(
                                                    spacing: 8.0,
                                                    runSpacing: 8.0,
                                                    alignment:
                                                        WrapAlignment.center,
                                                    children: [
                                                      _buildResponsiveButton(
                                                        'Detalji',
                                                        onPressed: () {},
                                                        constraints:
                                                            constraints,
                                                      ),
                                                      _buildResponsiveButton(
                                                        'Instrumenti',
                                                        onPressed: () {
                                                          Navigator.of(context)
                                                              .push(
                                                            MaterialPageRoute(
                                                              builder: (context) =>
                                                                  ShopInstrumentiListScreen(
                                                                shopId: shop.id,
                                                                shopNaziv:
                                                                    shop.naziv,
                                                              ),
                                                            ),
                                                          );
                                                        },
                                                        constraints:
                                                            constraints,
                                                      ),
                                                    ],
                                                  ),
                                                ),
                                              ),
                                            ),
                                          ],
                                        );
                                      },
                                    ),
                                  ),
                                ),
                              ),
                          ],
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
}

Widget _buildResponsiveButton(String text,
    {required VoidCallback onPressed, required BoxConstraints constraints}) {
  double horizontalPadding = constraints.maxWidth * 0.05;
  double verticalPadding = constraints.maxHeight * 0.02;
  return text.buildStyledButton(
    onPressed: onPressed,
    padding: EdgeInsets.symmetric(
      horizontal: horizontalPadding,
      vertical: verticalPadding,
    ),
  );
}
