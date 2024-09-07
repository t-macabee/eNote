using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class UlogeController(IUlogeService ulogeService) : BaseController<Model.DTOs.Uloge, UlogeSearchObject>(ulogeService)
    {
    }
}
