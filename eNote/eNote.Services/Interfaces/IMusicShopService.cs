using eNote.Model.DTOs;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;

namespace eNote.Services.Interfaces
{
    public interface IMusicShopService : ICRUDService<MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest>
    {
        Task<List<Instrumenti>> GetInstumentiByShop(int id);
    }
}
