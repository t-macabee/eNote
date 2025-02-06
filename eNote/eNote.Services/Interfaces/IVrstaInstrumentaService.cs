using eNote.Model.DTOs;
using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IVrstaInstrumentaService : ICRUDService<VrstaInstrumenta, VrstaInstrumentaSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest>
    {       
    }
}
