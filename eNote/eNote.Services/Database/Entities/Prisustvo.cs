namespace eNote.Services.Database.Entities
{
    public class Prisustvo
    {
        public int Id { get; set; }
        public bool? PotvrdaPrisustva { get; set; }

        public int PolaznikId { get; set; }
        public Polaznik Polaznik { get; set; } = null!;
        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; } = null!;
    }
}