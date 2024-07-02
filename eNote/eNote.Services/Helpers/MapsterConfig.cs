using eNote.Services.Database;
using Mapster;

namespace eNote.Services.Helpers
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.Uloga, src => src.Uloga.Naziv)
                .Map(dest => dest.DatumRodjenja, src => src.DatumRodjenja.ToString("d"))
                .Map(dest => dest.Adresa, src => src.Adresa != null ? $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}" : null);

            TypeAdapterConfig<Database.Instrumenti, Model.DTOs.Instrumenti>
                .NewConfig()
                .Map(dest => dest.Model, src => src.Model)
                .Map(dest => dest.Proizvodjac, src => src.Proizvodjac)
                .Map(dest => dest.Opis, src => src.Opis)
                .Map(dest => dest.MusicShop, src => src.MusicShop.Naziv)
                .Map(dest => dest.VrstaInstrumenta, src => src.VrstaInstrumenta != null ? src.VrstaInstrumenta.Naziv : null);

            TypeAdapterConfig<Database.MusicShop, Model.MusicShop>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.Naziv)
                .Map(dest => dest.AdresaString, src => src.Adresa != null ? $"{src.Adresa.Ulica} {src.Adresa.Broj}, {src.Adresa.Grad}" : null);

            TypeAdapterConfig<Database.VrstaInstrumenta, Model.VrstaInstrumenta>
                .NewConfig()
                .Map(dest => dest.Naziv, src => src.Naziv);
        }
    }
}
