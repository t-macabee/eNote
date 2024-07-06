using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Instrument
{
    public class InstrumentInsertRequest
    {        
        public string Model { get; set; } = string.Empty;
        public string Proizvodjac { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public int VrstaInstrumentaId { get; set; }
        public int? MusicShopId { get; set; }
    }
}
