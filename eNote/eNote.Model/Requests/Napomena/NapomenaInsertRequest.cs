using System;

namespace eNote.Model.Requests.Obavijesti
{
    public class NapomenaInsertRequest
    {
        public int PredavanjeId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Sadrzaj { get; set; } = null!;
        public DateTime DatumVrijemePostavljanja { get; set; }
    }
}
