using eNote.Model.Enums;

namespace eNote.Services.Database
{
    public class Korisnik
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
       
        public string Ime { get; set; } 
        public string Prezime { get; set; } 
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; } 
        public byte[]? Slika { get; set; }
        public byte[]? SlikaThumb { get; set; }        

        // Instruktor
        public ICollection<Kurs> Kurs { get; set; } = new List<Kurs>();

        // Učenik
        public ICollection<Upis> Upis { get; set; } = new List<Upis>();
        public ICollection<Prisustvo> Prisustvo { get; set; } = new List<Prisustvo>();
        public ICollection<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenta { get; set; } = new List<IznajmljivanjeInstrumenta>();
        public ICollection<PredajaZadatka> PredajaZadatka { get; set; } = new List<PredajaZadatka>(); 
    }
}