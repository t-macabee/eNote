using eNote.Model.Enums;
using System;

namespace eNote.Model.Requests.Predavanje
{
    public class PredavanjeInsertRequest
    {
        public int KursId { get; set; }        
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public DateTime DatumVrijemePredavanja { get; set; }
        public int TrajanjeMinute { get; set; }
        public Enums.TipPredavanja TipPredavanja { get; set; }         
        public StanjePredavanja StatusPredavanja { get; set; }
    }
}
