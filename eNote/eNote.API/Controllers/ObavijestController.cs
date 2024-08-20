using eNote.Model.Requests.Obavijest;
using eNote.Model.Requests.Obavijesti;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class ObavijestController(IObavijestService obavijestService) : CRUDController<Model.DTOs.Obavijest, ObavijestSearchObject, ObavijestInsertRequest, ObavijestUpdateRequest>(obavijestService)
    {
    }
}
