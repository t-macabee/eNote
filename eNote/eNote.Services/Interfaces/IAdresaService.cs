using eNote.Model.DTOs;
using eNote.Model.Requests.Adresa;
using eNote.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface IAdresaService : ICRUDService<Model.DTOs.Adresa, AdresaSearchObject, AdresaUpsertRequest, AdresaUpsertRequest>
    {
    }
}
