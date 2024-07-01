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
    public interface IKorisniciService
    {
        PagedResult<Model.Korisnik> GetAll(KorisnikSearchObject searchObject);
        Model.Korisnik GetById(int id);
        Model.Korisnik Insert(KorisnikInsertRequest request);
        Model.Korisnik Update(int id, KorisnikUpdateRequest request);
    }
}
