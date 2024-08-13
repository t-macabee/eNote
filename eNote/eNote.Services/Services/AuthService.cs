using eNote.Model;
using eNote.Services.Database;
using eNote.Services.Helpers;
using eNote.Services.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class AuthService(ENoteContext context, IMapper mapper) : IAuthService
    {
        public async Task<Model.Korisnik> Login(LoginModel model)
        {
            var entity = await context.Korisnici.Include(x => x.Adresa).FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (entity == null || !PasswordBuilder.VerifyPassword(entity.LozinkaSalt, model.Password, entity.LozinkaHash))
            {
                return null;
            }
            
            return mapper.Map<Model.Korisnik>(entity);            
        }
    }
}
