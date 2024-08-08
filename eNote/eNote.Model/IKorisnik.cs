using eNote.Model.DTOs;

namespace eNote.Model
{
    public interface IKorisnik
    {
        int Id { get; }
        string KorisnickoIme { get; }
        Uloge Uloga { get; }
    }
}

