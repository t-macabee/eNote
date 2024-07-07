namespace eNote.Services.Database
{
    public class Zadatak
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public DateTime RokPredaje { get; set; }

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; } 

        public ICollection<PredajaZadatka>? PredajaZadatka { get; set; }
    }
}