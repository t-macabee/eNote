using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class KursController(IKursService kursService) : CRUDController<Model.DTOs.Kurs, KursSearchObject, KursInsertRequest, KursUpdateRequest>(kursService)
    {
    }
}
