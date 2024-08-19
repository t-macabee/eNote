using eNote.Model;

namespace eNote.Services.Interfaces
{
    public interface IAuthService 
    {
        Task<object> Login(LoginModel model);
    }
}
