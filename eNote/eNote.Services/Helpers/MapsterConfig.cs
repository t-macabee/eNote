using eNote.Services.Database;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Helpers
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Korisnik, Model.Korisnik>
                .NewConfig().Map(dest => dest.Uloga, src => src.Uloga.Naziv);
        }
    }
}
