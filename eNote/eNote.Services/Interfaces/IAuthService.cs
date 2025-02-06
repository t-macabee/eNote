using eNote.Model;
using eNote.Services.Database.Entities;

namespace eNote.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<BaseKorisnik?> Login(LoginModel model);
    }
}
