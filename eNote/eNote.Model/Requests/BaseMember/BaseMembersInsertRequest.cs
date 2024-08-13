using eNote.Model.DTOs;
using eNote.Model.Enums;


namespace eNote.Model.Requests.Base
{
    public class BaseMembersInsertRequest
    {
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Lozinka { get; set; } = string.Empty;
        public string LozinkaPotvrda { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? AdresaId { get; set; }
        public Adresa Adresa { get; set; }
        public bool Status { get; set; }
    }
}
