namespace eNote.Services.Database.Entities
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Proizvodjac { get; set; } = null!;
        public string? Opis { get; set; } 
        public byte[]? Slika { get; set; }
        public bool Dostupan { get; set; }

        public int VrstaInstrumentaId { get; set; }
        public VrstaInstrumenta VrstaInstrumenta { get; set; } = null!;
        public int MusicShopId { get; set; }
        public MusicShop MusicShop { get; set; } = null!;

        public ICollection<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenta { get; set; } = new List<IznajmljivanjeInstrumenta>();
    }
}