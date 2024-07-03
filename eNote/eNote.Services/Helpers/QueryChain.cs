using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Helpers
{
    public static class QueryChain
    {
        public static IQueryable<Database.Korisnik> IncludeKorisnik(IQueryable<Database.Korisnik> query)
        {
            return query.Include(x => x.Uloga).Include(x => x.Adresa);
        }

        public static IQueryable<Database.MusicShop> IncludeMusicShop(IQueryable<Database.MusicShop> query)
        {
            return query.Include(x => x.Adresa);
        }

        public static IQueryable<Database.Instrumenti> IncludeInstrumenti(IQueryable<Database.Instrumenti> query)
        {
            return query.Include(x => x.VrstaInstrumenta).Include(x => x.MusicShop);
        }
    }
}
