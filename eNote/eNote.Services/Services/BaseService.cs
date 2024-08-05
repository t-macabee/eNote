using eNote.Model;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;


namespace eNote.Services.Services
{
    public abstract class BaseService<TModel, TSearch, TDbEntity>(ENoteContext context, IMapper mapper) 
        : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
    {
        public ENoteContext context { get; set; } = context;
        public IMapper mapper { get; set; } = mapper;

        public virtual async Task<TModel> GetById(int id)
        {
            var entity = await context.Set<TDbEntity>().FindAsync(id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<TModel>(entity);
        }

        public virtual async Task<PagedResult<TModel>> GetPaged(TSearch search)
        {
            var query = context.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);

            int count = await query.CountAsync();

            if (search?.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value)
                    .Take(search.PageSize.Value);
            }

            var list = await query.ToListAsync();

            var result = mapper.Map<List<TModel>>(list);  

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
