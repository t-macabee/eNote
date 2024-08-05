using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.MusicShop
{
    public class MusicShopInsertRequest
    {
        public string Naziv {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Lozinka { get; set; } = string.Empty;
        public string LozinkaPotvrda { get; set; } = string.Empty;
        public int UlogaId { get; set; }
        public int? AdresaId { get; set; }
    }
}
