using eNote.Model.Requests.Adresa;

namespace eNote.Model.Requests.Base
{
    public class BaseKorisnikUpdateRequest
    {
        public string? Lozinka { get; set; }
        public string? LozinkaPotvrda { get; set; }
        public bool? Status { get; set; }
        public string? Email { get; set; }
        public string? BrojTelefona { get; set; }
        public byte[]? Slika { get; set; }
        public int? AdresaId { get; set; }
        public AdresaInsertRequest? Adresa { get; set; }
    }
}
