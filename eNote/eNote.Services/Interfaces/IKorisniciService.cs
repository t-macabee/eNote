using eNote.Model;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IKorisniciService : ICRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        Task<List<Model.DTOs.Adresa>> GetAddresses();
    }
}
