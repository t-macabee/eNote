using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Korisnik
{
    public class MusicShopUpdateRequest : BaseKorisnikUpdateRequest
    {
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
    }
}
