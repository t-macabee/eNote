namespace eNote.Services.Database
{
    public class OglasnaTabla
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Sadrzaj { get; set; } = string.Empty;
        public DateTime DatumVrijemePostavljanja { get; set; }        

        public int AutorId { get; set; }
        public Korisnik Autor { get; set; }
    }
}