﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Kurs
{
    public class KursUpdateRequest
    {
        public string Naziv { get; set; } 
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public int BrojPolaznika { get; set; }
        public decimal Cijena { get; set; }
    }
}
