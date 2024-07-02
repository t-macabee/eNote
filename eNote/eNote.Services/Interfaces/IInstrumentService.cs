using eNote.Model.DTOs;
using eNote.Model.Pagination;
using eNote.Model.Requests.Instrument;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using System.Runtime.CompilerServices;

namespace eNote.Services.Interfaces
{
    public interface IInstrumentService : ICRUDService<Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest>
    {        
    }
}
