using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Pagination
{
    public class PagedResult<T> 
    {
        public int? Count { get; set; }
        public int? CurrentPage { get; set; }
        public List<T> ResultList { get; set; } = new List<T>();
    }
}
