namespace eNote.Services.Database.Entities
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Grad { get; set; } = null!;
        public string Ulica { get; set; } = null!;
        public string Broj { get; set; } = null!;

        public ICollection<Polaznik> Polaznici { get; set; } = new List<Polaznik>();
        public ICollection<Instruktor> Instruktori { get; set; } = new List<Instruktor>();
        public ICollection<Administrator> Administratori { get; set; } = new List<Administrator>();
        public ICollection<MusicShop> MusicShops { get; set; } = new List<MusicShop>();
    }
}
