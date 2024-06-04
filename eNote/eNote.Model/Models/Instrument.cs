using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Vrsta { get; set; }
        public string Opis{ get; set; }        

        public int MusicShopId { get; set; }
        public MusicShop MusicShop { get; set; }

        public ICollection<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenta { get; set; }

    }
}
