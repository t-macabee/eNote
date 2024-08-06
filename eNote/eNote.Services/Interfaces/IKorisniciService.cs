using eNote.Model;
using eNote.Model.DTOs;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IKorisniciService : ICRUDService<BaseKorisnik, BaseKorisnikSearchObject, BaseKorisnikInsertRequest, BaseKorisnikUpdateRequest>
    {
        Task<BaseKorisnik> Login(LoginModel model);
    }
}
