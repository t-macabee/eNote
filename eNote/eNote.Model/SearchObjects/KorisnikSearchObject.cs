using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class KorisnikSearchObject : BaseSearchObject
    {
        public string? ImeGTE { get; set; }
        public string? PrezimeGTE { get; set; }
        public string? KorisnickoIme { get; set; }  
        public string? Grad { get; set; }
    }
}
