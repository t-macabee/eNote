using eNote.Model.Pagination;
using eNote.Model.Requests.Korisnik;
using eNote.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface IKorisniciService : ICRUDService<Model.Korisnik, KorisnikSearchObject, KorisnikInsertRequest, KorisnikUpdateRequest>
    {

    }
}
