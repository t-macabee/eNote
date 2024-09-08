using eNote.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Utilities
{
    public static class EntityBuilder
    {
        public static async Task LoadEntities<TEntity>(DbContext context, TEntity entity) where TEntity : class
        {
            if (entity is Predavanje predavanje)
            {
                await context.Entry(predavanje)
                    .Reference(p => p.Kurs)                    
                    .LoadAsync();

                if (predavanje.Kurs != null)
                {
                    await context.Entry(predavanje.Kurs)
                        .Reference(k => k.Instruktor)
                        .LoadAsync();
                }
            }
            else if (entity is Korisnik korisnik)
            {
                await context.Entry(korisnik)
                    .Reference(k => k.Adresa)
                    .LoadAsync();
            }
        }
    }
}
