using eNote.API.Authorization;
using eNote.Model;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace eNote.API.Controllers
{
    public class KorisniciController : CRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        public KorisniciController(IKorisniciService service) : base(service)
        {
        }

        [HttpPost("Login")]
        //[AllowAnonymous]
        public async Task<ActionResult<Model.Korisnik>> Login(string korisnickoIme, string lozinka)
        {
            var user = await ((KorisniciService)service).Login(korisnickoIme, lozinka);

            return user == null ? (ActionResult<Model.Korisnik>)Unauthorized("Invalid username or password") : (ActionResult<Model.Korisnik>)Ok(user);
        }

        [HttpGet("GetAllMembers")]
        //[AllowAnonymous]
        public override async Task<PagedResult<Model.Korisnik>> GetAll([FromQuery] KorisnikSearchObject searchObject)
        {
            return await base.GetAll(searchObject);
        }       
       
        [HttpPost("InsertTeacher")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> InsertTeacher([FromBody] KorisnikInsertRequest request)
        {
            var result = await service.Insert(request);
            return Ok(result);
        }

        [HttpPost("InsertStudent")]
        //[Authorize(Policy = "AdminOrTeacher")]
        public async Task<ActionResult> InsertStudent([FromBody] KorisnikInsertRequest request)
        {
            var result = await service.Insert(request);
            return Ok(result);
        }
    }
}
