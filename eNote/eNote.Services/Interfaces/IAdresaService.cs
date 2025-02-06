using eNote.Model.DTOs;
using eNote.Model.Requests.Adresa;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IAdresaService : ICRUDService<Adresa, AdresaSearchObject, AdresaInsertRequest, AdresaInsertRequest>
    {
    }
}
