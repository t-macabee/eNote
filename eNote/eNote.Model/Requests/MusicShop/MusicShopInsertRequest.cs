using eNote.Model.Requests.BaseMember;

namespace eNote.Model.Requests.MusicShop
{
    public class MusicShopInsertRequest : BaseKorisnikInsertRequest
    {
        public string Naziv { get; set; } = null!;
        public string Opis { get; set; } = string.Empty;
        public string RadnoVrijeme { get; set; } = null!;
    }
}
