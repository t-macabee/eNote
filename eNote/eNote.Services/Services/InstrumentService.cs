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

            if (!string.IsNullOrWhiteSpace(search?.Model))
            {
                query = query.Where(x => x.Model.StartsWith(search.Model));
            }

            if (!string.IsNullOrWhiteSpace(search?.Proizvodjac))
            {
                query = query.Where(x => x.Model.StartsWith(search.Proizvodjac));
            }

            int count = query.Count();

            if (search?.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value)
                    .Take(search.PageSize.Value);
            }

            query = QueryChain.IncludeInstrumenti(query);

            return query;
        }

        public override Model.DTOs.Instrumenti GetById(int id)
        {
            var entity = QueryChain.IncludeInstrumenti(context.Instrumenti).FirstOrDefault(x => x.Id == id);

            return entity != null ? mapper.Map<Model.DTOs.Instrumenti>(entity) : null;
        }

        public override Model.DTOs.Instrumenti Insert(InstrumentInsertRequest request)
        {
            base.Insert(request);

            var entity = QueryChain.IncludeInstrumenti(context.Instrumenti).FirstOrDefault(x => x.Model == request.Model);

            return mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override Model.DTOs.Instrumenti Update(int id, InstrumentUpdateRequest request)
        {
            base.Update(id, request);

            var entity = QueryChain.IncludeInstrumenti(context.Instrumenti).FirstOrDefault(x => x.Id == id);

            return mapper.Map<Model.DTOs.Instrumenti>(entity);
        }
    }
}
