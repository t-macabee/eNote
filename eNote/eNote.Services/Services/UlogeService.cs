using eNote.Model.DTOs;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Services
{
    public class UlogeService(ENoteContext context, IMapper mapper) : BaseService<Model.DTOs.Uloge, UlogeSearchObject, Database.Uloge>(context, mapper), IUlogeService
    {

        public override IQueryable<Database.Uloge> AddFilter(UlogeSearchObject search, IQueryable<Database.Uloge> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            return query;
        }
    }
}
