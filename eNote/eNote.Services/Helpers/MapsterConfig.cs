using eNote.Model.Requests.MusicShop;
using eNote.Services.Database;
using Mapster;

namespace eNote.Services.Helpers
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {            
            TypeAdapterConfig<Database.Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.Uloga, src => src.Uloga != null ? src.Uloga.Naziv : null)
                .Map(dest => dest.DatumRodjenja, src => src.DatumRodjenja.ToString("d"))
                .Map(dest => dest.Adresa, src => src.Adresa != null ? $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}" : null);
            
            TypeAdapterConfig<Instrumenti, Model.DTOs.Instrumenti>
                .NewConfig()
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Proizvodjac, src => src.Proizvodjac)
                .Map(dest => dest.Opis, src => src.Opis)
                .Map(dest => dest.MusicShop, src => src.MusicShop != null ? src.MusicShop.Naziv : null)
                .Map(dest => dest.VrstaInstrumenta, src => src.VrstaInstrumenta != null ? src.VrstaInstrumenta.Naziv : null);

            TypeAdapterConfig<MusicShopUpsertRequest, MusicShop>
                .NewConfig()
                .Ignore(dest => dest.Adresa);

            TypeAdapterConfig<MusicShop, Model.MusicShop>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.Naziv)
                .Map(dest => dest.AdresaString, src => src.Adresa != null ? $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}" : null);
            
            TypeAdapterConfig<VrstaInstrumenta, Model.VrstaInstrumenta>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.Naziv);
            
            TypeAdapterConfig<Adresa, Model.DTOs.Adresa>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)  
                .Map(dest => dest.Grad, src => src.Grad)
                .Map(dest => dest.Ulica, src => src.Ulica)
                .Map(dest => dest.Broj, src => src.Broj);            

            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
