using eNote.Model.Requests.Obavijest;
using eNote.Model.Requests.Obavijesti;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Database.Entities;
using eNote.Services.Interfaces;
using MapsterMapper;


namespace eNote.Services.Services
{
    public class NapomenaService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.Napomena, NapomenaSearchObject, NapomenaInsertRequest, NapomenaUpdateRequest, Napomena>(context, mapper), INapomenaService
    {
        public override IQueryable<Napomena> AddFilter(NapomenaSearchObject search, IQueryable<Napomena> query)
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
