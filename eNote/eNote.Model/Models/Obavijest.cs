using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class Obavijest
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumPostavljanja { get; set; }

        public int PredavanjeId { get; set; } 
        public Predavanje Predavanje { get; set; }
    }
}
