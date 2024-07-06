namespace eNote.Services.Database
{
    public class OglasnaTabla
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; } 
        public DateTime DatumPostavljanja { get; set; }

        public int AutorId { get; set; }
        public Korisnik Autor { get; set; } 
    }
}