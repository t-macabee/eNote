using eNote.Model.DTOs;
using eNote.Model.Requests.Korisnik;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class MusicShopController(IMusicShopService musicShopService) : CRUDController<MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest>(musicShopService)
    {
        [HttpGet("Adrese")]
        public async Task<ActionResult<List<Adresa>>> GetAddresses()
        {
            var addresses = await musicShopService.GetAddresses();
            return Ok(addresses);
        }
    }
}
