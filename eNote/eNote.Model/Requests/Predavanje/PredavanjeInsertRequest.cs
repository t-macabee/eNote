using eNote.Model.Enums;
using System;

namespace eNote.Model.Requests.Predavanje
{
    public class PredavanjeInsertRequest
    {
        public int KursId { get; set; }        
        public string Naziv { get; set; } = null!;
        public string Lokacija { get; set; } = null!;
        public int TrajanjeMinute { get; set; }       
        public DateTime DatumVrijemePredavanja { get; set; }
        public PredavanjeTip PredavanjeTip { get; set; }
        public PredavanjeStatus PredavanjeStatus { get; set; }
    }
}
