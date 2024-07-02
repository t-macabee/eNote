using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BaseController<TModel, TSearch> : ControllerBase where TSearch : BaseSearchObject
    {
        protected IService<TModel, TSearch> service;

        public BaseController(IService<TModel, TSearch> service)
        {
            this.service = service;
        }

        [HttpGet]
        public PagedResult<TModel> GetAll([FromQuery]TSearch searchObject)         
        {
            return service.GetPaged(searchObject);
        }

        [HttpGet("{id}")]
        public TModel GetById(int id)
        {
            return service.GetById(id);
        }
    }
}
