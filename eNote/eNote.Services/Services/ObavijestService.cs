using eNote.Model.Requests.Obavijest;
using eNote.Model.Requests.Obavijesti;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;


namespace eNote.Services.Services
{
    public class ObavijestService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.Obavijest, ObavijestSearchObject, ObavijestInsertRequest, ObavijestUpdateRequest, Database.Obavijest>(context, mapper), IObavijestService
    {
        public override IQueryable<Obavijest> AddFilter(ObavijestSearchObject search, IQueryable<Obavijest> query)
        {
            query = base.AddFilter(search, query);

            if (search.Od.HasValue)
            {
                query = query.Where(x => x.DatumVrijemePostavljanja >= search.Od.Value);
            }

            if (search.Do.HasValue)
            {
                query = query.Where(x => x.DatumVrijemePostavljanja <= search.Do.Value);
            }

            return query;
        }
    }
}
