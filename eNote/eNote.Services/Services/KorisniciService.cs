using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class KorisniciService : CRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest, Database.Korisnik>, IKorisniciService
    {
        public KorisniciService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {
        }        

        public override IQueryable<Korisnik> AddFilter(KorisnikSearchObject search, IQueryable<Korisnik> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.ImeGTE))
            {
                query = query.Where(x => x.Ime.StartsWith(search.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(search?.PrezimeGTE))
            {
                query = query.Where(x => x.Prezime.StartsWith(search.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == search.KorisnickoIme);
            }

            if (!string.IsNullOrWhiteSpace(search?.Grad))
            {
                query = query.Where(x => x.Adresa.Grad.StartsWith(search.Grad));
            }

            int count = query.Count();

            if (search?.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value)
                    .Take(search.PageSize.Value);
            }

            query = query.Include(x => x.Uloga).Include(x => x.Adresa);

            return query;
        }

        public override Model.Korisnik GetById(int id)
        {
            var entity = context.Set<Korisnik>().Include(x => x.Uloga).Include(x => x.Adresa).FirstOrDefault(x => x.Id == id);

            if (entity != null)
            {
                return mapper.Map<Model.Korisnik>(entity);
            }
            else
            {
                return null;
            }
        }
        
        public override Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            base.Insert(request);

            var entity = context.Set<Korisnik>().Include(x => x.Uloga).Include(x => x.Adresa).FirstOrDefault(x => x.KorisnickoIme == request.KorisnickoIme);

            return mapper.Map<Model.Korisnik>(entity);
        }

        public override Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            base.Update(id, request);

            var entity = context.Set<Korisnik>().Include(x => x.Uloga).Include(x => x.Adresa).FirstOrDefault(x => x.Ime == request.Ime);

            return mapper.Map<Model.Korisnik>(entity);
        }

        public override void BeforeInsert(KorisnikInsertRequest request, Korisnik entity)
        {
            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }

            entity.UlogaId = request.UlogaId;            

            entity.LozinkaSalt = PasswordUtils.GenerateSalt();

            entity.LozinkaHash = PasswordUtils.GenerateHash(entity.LozinkaSalt, request.Lozinka);

            base.BeforeInsert(request, entity);
        }

        public override void BeforeUpdate(KorisnikUpdateRequest request, Korisnik entity)
        {
            if (request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i lozinka potvrda moraju biti iste!");
                }
                entity.LozinkaSalt = PasswordUtils.GenerateSalt();
                entity.LozinkaHash = PasswordUtils.GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            base.BeforeUpdate(request, entity);
        }                
    }
}
