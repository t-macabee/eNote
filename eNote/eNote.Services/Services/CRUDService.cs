using eNote.Model.SearchObjects;
using eNote.Services.Database;
using MapsterMapper;

namespace eNote.Services.Services
{
    public abstract class CRUDService<TModel, TSearch, TInsert, TUpdate, TDbEntity>(ENoteContext context, IMapper mapper) 
        : BaseService<TModel, TSearch, TDbEntity>(context, mapper) where TModel : class where TSearch : BaseSearchObject where TDbEntity : class
    {
        public virtual async Task<TModel> Insert(TInsert request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request), "Unos ne može biti null.");
            }

            TDbEntity entity = mapper.Map<TDbEntity>(request);

            await BeforeInsert(request, entity);

            await context.AddAsync(entity);

            await context.SaveChangesAsync();

            await context.Entry(entity).ReloadAsync();

            return mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Update(int id, TUpdate request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Unos ne može biti null.");
            }

            var entity = await context.Set<TDbEntity>().FindAsync(id) ?? throw new ArgumentException("ID nije pronadjen.", nameof(id));

            mapper.Map(request, entity);

            await BeforeUpdate(request, entity);

            await context.SaveChangesAsync();

            return mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Delete(int id)
        {
            var entity = await context.Set<TDbEntity>().FindAsync(id) ?? throw new ArgumentException("ID nije pronađen.", nameof(id));

            var temp = mapper.Map<TModel>(entity);

            context.Set<TDbEntity>().Remove(entity);

            await context.SaveChangesAsync();            

            return temp;
        }

        public virtual Task BeforeInsert(TInsert request, TDbEntity entity) => Task.CompletedTask;

        public virtual Task BeforeUpdate(TUpdate request, TDbEntity entity) => Task.CompletedTask;
    }
}
