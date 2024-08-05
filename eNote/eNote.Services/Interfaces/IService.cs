using eNote.Model;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IService<TModel, TSearch> where TSearch : BaseSearchObject
    {
        public Task<TModel> GetById(int id);
        public Task<PagedResult<TModel>> GetPaged(TSearch search);
    }
}
