using eNote.Services.Database;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicShopController : ControllerBase
    {
        protected IMusicShopService _service;

        public MusicShopController(IMusicShopService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.MusicShop> GetList()
        {
            return _service.GetAll();
        }
    }
}
