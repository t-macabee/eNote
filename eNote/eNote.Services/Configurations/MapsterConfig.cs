using eNote.Model.DTOs;
using eNote.Model.Requests.MusicShop;
using eNote.Services.Database;
using Mapster;

namespace eNote.Services.Configurations
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.Uloga, src => src.Uloga != null ? src.Uloga.Naziv : null)
                .Map(dest => dest.DatumRodjenja, src => src.DatumRodjenja.ToString("d"))
                .Map(dest => dest.Adresa, src => src.Adresa != null ? $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}" : null);

            TypeAdapterConfig<Database.Instrumenti, Model.DTOs.Instrumenti>
                .NewConfig()
                .Map(dest => dest.VrstaInstrumenta, src => src.VrstaInstrumenta != null ? src.VrstaInstrumenta.Naziv : null)
                .Map(dest => dest.MusicShop, src => src.MusicShop != null ? src.MusicShop.Naziv : null);

            TypeAdapterConfig<MusicShop, Model.MusicShop>
                .NewConfig()                
                .Map(dest => dest.Adresa, src => src.Adresa != null ? $"{src.Adresa.Grad}, {src.Adresa.Ulica} {src.Adresa.Broj}" : null);

            TypeAdapterConfig<Database.Adresa, Model.DTOs.Adresa>
                .NewConfig();
            TypeAdapterConfig<VrstaInstrumenta, Model.VrstaInstrumenta>
                .NewConfig();

            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
