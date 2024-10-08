﻿using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace eNote.Services.Services
{
    public class KorisniciService(ENoteContext context, IMapper mapper, IHttpContextAccessor accessor)
        : CRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest, Database.Korisnik>(context, mapper), IKorisniciService
    {

        public override IQueryable<Korisnik> AddFilter(KorisnikSearchObject search, IQueryable<Korisnik> query)
        {
            query = base.AddFilter(search, query)
                .Include(x => x.Adresa)
                .Include(x => x.Uloga);

            if (!string.IsNullOrEmpty(search.ImePrezime))
            {
                query = query.Where(x => x.Ime.Contains(search.ImePrezime) || x.Prezime.Contains(search.ImePrezime));
            }

            if (!string.IsNullOrEmpty(search.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == search.KorisnickoIme);
            }

            if (!string.IsNullOrEmpty(search.Uloga))
            {
                if (int.TryParse(search.Uloga, out int ulogaId))
                {
                    query = query.Where(x => x.Uloga.Id == ulogaId);
                }
            }

            return query;
        }

        public override async Task<Model.Korisnik> GetById(int id)
        {
            var entity = await context.Korisnici.Include(x => x.Uloga).Include(x => x.Adresa).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : mapper.Map<Model.Korisnik>(entity);
        }

        public override async Task BeforeInsert(KorisnikInsertRequest request, Database.Korisnik entity)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Unos ne može biti null.");
            }

            var existingUsername = await context.Korisnici.FirstOrDefaultAsync(x => x.KorisnickoIme == request.KorisnickoIme);

            if (existingUsername != null)
            {
                throw new Exception("Korisničko ime je u upotrebi.");
            }

            var existingEmail = await context.Korisnici.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (existingEmail != null)
            {
                throw new Exception("E-mail je u upotrebi.");
            }

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }

            var uloga = await context.Uloge.FindAsync(request.UlogaId);

            if (uloga == null)
            {
                throw new Exception("Uloga ne postoji!");
            }

            var adresa = await context.Adresa.FindAsync(request.AdresaId);

            if (adresa == null)
            {
                throw new Exception("Uloga ne postoji!");
            }

            entity.UlogaId = uloga.Id;
            entity.AdresaId = adresa.Id;

            entity.LozinkaSalt = PasswordBuilder.GenerateSalt();
            entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(KorisnikUpdateRequest request, Database.Korisnik entity)
        {
            entity = await context.Korisnici.Include(x => x.Uloga).Include(x => x.Adresa).FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entity == null)
            {
                throw new Exception("Korisnik ne postoji.");
            }

            if (request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i lozinka potvrda moraju biti iste!");
                }

                entity.LozinkaSalt = PasswordBuilder.GenerateSalt();
                entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }

            await base.BeforeUpdate(request, entity);
        }

        public async Task<Model.Korisnik> GetCurrentUser()
        {
            var userId = int.Parse(accessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return await GetById(userId);
        }
    }
}
    