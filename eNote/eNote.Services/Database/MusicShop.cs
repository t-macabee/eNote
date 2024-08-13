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
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public Uloge Uloga { get; set; }
        public bool Status { get; set; }

        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }

        public string Naziv { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb { get; set; }

        public ICollection<Instrumenti>? Instrumenti { get; set; }
    }
}
