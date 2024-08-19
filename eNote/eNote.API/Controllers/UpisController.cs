using eNote.Model.DTOs;
using eNote.Model.Requests.Upis;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class UpisController(IUpisService upisService) : CRUDController<Upis, UpisSearchObject, UpisUpsertRequest, UpisUpsertRequest>(upisService)
    {
    }
}
