using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Database
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; } 
        public string LozinkaSalt { get; set; }         

        public bool Status { get; set; }

        public int UlogaId { get; set; }
        public Uloge Uloga { get; set; }

        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }

        public string Naziv { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; } 
        public string RadnoVrijeme { get; set; }
        public byte[]? Slika { get; set; }

        public ICollection<Instrumenti> Instrumenti { get; set; } = new List<Instrumenti>();
    }
}
