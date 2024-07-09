using eNote.Model;
using eNote.Model.Requests.Instrument;
using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class VrstaInstrumentaController : CRUDController<Model.VrstaInstrumenta, VrstaInstrumentaSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest>
    {
        public VrstaInstrumentaController(IVrstaInstrumentaService service) : base(service)
        {
        }
    }
}
