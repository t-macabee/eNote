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
        public string Grad {  get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; } 

        public ICollection<Korisnik> Korisnici { get; set; } = [];
        public ICollection<MusicShop> MusicShops { get; set; } = [];
    }
}
