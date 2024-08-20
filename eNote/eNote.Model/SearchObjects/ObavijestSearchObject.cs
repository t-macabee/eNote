using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class ObavijestSearchObject : BaseSearchObject
    {
        public DateTime? PocetniDatum { get; set; } 
        public DateTime? KrajnjiDatum { get; set; } 
    }
}
