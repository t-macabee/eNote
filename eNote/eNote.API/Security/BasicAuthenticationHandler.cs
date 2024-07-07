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
    public class BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IKorisniciService service) 
        : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        private readonly IKorisniciService service = service;

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                return AuthenticateResult.Fail("Missing Authorization header");
            }

            var authHeaderVal = authorizationHeader.ToString();
            if (string.IsNullOrEmpty(authHeaderVal))
            {
                return AuthenticateResult.Fail("Empty Authorization header");
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(authHeaderVal);

                if (authHeader.Parameter == null)
                {
                    return AuthenticateResult.Fail("Invalid Authorization header format");
                }

                var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);

                var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(':');

                var username = credentials[0];

                var password = credentials[1];

                var user = await Task.Run(() => service.Login(username, password));

                if (user == null)
                {
                    return AuthenticateResult.Fail("Authentication failed");
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new (ClaimTypes.Name, user.Ime),
                        new (ClaimTypes.NameIdentifier, user.KorisnickoIme),
                        new (ClaimTypes.Role, user.Uloga)
                    };                    

                    var identity = new ClaimsIdentity(claims, Scheme.Name);

                    var principal = new ClaimsPrincipal(identity);

                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (FormatException)
            {
                return AuthenticateResult.Fail("Invalid Authorization header format");
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
            }
        }
    }
}
