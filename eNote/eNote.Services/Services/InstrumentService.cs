using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Model.DTOs;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using eNote.Model.Pagination;
using eNote.Services.Helpers;

namespace eNote.Services.Services
{
    public class InstrumentService : CRUDService<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest, Database.Instrumenti>, IInstrumentService
    {
        public InstrumentService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Instrumenti> AddFilter(InstrumentSearchObject search, IQueryable<Database.Instrumenti> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(new List<Func<IQueryable<Database.Instrumenti>, IQueryable<Database.Instrumenti>>>
            {
                x => !string.IsNullOrWhiteSpace(search?.Model) ? x.Where(k => k.Model.StartsWith(search.Model)) : x,
                x => !string.IsNullOrWhiteSpace(search?.Proizvodjac) ? x.Where(k => k.Proizvodjac.StartsWith(search.Proizvodjac)) : x,                
            });

            int count = query.Count();

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }

        public override Model.DTOs.Instrumenti GetById(int id)
        {
            var entity = QueryBuilder.ApplyChaining(context.Instrumenti).FirstOrDefault(x => x.Id == id);

            return entity != null ? mapper.Map<Model.DTOs.Instrumenti>(entity) : null;
        }

        public override Model.DTOs.Instrumenti Insert(InstrumentInsertRequest request)
        {
            base.Insert(request);

            var entity = QueryBuilder.ApplyChaining(context.Instrumenti).FirstOrDefault(x => x.Model == request.Model);

            return mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override Model.DTOs.Instrumenti Update(int id, InstrumentUpdateRequest request)
        {
            base.Update(id, request);

            var entity = QueryBuilder.ApplyChaining(context.Instrumenti).FirstOrDefault(x => x.Id == id);

            return mapper.Map<Model.DTOs.Instrumenti>(entity);
        }
    }
}
