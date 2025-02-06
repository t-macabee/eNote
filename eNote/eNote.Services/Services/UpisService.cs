using eNote.Model.Requests.Upis;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Database.Entities;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class UpisService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.Upis, UpisSearchObject, UpisInsertRequest, UpisUpdateRequest, Upis>(context, mapper), IUpisService
    {
        public override IQueryable<Upis> AddFilter(UpisSearchObject search, IQueryable<Upis> query)
        {
            query = base.AddFilter(search, query);

            if (search.PolaznikId.HasValue)
            {
                query = query.Where(x => x.PolaznikId == search.PolaznikId.Value);
            }

            if (search.KursId.HasValue)
            {
                query = query.Where(x => x.KursId == search.KursId.Value);
            }

            return query;
        }

        public override async Task<Model.DTOs.Upis> GetById(int id)
        {
            var entity = await context.Upis.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }
            
            return mapper.Map<Model.DTOs.Upis>(entity);
        }

        public override async Task BeforeInsert(UpisInsertRequest request, Upis entity)
        {
            var student = await context.Polaznik.FindAsync(request.PolaznikId) ?? throw new Exception("Samo korisnici sa ulogom 'Polaznik' mogu biti upisani na kurs.");

            if (await context.Upis.AnyAsync(x => x.PolaznikId == request.PolaznikId && x.KursId == request.KursId))
            {
                throw new Exception("Polaznik je prijavljen na ovaj kurs.");
            }

            entity.PolaznikId = request.PolaznikId;

            entity.KursId = request.KursId;

            var kurs = await context.Kurs.FindAsync(request.KursId);

            await base.BeforeInsert(request, entity);
        }

        public override async Task Delete(int id)
        {
            var entity = await context.Upis.Include(x => x.Kurs).FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentException("ID nije pronađen", nameof(id));

            context.Upis.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
