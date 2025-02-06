namespace eNote.Model.Requests.Instrument
{
    public class InstrumentInsertRequest
    {
        public string Model { get; set; } = null!;
        public string Proizvodjac { get; set; } = null!;
        public string Opis { get; set; } = string.Empty;
        public byte[]? Slika { get; set; }
        public bool Dostupan {  get; set; }

        public int VrstaInstrumentaId { get; set; }
        public int MusicShopId { get; set; }
    }
}
