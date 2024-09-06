using eNote.Model.DTOs;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class MusicShopController(IMusicShopService musicShopService) : CRUDController<MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest>(musicShopService)
    {
        [HttpGet("Instrumenti/{id}")]
        public async Task<IActionResult> GetInstrumentsByShop(int id)
        {
            var instruments = await musicShopService.GetInstumentiByShop(id);
            if (instruments == null || instruments.Count == 0)
            {
                return NotFound("No instruments found for the specified shop.");
            }
            return Ok(instruments);
        }
    }
}
