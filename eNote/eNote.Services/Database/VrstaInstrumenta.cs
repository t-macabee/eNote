using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Database
{
    public class VrstaInstrumenta
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Instrumenti> Instrumenti { get; set; } = new List<Instrumenti>();
    }
}
