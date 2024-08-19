using eNote.Model.Enums;

namespace eNote.Services.Database
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public int BrojUpisanih { get; set; }

        public DateTime DatumPocetka { get; set; }  
        public DateTime DatumZavrsetka { get; set; } 

        public int InstruktorId { get; set; }
        public Korisnik Instruktor { get; set; }

        public ICollection<Upis> Upis { get; set; } = new List<Upis>();
        public ICollection<Predavanje> Predavanje { get; set; } = new List<Predavanje>();
    }
}