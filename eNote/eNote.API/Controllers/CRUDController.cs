using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eNote.API.Controllers
{
    public class CRUDController<TModel, TSearch, TInsert, TUpdate> : BaseController<TModel, TSearch> where TSearch : BaseSearchObject where TModel : class
    {        
        public CRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : base(service)
        {            
        }

        [HttpPost]
        public TModel Insert(TInsert request)
        {
            return (service as ICRUDService<TModel, TSearch, TInsert, TUpdate>).Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, TUpdate request)
        {
            return (service as ICRUDService<TModel, TSearch, TInsert, TUpdate>).Update(id, request);
        }
    }
}
