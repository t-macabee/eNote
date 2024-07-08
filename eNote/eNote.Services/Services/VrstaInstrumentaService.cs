using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using MapsterMapper;

namespace eNote.Services.Services
{
    public class VrstaInstrumentaService(ENoteContext context, IMapper mapper) 
        : CRUDService<Model.VrstaInstrumenta, VrstaInstrumentaSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest, Database.VrstaInstrumenta>(context, mapper), IVrstaInstrumentaService
    {
        public override IQueryable<VrstaInstrumenta> AddFilter(VrstaInstrumentaSearchObject search, IQueryable<VrstaInstrumenta> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(
            [
                x => !string.IsNullOrWhiteSpace(search?.Naziv) ? x.Where(k => k.Naziv.Contains(search.Naziv)) : x
            ]);

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            return query;
        }
    }       
}
