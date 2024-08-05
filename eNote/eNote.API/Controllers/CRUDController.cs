using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class CRUDController<TModel, TSearch, TInsert, TUpdate>(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : BaseController<TModel, TSearch>(service) where TSearch : BaseSearchObject where TModel : class
    {
        protected new ICRUDService<TModel, TSearch, TInsert, TUpdate> service = service;

        [HttpPost]        
        public virtual async Task<TModel> Insert(TInsert request)
        {
            return await service.Insert(request);
        }

        [HttpPut("{id}")]
        public virtual async Task<TModel> Update(int id, TUpdate request)
        {
            return await service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public virtual async Task<TModel> DeleteAsync(int id) 
        { 
            return await service.Delete(id); 
        }
    }
}
