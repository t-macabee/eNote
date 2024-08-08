using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;


namespace eNote.API.Controllers
{
    public class InstrumentiController(IInstrumentService service) : CRUDController<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest>(service)
    {
    }
}
