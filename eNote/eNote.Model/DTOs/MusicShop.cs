using System.Collections.Generic;

namespace eNote.Model.DTOs
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public bool Status { get; set; }
        public string Email { get; set; } = null!;
        public string BrojTelefona { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public byte[]? Slika { get; set; }

        public string Naziv { get; set; } = null!;
        public string RadnoVrijeme { get; set; } = null!;

        public ICollection<Instrumenti> Instrumenti { get; set; } = new List<Instrumenti>();
    }
}
