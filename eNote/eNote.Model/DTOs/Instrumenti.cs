﻿using eNote.Model.Enums;

namespace eNote.Model.DTOs
{
    public class Instrumenti
    {
        public int Id { get; set; }
        public string Model { get; set; } 
        public string Proizvodjac { get; set; } 
        public string Opis { get; set; } 
        public string MusicShop { get; set; }
        public string VrstaInstrumenta { get; set; }
        public byte[]? Slika { get; set; }
        public bool Dostupan { get; set; }
    }
}
