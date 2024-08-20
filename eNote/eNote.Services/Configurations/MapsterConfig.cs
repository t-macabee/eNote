﻿using Mapster;

namespace eNote.Services.Configurations
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Database.Adresa, Model.DTOs.Adresa>
                .NewConfig();

            TypeAdapterConfig<Database.Korisnik, Model.Korisnik>
                .NewConfig()
                .Map(dest => dest.Adresa, src => src.Adresa);

            TypeAdapterConfig<Database.MusicShop, Model.DTOs.MusicShop>
                .NewConfig();

            TypeAdapterConfig<Database.Kurs, Model.DTOs.Kurs> 
                .NewConfig();

            TypeAdapterConfig<Database.Upis, Model.DTOs.Upis>
                .NewConfig();

            TypeAdapterConfig<Database.Obavijest, Model.DTOs.Obavijest>
                .NewConfig();

            TypeAdapterConfig<Database.Predavanje, Model.DTOs.Predavanje>
                .NewConfig()
                .Map(dest => dest.Kurs, src => src.Kurs);

            TypeAdapterConfig<Database.Instrumenti, Model.DTOs.Instrumenti>
               .NewConfig()
               .Map(dest => dest.MusicShop, src => src.MusicShop.Naziv);
            
            TypeAdapterConfig<Database.Kurs, Model.DTOs.Kurs>
               .NewConfig()               
               .Map(dest => dest.DatumPocetka, src => src.DatumPocetka.ToString("d"))
               .Map(dest => dest.DatumZavrsetka, src => src.DatumZavrsetka.ToString("d"))
               .Map(dest => dest.InstruktorIme, src => $"{src.Instruktor.Ime} {src.Instruktor.Prezime}");
            
            TypeAdapterConfig.GlobalSettings.Compile();
        }        
    }
}
