namespace eNote.Services.Database
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Vrsta { get; set; }
        public string Opis { get; set; }

        public int MusicShopId { get; set; }
        public MusicShop MusicShop { get; set; }

        public ICollection<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenta { get; set; }
    }
}