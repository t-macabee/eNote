using eNote.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model
{
    public class Korisnik
    {
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string DatumRodjenja { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Adresa { get; set; }
        public string KorisnickoIme { get; set; } = string.Empty;
        public Uloge Uloga { get; set; } = null!;
    }
}
