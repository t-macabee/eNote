using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.DTOs
{
    public class Predavanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public string DatumVrijemePredavanja { get; set; }
        public int TrajanjeMinute { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }

        public TipPredavanja TipPredavanja { get; set; }
        public StanjePredavanja StatusPredavanja { get; set; }
    }
}
