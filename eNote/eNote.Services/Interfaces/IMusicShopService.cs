using eNote.Model.Pagination;
using eNote.Model.Requests.Korisnik;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Database;

namespace eNote.Services.Interfaces
{
    public interface IMusicShopService : ICRUDService<Model.MusicShop, MusicShopSearchObject, MusicShopUpsertRequest, MusicShopUpsertRequest>
    {       
    }
}
