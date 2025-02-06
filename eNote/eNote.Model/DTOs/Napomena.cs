namespace eNote.Model.DTOs
{
    public class Napomena
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = null!;
        public string Sadrzaj { get; set; } = null!;
        public string DatumVrijemePostavljanja { get; set; } = null!;
        public string Predavanje { get; set; } = null!;
    }
}
