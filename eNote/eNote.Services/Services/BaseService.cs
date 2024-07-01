using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Services
{
    public class BaseService<TModel, TSearch, TDbEntity> : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
    {
        public eNoteContext context { get; set; }
        public IMapper mapper { get; set; }

        public BaseService(eNoteContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TModel GetById(int id)
        {
            var entity = context.Set<TDbEntity>().Find(id);

            if(entity != null)
            {
                return mapper.Map<TModel>(entity);
            }
            else 
            {
                return null;
            }            
        }

        public PagedResult<TModel> GetPaged(TSearch search)
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

            var resultList = mapper.Map<List<TModel>>(list);

            return new PagedResult<TModel>
            {
                ResultList = resultList,
                Count = count
            };
        }

        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query)
        {
            return query;
        }
    }
}
