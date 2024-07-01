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

            TypeAdapterConfig<Database.Instrumenti, Model.Instrumenti>
                .NewConfig()
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Proizvodjac, src => src.Proizvodjac) 
                .Map(dest => dest.Opis, src => src.Opis);

            TypeAdapterConfig<Database.MusicShop, Model.MusicShop>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.Naziv)
                .Map(dest => dest.Adresa, src => src.Adresa);

            TypeAdapterConfig<Database.VrstaInstrumenta, Model.VrstaInstrumenta>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.Naziv);            
        }
    }
}
