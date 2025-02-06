using eNote.Model.DTOs;
using eNote.Model.Requests.Obavijest;
using eNote.Model.Requests.Obavijesti;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface INapomenaService : ICRUDService<Napomena, NapomenaSearchObject, NapomenaInsertRequest, NapomenaUpdateRequest>
    {
    }
}
