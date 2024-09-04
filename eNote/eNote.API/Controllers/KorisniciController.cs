using eNote.Model.DTOs;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class KorisniciController(IKorisniciService korisniciService) : CRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>(korisniciService)
    {
        [HttpGet("Adrese")]        
        public async Task<ActionResult<List<Adresa>>> GetAddresses()
        {           
            var addresses = await korisniciService.GetAddresses();
            return Ok(addresses);          
        }

        [HttpGet("CurrentUser")]
        public async Task<ActionResult> GetCurrentUser()
        {
            var user = await korisniciService.GetCurrentUser();
            return Ok(user);
        }
    }
}
