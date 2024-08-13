using eNote.Model.Enums;

namespace eNote.Model.DTOs
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public NivoTezine NivoTezine { get; set; }

        public string DatumPocetka { get; set; } = string.Empty;
        public string DatumZavrsetka { get; set; } = string.Empty;
        public int BrojPolaznika { get; set; }

        public decimal Cijena { get; set; }
        public decimal CijenaPretplata { get; set; }
        public bool DostupanNaPretplati { get; set; }

        public string InstruktorIme { get; set; } = string.Empty;
    }
}
