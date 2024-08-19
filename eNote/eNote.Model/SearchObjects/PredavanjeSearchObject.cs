using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class PredavanjeSearchObject : BaseSearchObject
    {
        public string? Naziv {  get; set; }
        public StatusPredavanja? StatusPredavanja { get; set; }
        public TipPredavanja? TipPredavanja { get; set; }
    }
}
