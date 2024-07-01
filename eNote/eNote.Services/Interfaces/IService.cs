using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface IService<TModel, TSearch> where TSearch : BaseSearchObject
    {
        public TModel GetById(int id);
        public PagedResult<TModel> GetPaged(TSearch search);
    }
}
