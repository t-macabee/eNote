using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class Prisustvo
    {
        public int Id { get; set; }
        public bool PotvrdaPrisustva { get; set; }

        public int StudentId { get; set; }
        public Korisnik Student { get; set; }

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; }
    }
}
