using eNote.Model.Requests.Obavijest;
using eNote.Model.Requests.Obavijesti;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class ObavijestController(INapomenaService obavijestService) : CRUDController<Model.DTOs.Napomena, NapomenaSearchObject, NapomenaInsertRequest, NapomenaUpdateRequest>(obavijestService)
    {
    }
}
