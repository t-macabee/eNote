using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace eNote.Services.Services
{
    public abstract class CRUDService<TModel, TSearch, TInsert, TUpdate, TDbEntity> : BaseService<TModel, TSearch, TDbEntity>
    where TModel : class
    where TSearch : BaseSearchObject
    where TDbEntity : class
    {
        public CRUDService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            TDbEntity entity = mapper.Map<TDbEntity>(request);

            BeforeInsert(request, entity);

            context.Add(entity);

            context.SaveChanges();

            return mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = context.Set<TDbEntity>().Find(id);

            mapper.Map(request, entity);

            BeforeUpdate(request, entity);

            context.SaveChanges();

            return mapper.Map<TModel>(entity);
        }

        public virtual void BeforeInsert(TInsert request, TDbEntity entity) { }

        public virtual void BeforeUpdate(TUpdate request, TDbEntity entity) { }               
    }
}
