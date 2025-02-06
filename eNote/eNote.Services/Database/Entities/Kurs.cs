namespace eNote.Services.Database.Entities
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; }
        public decimal Cijena { get; set; }
        public int? BrojUpisanih => Upis.Count;
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }

        public int InstruktorId { get; set; }
        public Instruktor Instruktor { get; set; } = null!;

        public ICollection<Upis> Upis { get; set; } = new List<Upis>();
        public ICollection<Predavanje> Predavanje { get; set; } = new List<Predavanje>();
    }
}