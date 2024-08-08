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
        public async Task<IKorisnik> Login(LoginModel model)
        {
            var entity = await context.Korisnici
                .Include(x => x.Uloga)
                .Include(x => x.Adresa)
                .FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (entity == null || !PasswordBuilder.VerifyPassword(entity.LozinkaSalt, model.Password, entity.LozinkaHash))
            {
                return null;
            }

            if (entity.Uloga.Naziv == "Shop")
            {
                return mapper.Map<MusicShop>(entity);
            }
            
            return mapper.Map<Model.Korisnik>(entity);            
        }
    }
}
