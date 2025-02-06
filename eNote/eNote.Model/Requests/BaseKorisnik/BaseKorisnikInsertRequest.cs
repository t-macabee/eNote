using eNote.Model.Enums;
using eNote.Model.Requests.Adresa;

namespace eNote.Model.Requests.BaseMember
{
    public class BaseKorisnikInsertRequest
    {
        public string KorisnickoIme { get; set; } = null!;
        public string Lozinka { get; set; } = null!;
        public string LozinkaPotvrda { get; set; } = null!;
        public bool Status { get; set; }
        public string Email { get; set; } = null!;
        public string BrojTelefona { get; set; } = null!;
        public byte[]? Slika { get; set; }
        public KorisnikUloga Uloga { get; set; }

        public int? AdresaId { get; set; }        
        public AdresaInsertRequest? Adresa {  get; set; }
    }
}
 