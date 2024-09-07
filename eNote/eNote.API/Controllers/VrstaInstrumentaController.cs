using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class VrstaInstrumentaController(IVrstaInstrumentaService vrstaInstrumentaservice) : CRUDController<Model.DTOs.VrstaInstrumenta, VrstaInstrumentaSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest>(vrstaInstrumentaservice)
    {
    }
}
