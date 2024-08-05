using System;
using System.Collections.Generic;
using System.Text;

namespace eNote.Model.Requests.Kurs
{
    public class KursInsertRequest
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
    }
}
