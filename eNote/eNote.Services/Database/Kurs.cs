namespace eNote.Services.Database
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; } 

        public int InstruktorId { get; set; }
        public Korisnik Instruktor { get; set; }

        public ICollection<Predavanje> Predavanje { get; set; } = [];
        public ICollection<Upis> Upis { get; set; } = [];
    }
}