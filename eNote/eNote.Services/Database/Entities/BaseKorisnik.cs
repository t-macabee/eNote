using eNote.Model.Enums;
using System.Text.Json.Serialization;

namespace eNote.Services.Database.Entities
{
    public abstract class BaseKorisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public bool Status { get; set; }
        public string Email { get; set; } = null!;
        public string BrojTelefona { get; set; } = null!;
        public byte[]? Slika { get; set; }
        public KorisnikUloga Uloga { get; set; }

        public int AdresaId { get; set; }
        [JsonIgnore]
        public Adresa Adresa { get; set; } = null!;
    }
}
