using eNote.Model.Requests.BaseMember;
using System;

namespace eNote.Model.Requests.Polaznik
{
    public class PolaznikInsertRequest : BaseKorisnikInsertRequest
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }
    }
}
