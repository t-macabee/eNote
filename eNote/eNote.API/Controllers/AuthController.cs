using eNote.Model;
using eNote.Services.Database.Entities;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Login")] 
        [AllowAnonymous]    
        public async Task<ActionResult<BaseKorisnik>> Login(LoginModel model)
        {
            var korisnik = await authService.Login(model);

            if (korisnik == null)
            {
                return Unauthorized();
            }

            return Ok(korisnik);
        }
    }

}