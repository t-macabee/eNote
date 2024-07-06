using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eNote.API.Controllers
{
    public class CRUDController<TModel, TSearch, TInsert, TUpdate>(ICRUDService<TModel, TSearch, TInsert, TUpdate> service)
        : BaseController<TModel, TSearch>(service) where TSearch : BaseSearchObject where TModel : class
    {
        protected new ICRUDService<TModel, TSearch, TInsert, TUpdate> service = service;

        [HttpPost]
        public TModel Insert(TInsert request)
        {
            return service.Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, TUpdate request)
        {
            return service.Update(id, request);
        }
    }
}
