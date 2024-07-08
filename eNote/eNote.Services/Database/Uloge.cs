using eNote.Services.Configurations;

namespace eNote.Services.Database
{
    public class Uloge
    {
        public int Id { get; set; }
        public UserRoles Naziv { get; set; } 
        public string NazivString => Naziv.ToString();

        public ICollection<Korisnik> Korisnici { get; set; } = [];
    }
}