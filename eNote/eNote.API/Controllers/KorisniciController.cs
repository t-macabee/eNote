using eNote.Model;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Microsoft.AspNetCore.Mvc;
namespace eNote.API.Controllers
{
    public class KorisniciController(IKorisniciService service) : CRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>(service)
    {
        
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
