using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class Zadatak
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime RokPredaje { get; set; }

        public int PredavanjeId { get; set; }
        public Predavanje Predavanje { get; set; }

        public ICollection<PredajaZadatka>? PredajaZadatka { get; set; }
    }
}
