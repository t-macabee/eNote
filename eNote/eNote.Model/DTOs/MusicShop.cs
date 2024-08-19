using eNote.Model.Enums;

namespace eNote.Model.DTOs
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } 
        public string Status { get; set; }
        public string Naziv { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Adresa Adresa { get; set; }
        public Uloge Uloga { get; set; }
    }
}
