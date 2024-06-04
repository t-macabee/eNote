using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class OglasnaTabla
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumPostavljanja { get; set; }

        public int AutorId { get; set; } 
        public Korisnik Autor { get; set; } 
    }
}
