using eNote.Model.Requests.BaseMember;
using System;

namespace eNote.Model.Requests.Instruktor
{
    public class InstruktorInsertRequest : BaseKorisnikInsertRequest
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }
    }
}
