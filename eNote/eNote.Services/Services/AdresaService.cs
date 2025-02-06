using eNote.Model.Requests.Adresa;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using MapsterMapper;

namespace eNote.Services.Services
{
    public class AdresaService(ENoteContext context, IMapper mapper) : CRUDService<Model.DTOs.Adresa, AdresaSearchObject, AdresaInsertRequest, AdresaInsertRequest, Database.Entities.Adresa>(context, mapper), IAdresaService
    {            
    }
}
