using eNote.Model;

namespace eNote.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<IKorisnik> Login(LoginModel model);
    }
}
