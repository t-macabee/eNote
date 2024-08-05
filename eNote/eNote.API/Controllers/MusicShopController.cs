using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;


namespace eNote.API.Controllers
{
    public class MusicShopController(IMusicShopService service) : CRUDController<Model.MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest>(service)
    {       
    }
}
