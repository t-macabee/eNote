using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Services
{
    public class TipPredavanjaService(ENoteContext context, IMapper mapper) : BaseService<Model.DTOs.TipPredavanja, TipPredavanjaSearchObject, TipPredavanja>(context, mapper), ITipPredavanjaService
    {
        public override IQueryable<TipPredavanja> AddFilter(TipPredavanjaSearchObject search, IQueryable<TipPredavanja> query)
        {
            if (!string.IsNullOrEmpty(search.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            return query;
        }
    }
}
