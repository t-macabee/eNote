using eNote.Model;
using eNote.Services.Database;
using eNote.Services.Database.Entities;
using eNote.Services.Interfaces;
using eNote.Services.Utilities;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Services
{
    public class AuthService(ENoteContext context) : IAuthService
    {
        public async Task<BaseKorisnik?> Login(LoginModel model)
        {
            var admin = await context.Administrator.FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (admin != null && PasswordBuilder.VerifyPassword(admin.LozinkaSalt, model.Password, admin.LozinkaHash))
            {
                return admin;
            }

            var instruktor = await context.Instruktor
                .Include(x => x.Adresa)
                .FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (instruktor != null && PasswordBuilder.VerifyPassword(instruktor.LozinkaSalt, model.Password, instruktor.LozinkaHash))
            {
                return instruktor;
            }

            var polaznik = await context.Polaznik
                .Include(x => x.Adresa)
                .FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (polaznik != null && PasswordBuilder.VerifyPassword(polaznik.LozinkaSalt, model.Password, polaznik.LozinkaHash))
            {
                return polaznik;
            }

            var musicShop = await context.MusicShop
                .Include(x => x.Adresa)
                .FirstOrDefaultAsync(x => x.KorisnickoIme == model.Username);

            if (musicShop != null && PasswordBuilder.VerifyPassword(musicShop.LozinkaSalt, model.Password, musicShop.LozinkaHash))
            {
                return musicShop;
            }

            return null;
        }
    }
}
