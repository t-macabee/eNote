using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Obavijest
{
    public class ObavijestUpdateRequest
    {
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumVrijemeAzuriranja { get; set; }
    }
}
