using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
namespace eNote.API.Controllers
{
    public class KorisniciController(IKorisniciService service) : CRUDController<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>(service)
    {
    }
}
