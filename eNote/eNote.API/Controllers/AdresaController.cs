using eNote.Model.Requests.Adresa;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class AdresaController(IAdresaService adresaService) : CRUDController<Model.DTOs.Adresa, AdresaSearchObject, AdresaInsertRequest, AdresaInsertRequest>(adresaService)
    {        
    }
}
