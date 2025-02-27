﻿using eNote.Model.Requests.Kurs;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Database.Entities;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class KursService(ENoteContext context, IMapper mapper): CRUDService<Model.DTOs.Kurs, KursSearchObject, KursInsertRequest, KursUpdateRequest, Kurs>(context, mapper), IKursService
    {
        public override IQueryable<Kurs> AddFilter(KursSearchObject search, IQueryable<Kurs> query)
        {
            query = base.AddFilter(search, query).Include(x => x.Instruktor);

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search.InstruktorId.HasValue)
            {
                query = query.Where(x => x.InstruktorId == search.InstruktorId.Value);
            }

            return query;
        }

        public override async Task<Model.DTOs.Kurs> GetById(int id)
        {
            var entity = await context.Kurs.Include(x => x.Instruktor).FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Kurs nije pronađen");

            return mapper.Map<Model.DTOs.Kurs>(entity);
        }        

        public override async Task BeforeInsert(KursInsertRequest request, Kurs entity)
        {          
            var existing = await context.Kurs.FirstOrDefaultAsync(x => x.Naziv == request.Naziv);

            if (existing != null)
            {
                throw new Exception("Kurs pod tim imenom već postoji. Molimo odaberite drugo ime za kurs.");
            }

            var instruktor = await context.Instruktor.FirstOrDefaultAsync(x => x.Id == request.InstruktorId) ?? throw new Exception("Odabrani korisnik nije Instruktor");

            if (request.DatumPocetka < DateTime.Today)
                throw new ArgumentException("Početni datum ne može biti manji od trenutnog datuma.");

            if (request.DatumZavrsetka < request.DatumPocetka)
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

            if (request.DatumPocetka < DateTime.Today)
                throw new ArgumentException("Početni datum ne može biti manji od trenutnog datuma.");

            if (request.DatumZavrsetka < request.DatumPocetka)
                throw new ArgumentException("Datum završetka ne može biti manji od početnog datuma.");            

            await base.BeforeUpdate(request, entity);
        }
    }
}
