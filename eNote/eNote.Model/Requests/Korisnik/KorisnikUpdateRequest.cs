using eNote.Model.Requests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Korisnik
{
    public class KorisnikUpdateRequest : BaseMembersUpdateRequest
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
    }
}
