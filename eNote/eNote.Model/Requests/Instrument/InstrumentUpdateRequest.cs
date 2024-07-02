using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Instrument
{
    public class InstrumentUpdateRequest
    {
        public string? Model { get; set; }
        public string? Proizvodjac { get; set; }
        public string? Opis { get; set; }
    }
}
