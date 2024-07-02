using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Model.DTOs;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using eNote.Model.Pagination;

namespace eNote.Services.Services
{
    public class InstrumentService : CRUDService<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest, Database.Instrumenti>, IInstrumentService
    {
        public InstrumentService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override Model.DTOs.Instrumenti GetById(int id)
        {
            var entity = context.Instrumenti.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop).FirstOrDefault(x => x.Id == id);

            return entity != null ? mapper.Map<Model.DTOs.Instrumenti>(entity) : null;
        }

        public override PagedResult<Model.DTOs.Instrumenti> GetPaged(InstrumentSearchObject search)
        {
            var query = context.Instrumenti.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop).AsQueryable();

            query = AddFilter(search, query);

            int count = query.Count();

            if (search?.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value)
                             .Take(search.PageSize.Value);
            }

            var list = query.ToList();

            var resultList = mapper.Map<List<Model.DTOs.Instrumenti>>(list);

            return new PagedResult<Model.DTOs.Instrumenti>
            {
                ResultList = resultList,
                Count = count
            };
        }

        public override Model.DTOs.Instrumenti Insert(InstrumentInsertRequest request)
        {
            var entity = mapper.Map<Database.Instrumenti>(request);

            BeforeInsert(request, entity);

            context.Add(entity);

            context.SaveChanges();

            return mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override Model.DTOs.Instrumenti Update(int id, InstrumentUpdateRequest request)
        {
            var entity = context.Set<Database.Instrumenti>().Find(id);

            mapper.Map(request, entity);

            BeforeUpdate(request, entity);

            context.SaveChanges();

            return mapper.Map<Model.DTOs.Instrumenti>(entity);
        }
    }

}
