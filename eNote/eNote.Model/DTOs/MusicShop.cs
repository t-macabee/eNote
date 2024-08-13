using eNote.Model.Enums;

namespace eNote.Model.DTOs
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Naziv { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public Adresa Adresa { get; set; }
        public Uloge Uloga { get; set; }
    }
}
