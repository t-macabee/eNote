using eNote.Model.Requests.Base;

namespace eNote.Model.Requests.MusicShop
{
    public class MusicShopUpdateRequest : BaseKorisnikUpdateRequest
    {
        public string? Naziv {  get; set; }
        public string? Opis {  get; set; }
        public string? RadnoVrijeme {  get; set; }
    }
}
