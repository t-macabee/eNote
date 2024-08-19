using eNote.Model.DTOs;
using eNote.Model.Enums;

namespace eNote.Model
{
    public class Korisnik 
    {
        public int Id { get; set; }        
        public string KorisnickoIme { get; set; }
        public string Status { get; set; }
        public string Ime { get; set; } 
        public string Prezime { get; set; }      
        public string DatumRodjenja { get; set; } 
        public string Email { get; set; }
        public string Telefon { get; set; } 
        public Adresa Adresa { get; set; } 
        public Uloge Uloga { get; set; }
    }
}
