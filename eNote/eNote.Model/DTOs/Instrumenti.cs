namespace eNote.Model.DTOs
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Proizvodjac { get; set; } = null!;
        public string? Opis { get; set; } 
        public string VrstaInstrumenta { get; set; } = null!;
        public string MusicShop { get; set; } = null!;
        public byte[]? Slika { get; set; }
        public bool Dostupan { get; set; }
    }
}
