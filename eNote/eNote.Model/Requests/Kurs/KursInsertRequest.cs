using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Kurs
{
    public class KursInsertRequest
    {
        public int InstruktorId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public NivoTezine NivoTezine { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public int? BrojPolaznika { get; set; }
        public decimal Cijena { get; set; }
        public decimal CijenaPretplata { get; set; }
        public bool DostupanNaPretplati { get; set; }
    }
}
