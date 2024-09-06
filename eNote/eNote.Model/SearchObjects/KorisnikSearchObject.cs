using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class KorisnikSearchObject : BaseSearchObject
    {
        public string? ImePrezime { get; set; }        
        public string? KorisnickoIme { get; set; }
        public string? Uloga { get; set; }
    }
}
