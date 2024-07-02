namespace eNote.Services.Database
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }        
        public string Opis { get; set; }
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb { get; set; }

        public int MusicShopId { get; set; }
        public MusicShop MusicShop { get; set; }

        public int VrstaInstrumentaId { get; set; } 
        public VrstaInstrumenta VrstaInstrumenta { get; set; } 

        public ICollection<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenta { get; set; }
    }
}