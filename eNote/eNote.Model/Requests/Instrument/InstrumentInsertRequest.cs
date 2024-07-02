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
        public int VrstaInstrumentaId { get; set; }
        public int? MusicShopId { get; set; }
    }
}
