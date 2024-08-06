using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.DTOs
{
    public class BaseKorisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public Adresa Adresa { get; set; } = null!;
        public Uloge Uloga { get; set; } = null!;
    }
}
