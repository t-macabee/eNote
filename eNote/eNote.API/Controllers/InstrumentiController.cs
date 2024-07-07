using eNote.Model.DTOs;
using eNote.Model.Pagination;
using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class InstrumentiController(IInstrumentService service) 
        : CRUDController<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest>(service)
    {
        [Authorize(Roles = "Administrator")]
        public override Instrumenti Insert(InstrumentInsertRequest request)
        {
            return base.Insert(request);
        }

        [AllowAnonymous]
        public override PagedResult<Instrumenti> GetAll([FromQuery] InstrumentSearchObject searchObject)
        {
            return base.GetAll(searchObject);
        }
    }
}
