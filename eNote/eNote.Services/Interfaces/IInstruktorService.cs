using eNote.Model.DTOs;
using eNote.Model.Requests.Instruktor;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IInstruktorService : ICRUDService<Instruktor, KorisnikSearchObject, InstruktorInsertRequest, InstruktorUpdateRequest>
    {
    }
}
