using eNote.Model.DTOs;

namespace eNote.Model
{
    public class Korisnik : IKorisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = string.Empty;        
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string DatumRodjenja { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public Adresa Adresa { get; set; } = null!;
        public Uloge Uloga { get; set; } = null!;
    }
}
