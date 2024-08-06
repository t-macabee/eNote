using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Korisnik
{
    public class BaseKorisnikUpdateRequest
    {
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Lozinka { get; set; }
        public string? LozinkaPotvrda { get; set; }
    }
}
