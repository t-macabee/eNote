using eNote.Model.Pagination;
using eNote.Model.Requests.Instrument;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class InstrumentiController : CRUDController<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest>
    {
        public InstrumentiController(IInstrumentService service) : base(service)
        {
        }
    }
}
