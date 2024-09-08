using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class PredavanjeSearchObject : BaseSearchObject
    {
        public int? KursId { get; set; }
        public string? Naziv { get; set; }
    }
}
