using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IKursService : ICRUDService<Model.DTOs.Kurs, KursSearchObject, KursInsertRequest, KursUpdateRequest>
    {

    }
}
