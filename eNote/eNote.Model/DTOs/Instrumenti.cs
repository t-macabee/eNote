using eNote.Model.Enums;

namespace eNote.Model.DTOs
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Model { get; set; } 
        public string Proizvodjac { get; set; } 
        public string Opis { get; set; } 
        public string MusicShop { get; set; }
        public VrstaInstrumenta VrstaInstrumenta { get; set; }
        public bool Dostupan { get; set; }
    }
}
