using eNote.Model.Enums;

namespace eNote.Services.Database.Entities
{
    public class IznajmljivanjeInstrumenta
    {
        public int Id { get; set; }
        public decimal CijenaIznajmljivanja { get; set; }
        public string? Napomena { get; set; }
        public DateTime? DatumPovratka { get; set; }
        public DateTime? DatumIznajmljivanja { get; set; }
        public IznajmljivanjeStatus IznajmljivanjeStatus { get; set; }

        public int PolaznikId { get; set; }
        public Polaznik Polaznik { get; set; } = null!;
        public int InstrumentId { get; set; }
        public Instrumenti Instrument { get; set; } = null!;
    }
}
