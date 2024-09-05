using eNote.Model.Requests.Adresa;
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
    public class AdresaService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.Adresa, AdresaSearchObject, AdresaUpsertRequest, AdresaUpsertRequest, Database.Adresa>(context, mapper), IAdresaService
    {
    }
}
