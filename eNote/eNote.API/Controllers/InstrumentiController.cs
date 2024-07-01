using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class InstrumentiController : BaseController<Model.Instrumenti, InstrumentSearchObject>
    {
        public InstrumentiController(IInstrumentService service) : base(service)
        {
        }
    }
}
