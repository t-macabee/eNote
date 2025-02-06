using eNote.Model.DTOs;
using eNote.Model.Requests.Upis;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IUpisService : ICRUDService<Upis, UpisSearchObject, UpisInsertRequest, UpisUpdateRequest>
    {
    }
}
