using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Models
{
    public class Upis
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Korisnik Studenti { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}
