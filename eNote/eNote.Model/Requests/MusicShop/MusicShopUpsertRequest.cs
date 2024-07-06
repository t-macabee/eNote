using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.MusicShop
{
    public class MusicShopUpsertRequest
    {         
        public string Naziv { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
    }
}
