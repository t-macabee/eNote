using System;

namespace eNote.Model.Requests.Kurs
{
    public class KursInsertRequest
    {
        public int InstruktorId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = string.Empty;
        public decimal Cijena { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }
    }
}
