using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(IKorisniciService korisniciService, IMusicShopService musicShopService) : ControllerBase
    {
        private readonly IKorisniciService korisniciService = korisniciService ?? throw new ArgumentNullException(nameof(korisniciService));
        private readonly IMusicShopService musicShopService = musicShopService ?? throw new ArgumentNullException(nameof(musicShopService));

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Login(string korisnickoIme, string lozinka)
        {
            try
            {
                var user = await korisniciService.Login(korisnickoIme, lozinka);
                if (user != null)
                {
                    return Ok(user);
                }

                var musicShop = await musicShopService.Login(korisnickoIme, lozinka);
                if (musicShop != null)
                {
                    return Ok(musicShop);
                }

                return Unauthorized("Invalid username or password");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
