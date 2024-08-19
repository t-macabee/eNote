namespace eNote.Services.Database
{
    public class Zadatak
    {
        public int Id { get; set; }
        public string Naziv { get; set; } 
        public string Opis { get; set; } 
        public DateTime DatumVrijemePredaje { get; set; }        

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; }

        public ICollection<PredajaZadatka> PredajaZadatka { get; set; } = new List<PredajaZadatka>();
    }
}