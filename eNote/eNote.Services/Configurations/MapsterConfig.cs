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
            TypeAdapterConfig<Database.Uloge, Model.DTOs.Uloge>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.NazivString);

            TypeAdapterConfig<Database.Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.Uloga, src => src.Uloga == null ? null : new Model.DTOs.Uloge
                {
                    Id = src.Uloga.Id,
                    Naziv = src.Uloga.Naziv
                })
                .Map(dest => dest.DatumRodjenja, src => src.DatumRodjenja.HasValue ? src.DatumRodjenja.Value.ToString("d") : null)
                .Map(dest => dest.Adresa, src => src.Adresa != null ? $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}" : null);

            TypeAdapterConfig<Database.Instrumenti, Model.DTOs.Instrumenti>
                .NewConfig()
                .Map(dest => dest.VrstaInstrumenta, src => src.VrstaInstrumenta != null ? src.VrstaInstrumenta.Naziv : null)
                .Map(dest => dest.MusicShop, src => src.MusicShop != null ? src.MusicShop.Naziv : null);          

            TypeAdapterConfig<Database.Kurs, Model.DTOs.Kurs>
                .NewConfig()
                .Map(dest => dest.InstruktorIme, src => src.Instruktor.Ime.ToString());

            TypeAdapterConfig<Database.Adresa, Model.DTOs.Adresa>
                .NewConfig();
            TypeAdapterConfig<Database.VrstaInstrumenta, Model.VrstaInstrumenta>
                .NewConfig();

            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
