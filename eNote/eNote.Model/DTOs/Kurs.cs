using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.DTOs
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public string InstruktorIme { get; set; } = string.Empty;
    }
}
