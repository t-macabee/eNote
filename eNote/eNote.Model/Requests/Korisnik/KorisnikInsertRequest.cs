using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Korisnik
{
    public class KorisnikInsertRequest : BaseKorisnikInsertRequest
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }
    }
}
