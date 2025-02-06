using System;

namespace eNote.Model.SearchObjects
{
    public class NapomenaSearchObject : BaseSearchObject
    {
        public string? Predavanje { get; set; }
        public DateTime? Od { get; set; } 
        public DateTime? Do { get; set; } 
    }
}
