using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eNote.API.Controllers
{
    public class CRUDController<TModel, TSearch, TInsert, TUpdate> : BaseController<TModel, TSearch> where TSearch : BaseSearchObject where TModel : class
    {
        protected new ICRUDService<TModel, TSearch, TInsert, TUpdate> service;

        public CRUDController(ICRUDService<TModel, TSearch, TInsert, TUpdate> service) : base(service)
        {
            this.service = service;
        }

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
