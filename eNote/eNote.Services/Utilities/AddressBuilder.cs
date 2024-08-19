using eNote.Model.Requests.BaseMember;
using eNote.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Helpers
{
    public static class AddressBuilder
    {
        public static async Task<Adresa> GetOrCreateAdresa(ENoteContext context, BaseMembersInsertRequest request)
        {
            if (request.AdresaId.HasValue && request.AdresaId.Value > 0)
            {
                var adresa = await context.Adresa.FindAsync(request.AdresaId.Value) ?? throw new Exception($"Adresa sa Id-em {request.AdresaId.Value} ne postoji.");

                return adresa;
            }
            else if (request.Adresa != null)
            {
                var existingAdresa = await context.Adresa.FirstOrDefaultAsync(a => a.Ulica == request.Adresa.Ulica && a.Broj == request.Adresa.Broj);

                if (existingAdresa != null)
                {
                    throw new Exception("Adresa sa istom ulicom i brojem već postoji.");
                }

                var newAdresa = new Adresa
                {
                    Grad = request.Adresa.Grad,
                    Ulica = request.Adresa.Ulica,
                    Broj = request.Adresa.Broj
                };

                context.Adresa.Add(newAdresa);
                await context.SaveChangesAsync();

                return newAdresa;
            }
            else
            {
                throw new Exception("AdresaId ili Adresa mora biti navedena.");
            }
        }
    }
}
