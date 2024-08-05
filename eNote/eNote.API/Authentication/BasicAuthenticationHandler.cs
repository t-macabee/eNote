using eNote.Services.Database;
using eNote.Services.Interfaces;
using eNote.Services.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace eNote.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IKorisniciService korisniciService;
        private readonly IMusicShopService musicShopService;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IKorisniciService korisniciService, IMusicShopService musicShopService)
            : base(options, logger, encoder)
        {
            this.korisniciService = korisniciService;
            this.musicShopService = musicShopService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing authorization header");
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                ClaimsIdentity identity = null;

                var korisnik = await korisniciService.Login(username, password);
                if (korisnik != null)
                {
                    identity = CreateIdentity(korisnik.Id.ToString(), korisnik.KorisnickoIme, korisnik.Uloga.Naziv.ToString());
                }
                else
                {
                    var musicShop = await musicShopService.Login(username, password);
                    if (musicShop != null)
                    {
                        identity = CreateIdentity(musicShop.Id.ToString(), musicShop.KorisnickoIme, musicShop.Uloga.Naziv.ToString());
                    }
                }

                if (identity == null)
                {
                    return AuthenticateResult.Fail("Invalid username or password");
                }

                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }
        }

        private ClaimsIdentity CreateIdentity(string id, string username, string role)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, username),
                new (ClaimTypes.NameIdentifier, id),
                new (ClaimTypes.Role, role)
            };
            return new ClaimsIdentity(claims, Scheme.Name);
        }
    }
}
