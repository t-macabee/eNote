using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class MusicShop
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }

        public ICollection<Instrument>? Instrumenti { get; set; }
    }
}
