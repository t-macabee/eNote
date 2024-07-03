using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;


namespace eNote.Services.Services
{
    public abstract class BaseService<TModel, TSearch, TDbEntity> : IService<TModel, TSearch>
    where TSearch : BaseSearchObject
    where TDbEntity : class
    where TModel : class
    {
        public eNoteContext context { get; set; }
        public IMapper mapper { get; set; }

        public BaseService(eNoteContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public virtual TModel GetById(int id)
        {
            var entity = context.Set<TDbEntity>().Find(id);

            return entity != null ? mapper.Map<TModel>(entity) : null;
        }

        public virtual PagedResult<TModel> GetPaged(TSearch search)
        {
            var query = context.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);

            int count = query.Count();

            if (search?.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value)
                    .Take(search.PageSize.Value);
            }

            var list = query.ToList();

            var result = mapper.Map<List<TModel>>(list);  

            return new PagedResult<TModel>
            {
                ResultList = result,
                Count = count
            };
        }
        
        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query) => query;        
    }
}
