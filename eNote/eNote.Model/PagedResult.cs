using System.Collections.Generic;

namespace eNote.Model
{
    public class PagedResult<T>
    {
        public int? Count { get; set; }
        public int? CurrentPage { get; set; }
        public List<T> ResultList { get; set; } = new List<T>();
    }
}
