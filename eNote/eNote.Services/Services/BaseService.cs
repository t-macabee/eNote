using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;


namespace eNote.Services.Services
{
    public abstract class BaseService<TModel, TSearch, TDbEntity>(ENoteContext context, IMapper mapper) 
        : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
    {
        public ENoteContext Context { get; set; } = context;
        public IMapper Mapper { get; set; } = mapper;

        public virtual TModel GetById(int id)
        {
            var entity = Context.Set<TDbEntity>().Find(id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : Mapper.Map<TModel>(entity);
        }

        public virtual PagedResult<TModel> GetPaged(TSearch search)
        {
            var query = Context.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);

            int count = query.Count();

            if (search?.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value)
                    .Take(search.PageSize.Value);
            }

            var list = query.ToList();

            var result = Mapper.Map<List<TModel>>(list);  

            return new PagedResult<TModel>
            {
                ResultList = result,
                Count = count,
                CurrentPage = list.Count
            };
        }
        
        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query) => query;        
    }
}
