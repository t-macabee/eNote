using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.DTOs
{
    public class Obavijest
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumVrijemePostavljanja { get; set; }
    }
}
