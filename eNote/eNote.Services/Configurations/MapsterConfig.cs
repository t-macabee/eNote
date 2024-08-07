using eNote.Model;
using eNote.Model.DTOs;
using eNote.Services.Database;
using Mapster;

namespace eNote.Services.Configurations
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Database.VrstaInstrumenta, Model.VrstaInstrumenta>
               .NewConfig();

            TypeAdapterConfig<Database.Adresa, Model.DTOs.Adresa>
                .NewConfig();

            TypeAdapterConfig<Database.Uloge, Model.DTOs.Uloge>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.NazivString);

            TypeAdapterConfig<Database.Instrumenti, Model.DTOs.Instrumenti>
               .NewConfig()
               .Map(dest => dest.MusicShop, src => src.MusicShop.Naziv);
            
            TypeAdapterConfig<Database.Kurs, Model.DTOs.Kurs>
               .NewConfig()
               .Map(dest => dest.InstruktorIme, src => src.Instruktor.Ime.ToString());

            TypeAdapterConfig<Database.Korisnik, Model.MusicShop>
             .NewConfig();

            TypeAdapterConfig<Database.Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.DatumRodjenja, src => src.DatumRodjenja.HasValue ? src.DatumRodjenja.Value.ToString("d") : null);
                                                     
            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
