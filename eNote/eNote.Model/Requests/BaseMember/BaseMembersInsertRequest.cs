using eNote.Model.DTOs;

namespace eNote.Model.Requests.BaseMember
{
    public class BaseMembersInsertRequest
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string LozinkaPotvrda { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? AdresaId { get; set; }
        public bool Status { get; set; }
    }
}
