using eNote.Model.DTOs;
using eNote.Model.Enums;
using eNote.Model.Requests.Base;

namespace eNote.Model.Requests.MusicShop
{
    public class MusicShopInsertRequest : BaseMembersInsertRequest
    {
        public string Naziv {  get; set; } = string.Empty;
    }
}
