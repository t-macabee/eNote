using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using eNote.Services.Interfaces;

namespace eNote.API.Controllers
{
    public class MusicShopController : CRUDController<Model.MusicShop, MusicShopSearchObject, MusicShopUpsertRequest, MusicShopUpsertRequest>
    {
        public MusicShopController(IMusicShopService service) : base(service)
        {
        }
    }
}
