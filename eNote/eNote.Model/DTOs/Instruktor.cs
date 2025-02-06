using System.Collections.Generic;

namespace eNote.Model.DTOs
{
    public class Instruktor
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public bool Status { get; set; }
        public string Email { get; set; } = null!;
        public string BrojTelefona { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public byte[]? Slika { get; set; }

        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string DatumRodjenja { get; set; } = null!;

        public ICollection<Kurs> Kurs { get; set; } = new List<Kurs>();
    }
}
