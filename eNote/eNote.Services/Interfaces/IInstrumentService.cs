using eNote.Model.DTOs;
using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IInstrumentService : ICRUDService<Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest>
    {
    }
}
