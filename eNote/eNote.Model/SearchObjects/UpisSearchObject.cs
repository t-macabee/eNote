using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class UpisSearchObject : BaseSearchObject
    {
        public int? StudentId { get; set; }
        public int? KursId { get; set; }
    }
}
