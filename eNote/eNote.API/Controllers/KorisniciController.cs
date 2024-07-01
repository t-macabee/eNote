using eNote.Model;
using eNote.Model.Pagination;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : ControllerBase
    {
        protected IKorisniciService _service;

        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public PagedResult<Korisnik> GetList([FromQuery]KorisnikSearchObject searchObject)
        {
            return _service.GetAll(searchObject);
        }

        [HttpGet("{id}")]
        public Korisnik GetById(int id) 
        { 
            return _service.GetById(id);        
        }

        [HttpPost]
        public Korisnik Insert(KorisnikInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
