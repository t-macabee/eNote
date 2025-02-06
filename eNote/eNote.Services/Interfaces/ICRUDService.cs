using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface ICRUDService<TModel, TSearch, TInsert, TUpdate> : IService<TModel, TSearch> where TModel : class where TSearch : BaseSearchObject
    {
        Task<TModel> Insert(TInsert request);
        Task<TModel> Update(int id, TUpdate request);
        Task Delete(int id);
    }
}
