using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class KursSearchObject : BaseSearchObject
    {
        public int? instruktorId { get; set; }
        public string? Naziv { get; set; }
    }
}
