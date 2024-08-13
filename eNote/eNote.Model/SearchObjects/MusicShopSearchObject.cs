using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class MusicShopSearchObject : BaseSearchObject
    {
        public string? KorisnickoIme { get; set; }
        public string? Naziv {  get; set; }
        public string? Grad { get; set; }
    }
}
