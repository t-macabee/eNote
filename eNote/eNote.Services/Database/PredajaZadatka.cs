namespace eNote.Services.Database
{
    public class PredajaZadatka
    {
        public int Id { get; set; }
        public DateTime DatumVrijemePredaje { get; set; }        
        public int? Ocjena { get; set; }
        //public string FilePath { get; set; } 

        public int ZadatakId { get; set; }
        public Zadatak Zadatak { get; set; }

        public int StudentId { get; set; }
        public Korisnik Student { get; set; }
    }
}