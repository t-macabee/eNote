using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Database
{
    public class Adresa
    {
        public int Id { get; set; }
        public string Grad {  get; set; } = string.Empty;
        public string Ulica { get; set; } = string.Empty;
        public string Broj { get; set; } = string.Empty;

        public ICollection<Korisnik> Korisnici { get; set; } = new List<Korisnik>();
    }
}
