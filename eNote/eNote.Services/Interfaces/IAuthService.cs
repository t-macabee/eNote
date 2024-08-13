using eNote.Model;

namespace eNote.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<Korisnik> Login(LoginModel model);
    }
}
