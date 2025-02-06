using eNote.Model.Enums;
using System;

namespace eNote.Model.Requests.Predavanje
{
    public class PredavanjeUpdateRequest
    {
        public string? Naziv { get; set; } 
        public string? Lokacija { get; set; }
        public int TrajanjeMinute { get; set; }
        public DateTime? DatumVrijemePredavanja { get; set; }
        public PredavanjeTip? PredavanjeTip { get; set; }
        public PredavanjeStatus? PredavanjeStatus { get; set; }
    }
}
