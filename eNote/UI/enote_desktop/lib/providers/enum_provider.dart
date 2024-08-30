import 'package:enote_desktop/models/enums/stanje_iznajmljivanja.dart';
import 'package:enote_desktop/models/enums/stanje_predavanja.dart';
import 'package:enote_desktop/models/enums/stanje_upisa.dart';
import 'package:enote_desktop/models/enums/tip_predavanja.dart';
import 'package:enote_desktop/models/enums/vrsta_instrumenta.dart';

String vrstaInstrumenta(VrstaInstrumenta vrsta) {
  switch (vrsta) {
    case VrstaInstrumenta.Zicani:
      return 'Žičani';
    case VrstaInstrumenta.Limeni:
      return 'Limeni';
    case VrstaInstrumenta.Udaraljke:
      return 'Udaraljke';
    case VrstaInstrumenta.Tipke:
      return 'Tipke';
    case VrstaInstrumenta.Elektronicki:
      return 'Elektronički';
    default:
      return '';
  }
}

String tipPredavanja(TipPredavanja tip) {
  switch (tip) {
    case TipPredavanja.Teorija:
      return 'Teorija';
    case TipPredavanja.Praksa:
      return 'Praksa';
    case TipPredavanja.Kombinovano:
      return 'Kombinovano';
    default:
      return '';
  }
}

String stanjeUpisa(StanjeUpisa stanje) {
  switch (stanje) {
    case StanjeUpisa.NaCekanju:
      return 'Na čekanju';
    case StanjeUpisa.Potvrdjeno:
      return 'Potvrđeno';
    case StanjeUpisa.Aktivno:
      return 'Aktivno';
    case StanjeUpisa.Otkazano:
      return 'Otkazano';
    case StanjeUpisa.Odustao:
      return 'Odustao';
    default:
      return '';
  }
}

String stanjePredavanja(StanjePredavanja stanje) {
  switch (stanje) {
    case StanjePredavanja.NaCekanju:
      return 'Na čekanju';
    case StanjePredavanja.UToku:
      return 'U toku';
    case StanjePredavanja.Zavrseno:
      return 'Završeno';
    case StanjePredavanja.Otkazano:
      return 'Otkazano';
    default:
      return '';
  }
}

String stanjeIznajmljivanja(StanjeIznajmljivanja stanje) {
  switch (stanje) {
    case StanjeIznajmljivanja.NaCekanju:
      return 'Na čekanju';
    case StanjeIznajmljivanja.Potvrdjeno:
      return 'Potvrđeno';
    case StanjeIznajmljivanja.Zavrseno:
      return 'Završeno';
    case StanjeIznajmljivanja.Odbijeno:
      return 'Odbijeno';
    default:
      return '';
  }
}
