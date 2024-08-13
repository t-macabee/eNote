using eNote.Model.Enums;

namespace eNote.Services.Database
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;
        public Uloge Uloga { get; set; }
        public bool Status { get; set; } 

        public int AdresaId { get; set; }
        public Adresa Adresa { get; set; }
       
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty; 
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb { get; set; }        

        public ICollection<Kurs>? Kurs { get; set; } // Instruktor
        public ICollection<OglasnaTabla>? PostavljeneObavijesti { get; set; } // Instruktor
        public ICollection<Upis>? Upis { get; set; } // Učenik
        public ICollection<IznajmljivanjeInstrumenta>? IznajmljivanjeInstrumenta { get; set; } // Učenik
        public ICollection<PredajaZadatka>? PredajaZadatka { get; set; } // Učenik
        public ICollection<Prisustvo>? Prisustvo { get; set; } // Učenik

    }
}