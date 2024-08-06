namespace eNote.Services.Database
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Proizvodjac { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public byte[]? Slika { get; set; } 
        public byte[]? SlikaThumb { get; set; }

        public int KorisnikId { get; set; }
        public Korisnik MusicShop { get; set; } 

        public int VrstaInstrumentaId { get; set; } 
        public VrstaInstrumenta VrstaInstrumenta { get; set; } 

        public ICollection<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenta { get; set; } = [];
    }
}