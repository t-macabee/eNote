﻿using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class MusicShopService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest, Database.MusicShop>(context, mapper), IMusicShopService
    {
        public override IQueryable<MusicShop> AddFilter(MusicShopSearchObject search, IQueryable<MusicShop> query)
        {
            query = base.AddFilter(search, query).Include(x => x.Uloga).Include(x => x.Adresa);

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (!string.IsNullOrEmpty(search.Grad))
            {
                query = query.Where(x => x.Adresa.Grad.Contains(search.Grad));
            }

            return query;
        }

        public override async Task<Model.DTOs.MusicShop> GetById(int id)
        {
            var entity = await context.MusicShops.Include(x => x.Uloga).Include(x => x.Adresa).FirstOrDefaultAsync(x => x.Id == id);

            return entity == null ? null : mapper.Map<Model.DTOs.MusicShop>(entity);
        }

        public override async Task BeforeInsert(MusicShopInsertRequest request, MusicShop entity)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Unos ne može biti null.");
            }

            var existingUsername = await context.MusicShops.FirstOrDefaultAsync(x => x.KorisnickoIme == request.KorisnickoIme);
            if (existingUsername != null)
            {
                throw new Exception("Korisničko ime je u upotrebi.");
            }

            var existingEmail = await context.MusicShops.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (existingEmail != null)
            {
                throw new Exception("E-mail je u upotrebi.");
            }

            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i LozinkaPotvrda moraju biti iste!");
            }

            entity.UlogaId = 4;

            var adresa = await context.Adresa.FindAsync(request.AdresaId);

            if (adresa == null)
            {
                throw new Exception("Uloga ne postoji!");
            }

            entity.AdresaId = adresa.Id;

            entity.LozinkaSalt = PasswordBuilder.GenerateSalt();
            entity.LozinkaHash = PasswordBuilder.GenerateHash(entity.LozinkaSalt, request.Lozinka);

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(MusicShopUpdateRequest request, MusicShop entity)
        {
            entity = await context.MusicShops.Include(x => x.Uloga).Include(x => x.Adresa).FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entity == null)
            {
                throw new Exception("Korisnik not found.");
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

        public async Task<List<Model.DTOs.Instrumenti>> GetInstumentiByShop(int id)
        {
            var entity = await context.MusicShops.Where(x => x.Id == id).SelectMany(x => x.Instrumenti).Include(x => x.MusicShop).Include(x => x.VrstaInstrumenta).ToListAsync();
            return mapper.Map<List<Model.DTOs.Instrumenti>>(entity);
        }
    }
}
