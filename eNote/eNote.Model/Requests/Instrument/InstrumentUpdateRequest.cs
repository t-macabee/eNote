namespace eNote.Model.Requests.Instrument
{
    public class InstrumentUpdateRequest
    {
        public string? Model { get; set; }
        public string? Opis { get; set; }
        public byte[]? Slika { get; set; }
        public bool? Dostupan { get; set; }
    }
}
