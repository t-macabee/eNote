using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace eNote.Services.Services
{
    public class InstrumentService : BaseService<Model.Instrumenti, InstrumentSearchObject, Database.Instrumenti>, IInstrumentService
    {
        public InstrumentService(eNoteContext context, IMapper mapper) : base(context, mapper) { }

        public override IQueryable<Instrumenti> AddFilter(InstrumentSearchObject search, IQueryable<Instrumenti> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if(!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x => x.Model.Contains(search.FTS) || x.Proizvodjac.Contains(search.FTS));
            }

            return filteredQuery;
        }
    }
}
