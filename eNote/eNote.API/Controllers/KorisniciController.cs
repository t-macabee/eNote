using eNote.Model;
using eNote.Model.Pagination;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace eNote.API.Controllers
{
    public class KorisniciController : CRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        public KorisniciController(IKorisniciService service) : base(service)
        {
        }
    }
}
