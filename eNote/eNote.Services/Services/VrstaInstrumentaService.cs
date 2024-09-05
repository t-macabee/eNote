using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class VrstaInstrumentaService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.VrstaInstrumenta, VrstaInstrumentaSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest, Database.VrstaInstrumenta>(context, mapper), IVrstaInstrumentaService
    {
        public override IQueryable<VrstaInstrumenta> AddFilter(VrstaInstrumentaSearchObject search, IQueryable<VrstaInstrumenta> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(search.Naziv));
            }

            return query;
        }

        public override async Task BeforeInsert(VrstaInstrumentaUpsertRequest request, VrstaInstrumenta entity)
        {
            var existingType = await context.VrstaInstrumenta.FirstOrDefaultAsync(x => x.Naziv == request.Naziv);

            if (existingType != null)
            {
                throw new Exception("Vrsta instrumenta već postoji.");
            }

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(VrstaInstrumentaUpsertRequest request, VrstaInstrumenta entity)
        {
            var existingType = await context.VrstaInstrumenta.FirstOrDefaultAsync(x => x.Naziv == request.Naziv);

            if (existingType != null)
            {
                throw new Exception("Vrsta instrumenta pod tim nazivom već postoji.");
            }

            await base.BeforeUpdate(request, entity);
        }
    }
}
