﻿using eNote.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.SearchObjects
{
    public class InstrumentSearchObject : BaseSearchObject
    {
        public string? Model { get; set; }
        public string? Proizvodjac { get; set; }
        public string? VrstaInstrumenta {  get; set; }
        public bool? Dostupan {  get; set; }
    }
}
