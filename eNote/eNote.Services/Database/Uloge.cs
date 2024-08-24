using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Database
{
    public class Uloge
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Korisnik> Korisnik { get; set; } = new List<Korisnik>(); 
        public ICollection<MusicShop> MusicShop { get; set; } = new List<MusicShop>();
    }
}
