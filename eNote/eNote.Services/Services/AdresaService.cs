using eNote.Model.DTOs;
using eNote.Model.Requests.Adresa;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class AdresaService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.Adresa, AdresaSearchObject, AdresaUpsertRequest, AdresaUpsertRequest, Database.Adresa>(context, mapper), IAdresaService
    {      
      
    }
}
