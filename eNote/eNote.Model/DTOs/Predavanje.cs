namespace eNote.Model.DTOs
{
    public class Predavanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Lokacija { get; set; } = null!;
        public int TrajanjeMinute { get; set; }        
        public string DatumVrijemePredavanja { get; set; } = null!;
        public string Kurs { get; set; } = null!;
        public string PredavanjeTip { get; set; } = null!;
        public string PredavanjeStatus { get; set; } = null!;
    }
}
