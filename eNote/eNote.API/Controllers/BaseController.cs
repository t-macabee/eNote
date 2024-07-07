using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseController<TModel, TSearch>(IService<TModel, TSearch> service) : ControllerBase where TSearch : BaseSearchObject
    {
        protected IService<TModel, TSearch> service = service;

        [HttpGet]
        public virtual PagedResult<TModel> GetAll([FromQuery]TSearch searchObject)         
        {
            return service.GetPaged(searchObject);
        }

        [HttpGet("{id}")]
        public virtual TModel GetById(int id)
        {
            return service.GetById(id);
        }
    }
}
