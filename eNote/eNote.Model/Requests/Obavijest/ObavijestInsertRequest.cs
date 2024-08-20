using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Obavijesti
{
    public class ObavijestInsertRequest
    {
        public int PredavanjeId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumVrijemePostavljanja { get; set; }
    }
}
