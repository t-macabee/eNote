using eNote.Model.Enums;
using eNote.Model.Requests.Upis;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
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

            if (search.StudentId.HasValue)
            {
                query = query.Where(x => x.StudentId == search.StudentId.Value);
            }

            if (search.KursId.HasValue)
            {
                query = query.Where(x => x.KursId == search.KursId.Value);
            }

            return query;
        }

        public override async Task<Model.DTOs.Upis> GetById(int id)
        {
            var entity = await context.Upisi.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }
            
            return mapper.Map<Model.DTOs.Upis>(entity);
        }

        public override async Task BeforeInsert(UpisInsertRequest request, Upis entity)
        {
            var student = await context.Korisnici.FindAsync(request.StudentId);

            if (student == null || student.UlogaId != 3)
            {
                throw new Exception("Samo korisnici sa ulogom 'Polaznik' mogu biti upisani na kurs.");
            }

            if (await context.Upisi.AnyAsync(x => x.StudentId == request.StudentId && x.KursId == request.KursId))
            {
                throw new Exception("Student je prijavljen na ovaj kurs.");
            }

            entity.StudentId = request.StudentId;
            entity.KursId = request.KursId;
            entity.StanjeUpisa = request.StanjeUpisa.ToString();

            var kurs = await context.Kurs.FindAsync(request.KursId);
            if (kurs != null)
            {
                kurs.BrojUpisanih++;
            }

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(UpisUpdateRequest request, Upis entity)
        {
            entity.StanjeUpisa = request.StanjeUpisa.ToString();

            await base.BeforeUpdate(request, entity);
        }

        public override async Task Delete(int id)
        {
            var entity = await context.Upisi.Include(x => x.Kurs).FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentException("ID nije pronađen", nameof(id));

            if (entity.Kurs != null && entity.Kurs.BrojUpisanih > 0)
            {
                entity.Kurs.BrojUpisanih--;
            }

            context.Upisi.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
