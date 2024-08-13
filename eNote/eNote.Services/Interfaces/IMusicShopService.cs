using eNote.Model.DTOs;
using eNote.Model.Requests.MusicShop;
using eNote.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Interfaces
{
    public interface IMusicShopService : ICRUDService<MusicShop, MusicShopSearchObject, MusicShopInsertRequest, MusicShopUpdateRequest>
    {
        Task<List<Model.DTOs.Adresa>> GetAddresses();
    }
}
