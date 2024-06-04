using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }

        public int UlogaId { get; set; }
        public Uloge Uloga { get; set; }

        public ICollection<Kurs>? Kurs { get; set; } //Instruktori
        public ICollection<Upis>? Upis { get; set; } //Studenti
        public ICollection<IznajmljivanjeInstrumenta>? IznajmljivanjeInstrumenta { get; set; } //Studenti
        public ICollection<PredajaZadatka>? PredajaZadatka { get; set; } //Studenti
        public ICollection<Prisustvo>? Prisustvo { get; set; } //Studenti
        public ICollection<OglasnaTabla>? PostavljeneObavijesti { get; set; }
    }
}
