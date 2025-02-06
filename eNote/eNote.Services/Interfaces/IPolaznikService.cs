using eNote.Model.DTOs;
using eNote.Model.Requests.Polaznik;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IPolaznikService : ICRUDService<Polaznik, KorisnikSearchObject, PolaznikInsertRequest, PolaznikUpdateRequest>
    {
    }
}
