using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class BaseKorisnikSearchObject : BaseSearchObject
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? Naziv { get; set; }
        public string? Grad { get; set; }
    }
}
