using eNote.Model;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<Korisnik>> Login(LoginModel model)
        {
            var result = await authService.Login(model);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
