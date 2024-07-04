using eNote.Model.Requests.MusicShop;
using eNote.Model.Requests.VrstaInstrumenta;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Services
{
    public class VrstaInstrumentaService : CRUDService<Model.VrstaInstrumenta, VrstaInstrumentaSearchObject, VrstaInstrumentaUpsertRequest, VrstaInstrumentaUpsertRequest, Database.VrstaInstrumenta>, IVrstaInstrumentaService
    {
        public VrstaInstrumentaService(eNoteContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<VrstaInstrumenta> AddFilter(VrstaInstrumentaSearchObject search, IQueryable<VrstaInstrumenta> query)
        {
            query = base.AddFilter(search, query);

            query = query.ApplyFilters(new List<Func<IQueryable<VrstaInstrumenta>, IQueryable<VrstaInstrumenta>>>
            {
                x => !string.IsNullOrWhiteSpace(search?.Naziv) ? x.Where(k => k.Naziv.StartsWith(search.Naziv)) : x,                
            });

            query = QueryBuilder.ApplyPaging(query, search?.Page, search?.PageSize);

            return query;
        }
    }       
}
