namespace eNote.Services.Database
{
    public class Obavijest
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; } 
        public DateTime DatumVrijemePostavljanja { get; set; }        

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; }
    }
}