using eNote.Model;
using eNote.Model.DTOs;
using eNote.Model.Requests.Korisnik;
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

            TypeAdapterConfig<Database.Korisnik, MusicShop>
               .NewConfig()
               .Map(dest => dest.Adresa, src => src.Adresa != null ? src.Adresa.Adapt<Model.DTOs.Adresa>() : null)
               .Map(dest => dest.Uloga, src => src.Uloga != null ? src.Uloga.Adapt<Model.DTOs.Uloge>() : null);

            TypeAdapterConfig<Database.Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.DatumRodjenja, src => src.DatumRodjenja.HasValue ? src.DatumRodjenja.Value.ToString("d") : null)
                .Map(dest => dest.Adresa, src => src.Adresa != null ? src.Adresa.Adapt<Model.DTOs.Adresa>() : null)
                .Map(dest => dest.Uloga, src => src.Uloga != null ? src.Uloga.Adapt<Model.DTOs.Uloge>() : null);


            TypeAdapterConfig.GlobalSettings.Compile();
        }        
    }
}
