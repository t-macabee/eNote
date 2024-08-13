using eNote.Model.Requests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.MusicShop
{
    public class MusicShopUpdateRequest : BaseMembersUpdateRequest
    {
        public string Naziv {  get; set; }
    }
}
