using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Adresa
{
    public class AdresaUpsertRequest
    {
        public string Broj { get; set; }
        public string Ulica { get; set; }
        public string Grad { get; set; }
    }
}
