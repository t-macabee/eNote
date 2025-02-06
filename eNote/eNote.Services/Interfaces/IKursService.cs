using eNote.Model.DTOs;
using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IKursService : ICRUDService<Kurs, KursSearchObject, KursInsertRequest, KursUpdateRequest>
    {

    }
}
