using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Database.Entities;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class InstrumentService(ENoteContext context, IMapper mapper)
        : CRUDService<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest, Instrumenti>(context, mapper), IInstrumentService
    {
        public override IQueryable<Instrumenti> AddFilter(InstrumentSearchObject search, IQueryable<Instrumenti> query)
        {
            query = base.AddFilter(search, query).Include(x => x.MusicShop).Include(x => x.VrstaInstrumenta);

            if (!string.IsNullOrEmpty(search.Model))
            {
                query = query.Where(x => x.Model.Contains(search.Model));
            }

            if (!string.IsNullOrEmpty(search.Proizvodjac))
            {
                query = query.Where(x => x.Proizvodjac.Contains(search.Proizvodjac));
            }

            if (!string.IsNullOrEmpty(search.VrstaInstrumenta))
            {
                if (int.TryParse(search.VrstaInstrumenta, out int vrstaInstrumentaId))
                {
                    query = query.Where(x => x.VrstaInstrumenta.Id == vrstaInstrumentaId);
                }
            }

            if (search.ShopId.HasValue)
            {
                query = query.Where(x => x.MusicShop.Id == search.ShopId.Value);
            }

            return query;
        }

        public override async Task<Model.DTOs.Instrumenti> GetById(int id)
        {
            var entity = await context.Instrumenti.Include(x => x.MusicShop).Include(x => x.VrstaInstrumenta).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override async Task BeforeInsert(InstrumentInsertRequest request, Instrumenti entity)
        {
            entity.Dostupan = true;
            await base.BeforeInsert(request, entity);
        }

        //public override async Task<Model.DTOs.Instrumenti> Insert(InstrumentInsertRequest request)
        //{
        //    await base.Insert(request);

        //    var entity = await context.Instrumenti.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop).FirstOrDefaultAsync(x => x.Model == request.Model);

        //    return entity == null ? throw new Exception("Model nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        //}

        public override async Task<Model.DTOs.Instrumenti> Update(int id, InstrumentUpdateRequest request)
        {
            await base.Update(id, request);

            var entity = await context.Instrumenti.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }
    }
}
