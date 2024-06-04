using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace eNote.Model.Models
{
    public class Uloge
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Korisnik> Korisnici {  get; set; } 
    }
}
