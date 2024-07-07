using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace eNote.API.Controllers
{
    public class KorisniciController(IKorisniciService service) : CRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>(service)
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public Model.Korisnik Login(string korisnickoIme, string lozinka)
        {
            return ((KorisniciService)service).Login(korisnickoIme, lozinka);
        }
    }
}
