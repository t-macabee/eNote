using eNote.Model;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IKorisniciService : ICRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        Task<Model.Korisnik> Login(string username, string password);
    }
}
