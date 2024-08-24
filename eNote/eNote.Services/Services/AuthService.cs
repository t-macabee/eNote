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
        public async Task<object> Login(LoginModel model)
        {
            var korisnikEntity = await context.Korisnici
                .Include(x => x.Uloga)
                .Include(x => x.Adresa)
                .FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (korisnikEntity != null && PasswordBuilder.VerifyPassword(korisnikEntity.LozinkaSalt, model.Password, korisnikEntity.LozinkaHash))
            {
                return mapper.Map<Model.Korisnik>(korisnikEntity);
            }

            var musicShopEntity = await context.MusicShops
                .Include(x => x.Uloga)
                .Include(x => x.Adresa)
                .FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (musicShopEntity != null && PasswordBuilder.VerifyPassword(musicShopEntity.LozinkaSalt, model.Password, musicShopEntity.LozinkaHash))
            {
                return mapper.Map<Model.DTOs.MusicShop>(musicShopEntity);
            }

            return null;
        }
    }
}
