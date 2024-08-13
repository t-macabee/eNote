using eNote.Model.Enums;

namespace eNote.Model.DTOs
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Proizvodjac { get; set; } = string.Empty;        
        public string Opis { get; set; } = string.Empty;
        public string MusicShop { get; set; } = string.Empty;
        public VrstaInstrumenta VrstaInstrumenta { get; set; }
    }
}
