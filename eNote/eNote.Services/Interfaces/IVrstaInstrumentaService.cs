using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.Services.Services
{
    public interface IVrstaInstrumentaService : ICRUDService<Model.VrstaInstrumenta, NazivSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest>
    {
    }
}
