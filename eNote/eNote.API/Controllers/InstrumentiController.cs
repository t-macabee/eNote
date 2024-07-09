using eNote.Model;
using eNote.Model.DTOs;
using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
