using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class IznajmljivanjeInstrumenta
    {
        public int Id { get; set; }
        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime? DatumPovratka { get; set; }
        public int Cijena { get; set; }

        public int StudentId { get; set; }
        public Korisnik Student { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

    }
}
