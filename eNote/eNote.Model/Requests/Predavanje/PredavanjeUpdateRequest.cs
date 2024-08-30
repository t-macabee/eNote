using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Predavanje
{
    public class PredavanjeUpdateRequest
    {
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public DateTime DatumVrijemePredavanja { get; set; }
        public StanjePredavanja StatusPredavanja { get; set; }
    }
}
