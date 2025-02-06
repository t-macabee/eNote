using eNote.Services.Database.Entities;
using Mapster;

namespace eNote.Services.Utilities
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Adresa, Model.DTOs.Adresa>
                .NewConfig();

            TypeAdapterConfig<MusicShop, Model.DTOs.MusicShop>
                .NewConfig()
                .Map(dest => dest.Adresa, src => $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}");

            TypeAdapterConfig<Upis, Model.DTOs.Upis>
                .NewConfig();

            TypeAdapterConfig<VrstaInstrumenta, Model.DTOs.VrstaInstrumenta>
                .NewConfig();

            TypeAdapterConfig<Napomena, Model.DTOs.Napomena>
                .NewConfig();
            //.Map(dest => dest.DatumVrijemePostavljanja, src => src.DatumVrijemePostavljanja);

            TypeAdapterConfig<Predavanje, Model.DTOs.Predavanje>
                .NewConfig();
            //.Map(dest => dest.Kurs, src => src.Kurs.Naziv)
            //.Map(dest => dest.DatumVrijemePredavanja, src => src.DatumVrijemePredavanja);

            TypeAdapterConfig<Instrumenti, Model.DTOs.Instrumenti>
               .NewConfig();

            TypeAdapterConfig<Kurs, Model.DTOs.Kurs>
               .NewConfig();
               //.Map(dest => dest.DatumPocetka, src => src.DatumPocetka.ToString("d"))
               //.Map(dest => dest.DatumZavrsetka, src => src.DatumZavrsetka.ToString("d"))
               //.Map(dest => dest.InstruktorIme, src => $"{src.Instruktor.Ime} {src.Instruktor.Prezime}");

            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
