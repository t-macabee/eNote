using eNote.Model;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;

namespace eNote.Services.Services
{
    public class KorisniciService : CRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest, Database.Korisnik>, IKorisniciService
    {       
        public KorisniciService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {            
        }

        public override IQueryable<Database.Korisnik> AddFilter(KorisnikSearchObject search, IQueryable<Database.Korisnik> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(new List<Func<IQueryable<Database.Korisnik>, IQueryable<Database.Korisnik>>>
            {
                x => !string.IsNullOrWhiteSpace(search?.Ime) ? x.Where(k => k.Ime.StartsWith(search.Ime)) : x,
                x => !string.IsNullOrWhiteSpace(search?.Prezime) ? x.Where(k => k.Prezime.StartsWith(search.Prezime)) : x,
                x => !string.IsNullOrWhiteSpace(search?.KorisnickoIme) ? x.Where(k => k.KorisnickoIme.StartsWith(search.KorisnickoIme)) : x,
                x => !string.IsNullOrWhiteSpace(search?.Grad) ? x.Include(k => k.Adresa).Where(k => k.Adresa.Grad.StartsWith(search.Grad)) : x
            });

            int count = query.Count();

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            query = QueryBuilder.ApplyChaining(query);

            return query;
        }

        public override Model.Korisnik GetById(int id)
        {
            var entity = QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefault(x => x.Id == id);

            return entity != null ? mapper.Map<Model.Korisnik>(entity) : null;
        }

        public override Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            base.Insert(request);

            var entity = QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefault(x => x.KorisnickoIme == request.KorisnickoIme);

            return mapper.Map<Model.Korisnik>(entity);
        }

        public override Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            base.Update(id, request);

            var entity = QueryBuilder.ApplyChaining(context.Korisnici).FirstOrDefault(x => x.Ime == request.Ime);

            return mapper.Map<Model.Korisnik>(entity);
        }

        public Model.Korisnik Login(string korisnickoIme, string lozinka)
        {
            var entity = context.Korisnici.FirstOrDefault(x => x.KorisnickoIme == korisnickoIme);

            if (entity == null)
            {
                return null;
            }

            var hash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, lozinka);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return mapper.Map<Model.Korisnik>(entity);
        }

        public override void BeforeInsert(KorisnikInsertRequest request, Database.Korisnik entity)
        {            
            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }

            entity.UlogaId = request.UlogaId;            

            entity.LozinkaSalt = PasswordBuilder.GenerateSalt();

            entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);

            base.BeforeInsert(request, entity);
        }

        public override void BeforeUpdate(KorisnikUpdateRequest request, Database.Korisnik entity)
        {
            if (request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i lozinka potvrda moraju biti iste!");
                }
                entity.LozinkaSalt = PasswordBuilder.GenerateSalt();
                entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            base.BeforeUpdate(request, entity);
        }
    }
}
