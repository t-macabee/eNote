namespace eNote.Services.Database
{
    public class Uloge
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Korisnik> Korisnici { get; set; }
    }
}