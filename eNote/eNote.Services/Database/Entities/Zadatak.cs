namespace eNote.Services.Database.Entities
{
    public class Zadatak
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public DateTime DatumVrijemePredaje { get; set; }

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; } = null!;

        public ICollection<PredajaZadatka> PredajaZadatka { get; set; } = new List<PredajaZadatka>();
    }
}