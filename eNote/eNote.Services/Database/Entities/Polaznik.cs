namespace eNote.Services.Database.Entities
{
    public class Polaznik : BaseKorisnik
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }

        public ICollection<Upis> Upis { get; set; } = new List<Upis>();
        public ICollection<Prisustvo> Prisustvo { get; set; } = new List<Prisustvo>();
        public ICollection<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenta { get; set; } = new List<IznajmljivanjeInstrumenta>();
        public ICollection<PredajaZadatka> PredajaZadatka { get; set; } = new List<PredajaZadatka>();
    }
}
