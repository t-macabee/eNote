using eNote.Model.DTOs;
using eNote.Model.Enums;
using eNote.Model.Requests.BaseMember;
using System;

namespace eNote.Model.Requests.Korisnik
{
    public class KorisnikInsertRequest : BaseMembersInsertRequest
    {
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public DateTime DatumRodjenja { get; set; }             
        public Uloge Uloga { get; set; }
    }
}
