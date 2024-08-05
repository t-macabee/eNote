using eNote.Model.DTOs;

namespace eNote.Model
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string KorisnickoIme { get; set; } = string.Empty;
        public Uloge Uloga { get; set; } = null!;
    }
}
