namespace eNote.Services.Database.Entities
{
    public class Napomena
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Sadrzaj { get; set; } = null!;
        public DateTime DatumVrijemePostavljanja { get; set; }

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; } = null!;
    }
}