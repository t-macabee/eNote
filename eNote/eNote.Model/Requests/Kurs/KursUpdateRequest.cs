using System;

namespace eNote.Model.Requests.Kurs
{
    public class KursUpdateRequest
    {
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public decimal? Cijena { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }        
    }
}
