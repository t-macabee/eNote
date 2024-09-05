using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class PredavanjeSearchObject : BaseSearchObject
    {
        public string? Naziv { get; set; }
        public StanjePredavanja? StanjePredavanja { get; set; }
        public string? TipPredavanja { get; set; }
    }
}
