using System;

namespace eNote.Model.Requests.Obavijest
{
    public class NapomenaUpdateRequest
    {
        public string? Naziv { get; set; }
        public string? Sadrzaj { get; set; }
        public DateTime? DatumVrijemeAzuriranja { get; set; } = DateTime.Now;
    }
}
