using eNote.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model
{
    public class Korisnik : BaseKorisnik
    {
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string DatumRodjenja { get; set; } = string.Empty;
    }
}
