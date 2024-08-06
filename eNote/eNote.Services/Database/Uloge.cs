using eNote.Services.Configurations;

namespace eNote.Services.Database
{
    public class Uloge
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string NazivString => Naziv.ToString();

        public ICollection<Korisnik> Korisnici { get; set; } = new List<Korisnik>();
    }
}