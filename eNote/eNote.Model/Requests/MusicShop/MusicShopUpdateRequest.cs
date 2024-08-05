using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.MusicShop
{
    public class MusicShopUpdateRequest
    {         
        public string? Naziv { get; set; }
        public string? Adresa { get; set; }
        public string? Telefon { get; set; }
        public string? KorisnickoIme { get; set; } 
    }
}
