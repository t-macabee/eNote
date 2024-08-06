using EasyNetQ.Events;
using eNote.Model;
using eNote.Model.DTOs;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
namespace eNote.API.Controllers
{
    public class KorisniciController(IKorisniciService korisniciService) : CRUDController<BaseKorisnik, BaseKorisnikSearchObject, BaseKorisnikInsertRequest, BaseKorisnikUpdateRequest>(korisniciService)
    {

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Invalid login request.");
            }

            var user = await korisniciService.Login(model);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(user);
        }   
             
    }
}
