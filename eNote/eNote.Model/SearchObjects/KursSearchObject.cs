using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class KursSearchObject : BaseSearchObject
    {
        public string? Naziv { get; set; }
        public NivoTezine? NivoTezine { get; set; }
    }
}
