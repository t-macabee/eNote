using eNote.Model.Requests.Adresa;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class AdresaController(IAdresaService service) : CRUDController<Model.DTOs.Adresa, AdresaSearchObject, AdresaUpsertRequest, AdresaUpsertRequest>(service)
    {
    }
}
