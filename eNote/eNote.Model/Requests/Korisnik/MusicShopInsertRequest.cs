using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Korisnik
{
    public class MusicShopInsertRequest : BaseKorisnikInsertRequest
    {
        public string Naziv { get; set; } = string.Empty;
    }
}
