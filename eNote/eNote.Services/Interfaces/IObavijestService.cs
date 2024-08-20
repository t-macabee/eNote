using eNote.Model.Requests.Obavijest;
using eNote.Model.Requests.Obavijesti;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IObavijestService : ICRUDService<Model.DTOs.Obavijest, ObavijestSearchObject, ObavijestInsertRequest, ObavijestUpdateRequest>
    {
    }
}
