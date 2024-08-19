using eNote.Model.Requests.Upis;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IUpisService : ICRUDService<Model.DTOs.Upis, UpisSearchObject, UpisUpsertRequest, UpisUpsertRequest>
    {
    }
}
