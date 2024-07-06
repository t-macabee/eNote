using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using eNote.Services.Helpers;

namespace eNote.Services.Services
{
    public class InstrumentService(ENoteContext context, IMapper mapper) 
        : CRUDService<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest, Instrumenti>(context, mapper), IInstrumentService
    {
        public override IQueryable<Instrumenti> AddFilter(InstrumentSearchObject search, IQueryable<Instrumenti> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(
            [
                x => !string.IsNullOrWhiteSpace(search?.Model) ? x.Where(k => k.Model.StartsWith(search.Model)) : x,
                x => !string.IsNullOrWhiteSpace(search?.Proizvodjac) ? x.Where(k => k.Proizvodjac.StartsWith(search.Proizvodjac)) : x,                
            ]);

            int count = query.Count();

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }

        public override Model.DTOs.Instrumenti GetById(int id)
        {
            var entity = QueryBuilder.ApplyChaining(Context.Instrumenti).FirstOrDefault(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : Mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override Model.DTOs.Instrumenti Insert(InstrumentInsertRequest request)
        {
            base.Insert(request);

            var entity = QueryBuilder.ApplyChaining(Context.Instrumenti).FirstOrDefault(x => x.Model == request.Model);

            return entity == null ? throw new Exception("Model nije pronadjen.") : Mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override Model.DTOs.Instrumenti Update(int id, InstrumentUpdateRequest request)
        {
            base.Update(id, request);

            var entity = QueryBuilder.ApplyChaining(Context.Instrumenti).FirstOrDefault(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : Mapper.Map<Model.DTOs.Instrumenti>(entity);

        }
    }
}
