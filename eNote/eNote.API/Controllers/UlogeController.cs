using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class UlogeController(IUlogeService service) : BaseController<Model.DTOs.Uloge, UlogeSearchObject>(service)
    {
    }
}
