using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; } 
        public string Prezime { get; set; } 
        public string? Email { get; set; }
        public string? Telefon { get; set; }

        public string KorisnickoIme { get; set; }  
        public string Uloga { get; set; }
    }
}
