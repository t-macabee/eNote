using eNote.Model;
using eNote.Model.DTOs;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(IKorisniciService korisniciService) : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<ActionResult<BaseKorisnik>> Login(LoginModel model)
        {
            try
            {
                var user = await korisniciService.Login(model);
                if (user != null)
                {
                    return Ok(user);
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
