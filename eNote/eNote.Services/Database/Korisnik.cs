﻿namespace eNote.Services.Database
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }

        public string KorisnickoIme { get; set; } = null!;
        public string LozinkaHash { get; set; } = null!;
        public string LozinkaSalt { get; set; } = null!;

        public int UlogaId { get; set; }
        public Uloge Uloga { get; set; } = null!;

        public ICollection<Kurs>? Kurs { get; set; } // Instruktori
        public ICollection<Upis>? Upis { get; set; } // Studenti
        public ICollection<IznajmljivanjeInstrumenta>? IznajmljivanjeInstrumenta { get; set; } // Studenti
        public ICollection<PredajaZadatka>? PredajaZadatka { get; set; } // Studenti
        public ICollection<Prisustvo>? Prisustvo { get; set; } // Studenti
        public ICollection<OglasnaTabla>? PostavljeneObavijesti { get; set; } // Instruktori

    }
}