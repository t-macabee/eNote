using eNote.Model.DTOs;
using eNote.Model.Enums;

namespace eNote.Model
{
    public class Korisnik 
    {
        public int Id { get; set; }        
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;        
        public string DatumRodjenja { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public Adresa Adresa { get; set; } 
        public Uloge Uloga { get; set; }
    }
}
