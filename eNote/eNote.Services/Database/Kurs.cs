using eNote.Model.Enums;

namespace eNote.Services.Database
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public NivoTezine NivoTezine { get; set; } 

        public DateTime DatumPocetka { get; set; }  
        public DateTime DatumZavrsetka { get; set; } 
        public int? BrojPolaznika { get; set; }

        public decimal Cijena { get; set; } 
        public decimal CijenaPretplata { get; set; } 
        public bool DostupanNaPretplati { get; set; } 

        public int InstruktorId { get; set; }
        public Korisnik Instruktor { get; set; }

        public ICollection<Predavanje> Predavanje { get; set; } = [];
        public ICollection<Upis> Upis { get; set; } = [];
    }
}