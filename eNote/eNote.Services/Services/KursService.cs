using eNote.Model.Enums;
using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class KursService(ENoteContext context, IMapper mapper): CRUDService<Model.DTOs.Kurs, KursSearchObject, KursInsertRequest, KursUpdateRequest, Kurs>(context, mapper), IKursService
    {
        public override IQueryable<Kurs> AddFilter(KursSearchObject search, IQueryable<Kurs> query)
        {
            query = base.AddFilter(search, query).Include(x => x.Instruktor)
                .Where(x =>
                    (string.IsNullOrEmpty(search.Naziv) || x.Naziv.StartsWith(search.Naziv)) &&
                    (!search.NivoTezine.HasValue || x.NivoTezine == search.NivoTezine.Value)
                );

            return query;
        }

        public override async Task<Model.DTOs.Kurs> GetById(int id)
        {
            var entity = await context.Kurs.Include(x => x.Instruktor).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Kurs nije pronađen");

            return mapper.Map<Model.DTOs.Kurs>(entity);
        }        

        public override async Task BeforeInsert(KursInsertRequest request, Kurs entity)
        {          
            var existingCourse = await context.Kurs.FirstOrDefaultAsync(x => x.Naziv == request.Naziv);

            if (existingCourse != null)
            {
                throw new Exception("Kurs pod tim imenom već postoji. Molimo odaberite drugo ime za kurs.");
            }

            var instruktor = await context.Korisnici
                .FirstOrDefaultAsync(x => x.Id == request.InstruktorId && x.Uloga == Uloge.Instruktor) ?? throw new Exception("Odabrani korisnik nije Instruktor");

            if (request.DatumPocetka.Date < DateTime.Today)
                throw new ArgumentException("Početni datum ne može biti manji od trenutnog datuma.");

            if (request.DatumZavrsetka.Date < request.DatumPocetka.Date)
                throw new ArgumentException("Datum završetka ne može biti manji od početnog datuma.");

            entity.InstruktorId = request.InstruktorId;

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(KursUpdateRequest request, Kurs entity)
        {
            entity = await context.Kurs.Include(x => x.Instruktor).FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entity == null)
            {
                throw new Exception("Kurs ne postoji.");
            }

            if (request.DatumPocetka.HasValue && request.DatumPocetka.Value < DateTime.Today)
                throw new ArgumentException("Početni datum ne može biti manji od trenutnog datuma.");

            if (request.DatumZavrsetka.HasValue && request.DatumPocetka.HasValue && request.DatumZavrsetka.Value < request.DatumPocetka.Value)
                throw new ArgumentException("Datum završetka ne može biti manji od početnog datuma.");            

            await base.BeforeUpdate(request, entity);
        }
    }
}
