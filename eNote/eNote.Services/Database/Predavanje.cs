namespace eNote.Services.Database
{
    public class Predavanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Lokacija { get; set; } = string.Empty;
        public DateOnly DatumVrijemePredavanja { get; set; }         

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }

        public ICollection<Obavijest>? Obavijesti { get; set; }
        public ICollection<Zadatak>? Zadaci { get; set; }
        public ICollection<Prisustvo>? Prisustvo { get; set; }
    }
}