﻿using eNote.Model.Enums;
using eNote.Model.Requests.Predavanje;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Database.Entities;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class PredavanjeService(ENoteContext context, IMapper mapper) 
        : CRUDService<Model.DTOs.Predavanje, PredavanjeSearchObject, PredavanjeInsertRequest, PredavanjeUpdateRequest, Predavanje>(context, mapper), IPredavanjeService
    {
        public override IQueryable<Predavanje> AddFilter(PredavanjeSearchObject search, IQueryable<Predavanje> query)
        {
            query = base.AddFilter(search, query).Include(x => x.Kurs).ThenInclude(x => x.Instruktor);

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search.KursId.HasValue)
            {
                query = query.Where(x => x.KursId == search.KursId.Value);
            }


            return query;
        }

        public override async Task<Model.DTOs.Predavanje> GetById(int id)
        {
            var entity = await context.Predavanje.Include(x => x.Kurs).ThenInclude(x => x.Instruktor).FirstOrDefaultAsync(p => p.Id == id);

            if(entity == null)
            {
                return null;
            }

            return mapper.Map<Model.DTOs.Predavanje>(entity);                       
        }

        public override async Task BeforeInsert(PredavanjeInsertRequest request, Predavanje entity)
        {
            var existingPredavanje = await context.Predavanje.Include(x => x.Kurs).ThenInclude(x => x.Instruktor)
                .FirstOrDefaultAsync(x => x.Naziv == request.Naziv && x.KursId == request.KursId);

            if (existingPredavanje != null)
            {
                throw new Exception("Predavanje s tim nazivom već postoji u ovom kursu. Molimo odaberite drugo ime za predavanje.");
            }

            var kurs = await context.Kurs.FindAsync(request.KursId);

            if (kurs == null)
            {
                throw new ArgumentException("Odabrani kurs ne postoji.");
            }

            if (request.DatumVrijemePredavanja < kurs.DatumPocetka || request.DatumVrijemePredavanja > kurs.DatumZavrsetka)
            {
                throw new ArgumentException("Datum i vrijeme predavanja moraju biti unutar trajanja kursa.");
            }

            if (request.TrajanjeMinute <= 0)
            {
                throw new ArgumentException("Trajanje predavanja mora biti pozitivno.");
            }

            entity.TrajanjeMinute = request.TrajanjeMinute;

            entity.PredavanjeStatus = PredavanjeStatus.Zakazano;

            await base.BeforeInsert(request, entity);
        }

        public override async Task BeforeUpdate(PredavanjeUpdateRequest request, Predavanje entity)
        {
            entity = await context.Predavanje.Include(x => x.Kurs).ThenInclude(x => x.Instruktor).FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entity == null)
            {
                throw new Exception("Predavanje ne postoji.");
            }

            await base.BeforeUpdate(request, entity);
        }
    }
}
