using eNote.Model.Enums;

namespace eNote.Model.DTOs
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; }
        public decimal Cijena { get; set; }
        public int BrojUpisanih { get; set; }
        public string? DatumPocetka { get; set; }
        public string? DatumZavrsetka { get; set; }
        public string InstruktorIme { get; set; } = null!;
    }
}
