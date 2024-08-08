using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using MapsterMapper;

namespace eNote.Services.Services
{
    public class VrstaInstrumentaService(ENoteContext context, IMapper mapper)
        : CRUDService<Model.VrstaInstrumenta, NazivSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest, Database.VrstaInstrumenta>(context, mapper), IVrstaInstrumentaService
    {
        public override IQueryable<VrstaInstrumenta> AddFilter(NazivSearchObject search, IQueryable<VrstaInstrumenta> query)
        {
            query = base.AddFilter(search, query);

            return query;
        }
        
    }
}
