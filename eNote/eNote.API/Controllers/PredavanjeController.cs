using eNote.Model.DTOs;
using eNote.Model.Requests.Predavanje;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class PredavanjeController(IPredavanjeService predavanjeService) : CRUDController<Predavanje, PredavanjeSearchObject, PredavanjeInsertRequest, PredavanjeUpdateRequest>(predavanjeService)
    {
    }
}
