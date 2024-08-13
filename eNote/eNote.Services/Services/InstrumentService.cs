using eNote.Model.Requests.Instrument;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using eNote.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Azure.Core;
using eNote.Model.Enums;

namespace eNote.Services.Services
{
    public class InstrumentService(ENoteContext context, IMapper mapper)
        : CRUDService<Model.DTOs.Instrumenti, InstrumentSearchObject, InstrumentInsertRequest, InstrumentUpdateRequest, Instrumenti>(context, mapper), IInstrumentService
    {
        public override IQueryable<Instrumenti> AddFilter(InstrumentSearchObject search, IQueryable<Instrumenti> query)
        {
            query = base.AddFilter(search, query).Include(x => x.MusicShop)
                .Where(x =>
                    (string.IsNullOrEmpty(search.Model) || x.Model.StartsWith(search.Model)) &&
                    (string.IsNullOrEmpty(search.Proizvodjac) || x.Proizvodjac.StartsWith(search.Proizvodjac))
                );         

            return query; 
        }

        public override async Task<Model.DTOs.Instrumenti> GetById(int id)
        {
            var entity = await context.Instrumenti.Include(x => x.MusicShop).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override async Task<Model.DTOs.Instrumenti> Insert(InstrumentInsertRequest request)
        {
            await base.Insert(request);

            var entity = await context.Instrumenti.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop).FirstOrDefaultAsync(x => x.Model == request.Model);

            return entity == null ? throw new Exception("Model nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }

        public override async Task<Model.DTOs.Instrumenti> Update(int id, InstrumentUpdateRequest request)
        {
            await base.Update(id, request);

            var entity = await context.Instrumenti.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? throw new KeyNotFoundException("ID nije pronadjen.") : mapper.Map<Model.DTOs.Instrumenti>(entity);
        }
    }
}
