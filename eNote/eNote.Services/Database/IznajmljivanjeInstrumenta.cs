using System.Diagnostics.Metrics;

namespace eNote.Services.Database
{
    public class IznajmljivanjeInstrumenta
    {
        public int Id { get; set; }
        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime DatumVracanja { get; set; }
        public bool Vracen { get; set; }

        public int StudentId { get; set; }
        public Korisnik Student { get; set; } 

        public int InstrumentId { get; set; }
        public Instrumenti Instrument { get; set; }
    }
}
