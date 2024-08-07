using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using eNote.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eNote.Services.Services
{
    public class InstrumentService(ENoteContext context, IMapper mapper)
        : CRUDService<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest, Instrumenti>(context, mapper), IInstrumentService
    {
        public override IQueryable<Instrumenti> AddFilter(InstrumentSearchObject search, IQueryable<Instrumenti> query)
        {
            query = base.AddFilter(search, query);

            query = QueryBuilder.ApplyFilters(query, builder =>
            {
                builder.Add("Model", search.Model)
                       .Add("Proizvodjac", search.Proizvodjac);
            });

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }

        public override async Task<Model.DTOs.Instrumenti> GetById(int id)
        {
            var entity = await QueryBuilder.ApplyChaining(context.Instrumenti).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override async Task<Model.DTOs.Instrumenti> Insert(InstrumentInsertRequest request)
        {
            await base.Insert(request);

            var entity = await QueryBuilder.ApplyChaining(context.Instrumenti).FirstOrDefaultAsync(x => x.Model == request.Model);

            return entity == null ? throw new Exception("Model nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override async Task<Model.DTOs.Instrumenti> Update(int id, InstrumentUpdateRequest request)
        {
            await base.Update(id, request);

            var entity = QueryBuilder.ApplyChaining(context.Instrumenti).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }
    }
}
