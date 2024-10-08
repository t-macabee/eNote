﻿using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.DTOs
{
    public class Predavanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }
        public string DatumVrijemePredavanja { get; set; }
        public int TrajanjeMinute { get; set; }        
        public string Kurs { get; set; }
        public string TipPredavanja { get; set; }
        public string StanjePredavanja { get; set; }
    }
}
