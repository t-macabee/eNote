namespace eNote.Services.Database.Entities
{
    public class PredajaZadatka
    {
        public int Id { get; set; }
        public int? Ocjena { get; set; }
        public DateTime RokPredaje { get; set; }
        //public string FilePath { get; set; } 

        public  int ZadatakId { get; set; }
        public Zadatak Zadatak { get; set; } = null!;
        public  int PolaznikId { get; set; }
        public Polaznik Polaznik { get; set; } = null!;
    }
}