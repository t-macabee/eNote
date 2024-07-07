using EasyNetQ;
using eNote.Model.Pagination;
using eNote.Model.RabbitMQMessages;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace eNote.Services.Services
{
    public abstract class CRUDService<TModel, TSearch, TInsert, TUpdate, TDbEntity>(ENoteContext context, IMapper mapper)
        : BaseService<TModel, TSearch, TDbEntity>(context, mapper) where TModel : class where TSearch : BaseSearchObject where TDbEntity : class
    {
        public virtual TModel Insert(TInsert request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request), "Unos ne može biti null.");
            }

            TDbEntity entity = Mapper.Map<TDbEntity>(request);

            BeforeInsert(request, entity);

            Context.Add(entity);

            Context.SaveChanges();

            //var bus = RabbitHutch.CreateBus("host=localhost");

            var mappedEntity = Mapper.Map<TModel>(entity);

            //var message = new EntityCreated<TModel> { Entity = mappedEntity };

            //bus.PubSub.Publish(message);

            return mappedEntity;
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Unos ne može biti null.");
            }

            var entity = Context.Set<TDbEntity>().Find(id) ?? throw new ArgumentException("ID nije pronadjen.", nameof(id));

            Mapper.Map(request, entity);

            BeforeUpdate(request, entity);

            Context.SaveChanges();

            return Mapper.Map<TModel>(entity);
        }

        public virtual void BeforeInsert(TInsert request, TDbEntity entity) { }

        public virtual void BeforeUpdate(TUpdate request, TDbEntity entity) { }               
    }
}
