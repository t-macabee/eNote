using eNote.Model.Pagination;
using eNote.Model.SearchObjects;
using eNote.Services.Database;
using eNote.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eNote.API.Controllers
{
    public class MusicShopController : BaseController<Model.MusicShop, MusicShopSearchObject>
    {
        public MusicShopController(IMusicShopService service) : base(service)
        {
        }
    }
}
