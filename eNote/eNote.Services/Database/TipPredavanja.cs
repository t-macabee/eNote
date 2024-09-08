using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Database
{
    public class TipPredavanja
    {
        public int Id {  get; set; }
        public string Naziv {  get; set; }

        public ICollection<Predavanje> Predavanje { get; set; } = new List<Predavanje>();
    }
}
