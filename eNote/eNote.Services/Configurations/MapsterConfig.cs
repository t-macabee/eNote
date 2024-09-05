using Mapster;

namespace eNote.Services.Configurations
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Database.Adresa, Model.DTOs.Adresa>
                .NewConfig();

            TypeAdapterConfig<Database.Uloge, Model.DTOs.Uloge>
                .NewConfig();

            TypeAdapterConfig<Database.Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.Adresa, src => $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}")
                .Map(dest => dest.Uloga, src => src.Uloga.Naziv);

            TypeAdapterConfig<Database.MusicShop, Model.DTOs.MusicShop>
                .NewConfig()
                .Map(dest => dest.Adresa, src => $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}")
                .Map(dest => dest.Uloga, src => src.Uloga.Naziv);

            TypeAdapterConfig<Database.Upis, Model.DTOs.Upis>
                .NewConfig();

            TypeAdapterConfig<Database.VrstaInstrumenta, Model.DTOs.VrstaInstrumenta>
                .NewConfig();

            TypeAdapterConfig<Database.Obavijest, Model.DTOs.Obavijest>
                .NewConfig()
                .Map(dest => dest.DatumVrijemePostavljanja, src => src.DatumVrijemePostavljanja);

            TypeAdapterConfig<Database.Predavanje, Model.DTOs.Predavanje>
                .NewConfig()
                .Map(dest => dest.Kurs, src => src.Kurs.Naziv)
                .Map(dest => dest.DatumVrijemePredavanja, src => src.DatumVrijemePredavanja);

            TypeAdapterConfig<Database.Instrumenti, Model.DTOs.Instrumenti>
               .NewConfig()
               .Map(dest => dest.MusicShop, src => src.MusicShop.Naziv)
               .Map(dest => dest.VrstaInstrumenta, src => src.VrstaInstrumenta.Naziv);

            TypeAdapterConfig<Database.Kurs, Model.DTOs.Kurs>
               .NewConfig()               
               .Map(dest => dest.DatumPocetka, src => src.DatumPocetka.ToString("d"))
               .Map(dest => dest.DatumZavrsetka, src => src.DatumZavrsetka.ToString("d"))
               .Map(dest => dest.InstruktorIme, src => $"{src.Instruktor.Ime} {src.Instruktor.Prezime}");
            
            TypeAdapterConfig.GlobalSettings.Compile();
        }        
    }
}
