using eNote.Model;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IMusicShopService : ICRUDService<Model.MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest>
    {
        Task<Model.MusicShop> Login(string username, string password);
    }
}
