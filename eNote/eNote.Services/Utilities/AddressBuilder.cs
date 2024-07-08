using Azure.Core;
using eNote.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Helpers
{
    public static class AddressBuilder
    {
        private static readonly char[] separator = [','];
        private static readonly char[] separatorArray = [','];

        public static async Task<Adresa> Create(ENoteContext context, string adresaString)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (string.IsNullOrWhiteSpace(adresaString))
            {
                throw new ArgumentException("Address string ne može biti null ili empty.", nameof(adresaString));
            }

            var addressComponents = adresaString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (addressComponents.Length < 2)
            {
                throw new ArgumentException("Nevažeći format adrese. Očekivani format: 'Ulica Broj, Grad'.", nameof(adresaString));
            }

            var ulicaIBroj = addressComponents[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (ulicaIBroj.Length < 2)
            {
                throw new ArgumentException("Adresa mora sadržavati ulicu i broj.", nameof(adresaString));
            }

            var adresa = new Database.Adresa
            {
                Ulica = string.Join(' ', ulicaIBroj[..^1]),
                Broj = ulicaIBroj[^1],
                Grad = addressComponents[1].Trim()
            };

            await context.AddAsync(adresa);
            
            await context.SaveChangesAsync();

            return adresa;
        }

        public static async Task Update(ENoteContext context, Adresa adresa, string adresaString)
        {
            ArgumentNullException.ThrowIfNull(adresa);

            if (string.IsNullOrWhiteSpace(adresaString))
            {
                throw new ArgumentException("Address string ne može biti null ili empty.", nameof(adresaString));
            }

            var addressComponents = adresaString.Split(separatorArray, StringSplitOptions.RemoveEmptyEntries);

            if (addressComponents.Length < 2)
            {
                throw new ArgumentException("Nevažeći format adrese. Očekivani format: 'Ulica Broj, Grad'.", nameof(adresaString));
            }

            var ulicaIBroj = addressComponents[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            adresa.Ulica = string.Join(' ', ulicaIBroj[..^1]);
            adresa.Broj = ulicaIBroj[^1];
            adresa.Grad = addressComponents[1].Trim();

            await context.SaveChangesAsync();
        }
    }
}
