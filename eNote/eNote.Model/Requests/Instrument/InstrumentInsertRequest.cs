using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Instrument
{
    public class InstrumentInsertRequest
    {
        public string Model { get; set; }
        public string Proizvodjac { get; set; } 
        public string Opis { get; set; } 
        public VrstaInstrumenta VrstaInstrumenta { get; set; }
        public int? MusicShopId { get; set; }
    }
}
