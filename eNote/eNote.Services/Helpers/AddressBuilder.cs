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
        public static Adresa Create(eNoteContext context, string adresaString)
        {
            var addressComponents = adresaString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (addressComponents.Length < 2)
            {
                throw new Exception("Nevažeći format adrese. Očekivani format: 'Ulica Broj, Grad'.");
            }

            var ulicaIBroj = addressComponents[0].Trim().Split(' ');

            if (ulicaIBroj.Length < 2)
            {
                throw new Exception("Adresa mora sadržavati ulicu i broj.");
            }

            var ulica = string.Join(' ', ulicaIBroj.Take(ulicaIBroj.Length - 1));

            var broj = ulicaIBroj.Last();

            var grad = addressComponents[1].Trim();
            
            var adresa = new Database.Adresa
            {
                Ulica = ulica,
                Broj = broj,
                Grad = grad
            };
            
            context.Add(adresa);

            context.SaveChanges();

            return adresa;
        }

        public static void Update(eNoteContext context, Database.Adresa adresa, string adresaString)
        {
            var addressComponents = adresaString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var ulicaIBroj = addressComponents[0].Trim().Split(' ');           

            adresa.Ulica = string.Join(' ', ulicaIBroj.Take(ulicaIBroj.Length - 1));

            adresa.Broj = ulicaIBroj.Last();

            adresa.Grad = addressComponents[1].Trim();
        }
    }
}
