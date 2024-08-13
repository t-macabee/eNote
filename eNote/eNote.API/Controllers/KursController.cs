using eNote.Model.Requests.Korisnik;
using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using eNote.Services.Services;

namespace eNote.API.Controllers
{
    public class KursController(IKursService kursService) : CRUDController<Model.DTOs.Kurs, KursSearchObject, KursInsertRequest, KursUpdateRequest>(kursService)
    {
    }
}
