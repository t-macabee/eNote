namespace eNote.Services.Database.Entities
{
    public class Instruktor : BaseKorisnik
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }

        public ICollection<Kurs> Kurs { get; set; } = new List<Kurs>();
    }
}
