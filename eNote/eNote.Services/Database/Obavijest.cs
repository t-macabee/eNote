namespace eNote.Services.Database
{
    public class Obavijest
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Sadrzaj { get; set; } = string.Empty;
        public DateTime DatumPostavljanja { get; set; }

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; }
    }
}