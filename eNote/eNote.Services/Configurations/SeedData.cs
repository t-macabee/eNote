using eNote.Services.Database;
using eNote.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Configurations
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedAddresses(modelBuilder);
            SeedUsers(modelBuilder);
            SeedInstrumentType(modelBuilder);
            SeedInstruments(modelBuilder);
        }

        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uloge>().HasData(
                new Uloge { Id = 1, Naziv = "Administrator" },
                new Uloge { Id = 2, Naziv = "Instruktor" },
                new Uloge { Id = 3, Naziv = "Ucenik" },
                new Uloge { Id = 4, Naziv = "Shop" }
            );
        }

        public static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresa>().HasData(
                new Adresa { Id = 1, Grad = "Sarajevo", Ulica = "Bistrik", Broj = "12" },
                new Adresa { Id = 2, Grad = "Sarajevo", Ulica = "Maršala Tita", Broj = "15" },
                new Adresa { Id = 3, Grad = "Sarajevo", Ulica = "Mula Mustafe Bašeskije", Broj = "8" },
                new Adresa { Id = 4, Grad = "Sarajevo", Ulica = "Obala Kulina bana", Broj = "18" },
                new Adresa { Id = 5, Grad = "Sarajevo", Ulica = "Veliki Alifakovac", Broj = "14" }
            );

        }

        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            var adminSalt = PasswordBuilder.GenerateSalt();
            var adminHash = PasswordBuilder.GenerateHash(adminSalt, "admin");

            var instruktorSalt = PasswordBuilder.GenerateSalt();
            var instruktorHash = PasswordBuilder.GenerateHash(instruktorSalt, "pwd123");

            var ucenikSalt = PasswordBuilder.GenerateSalt();
            var ucenikHash = PasswordBuilder.GenerateHash(ucenikSalt, "pwd123");

            var musicShopSalt = PasswordBuilder.GenerateSalt();
            var musicShopHash = PasswordBuilder.GenerateHash(musicShopSalt, "pwd123");

            modelBuilder.Entity<Database.Korisnik>().HasData(
                new Korisnik { Id = 1, KorisnickoIme = "admin", Email = "admin@outlook.com", Telefon = "000000000", LozinkaHash = adminHash, LozinkaSalt = adminSalt, UlogaId = 1, AdresaId = 1, Ime = "Admin", Prezime = "Admin", DatumRodjenja = DateTime.Now },
                new Korisnik { Id = 2, KorisnickoIme = "instruktor", Email = "john.doe@outlook.com", Telefon = "111111111", LozinkaHash = instruktorHash, LozinkaSalt = instruktorSalt, UlogaId = 2, AdresaId = 4, Ime = "John", Prezime = "Doe", DatumRodjenja = DateTime.Now },
                new Korisnik { Id = 3, KorisnickoIme = "ucenik", Email = "jane.doe@outlook.com", Telefon = "222222222", LozinkaHash = ucenikHash, LozinkaSalt = ucenikSalt, UlogaId = 3, AdresaId = 5, Ime = "Jane", Prezime = "Doe", DatumRodjenja = DateTime.Now },
                new Korisnik { Id = 4, KorisnickoIme = "shop1", Email = "shop1@outlook.com", Telefon = "333333333", LozinkaHash = musicShopHash, LozinkaSalt = musicShopSalt, UlogaId = 4, AdresaId = 2, Naziv = "Bonemeal Music Shop" }
            );
            
        }      

        public static void SeedInstrumentType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VrstaInstrumenta>().HasData(
                new VrstaInstrumenta { Id = 1, Naziv = "Žičani" },
                new VrstaInstrumenta { Id = 2, Naziv = "Limeni" },
                new VrstaInstrumenta { Id = 3, Naziv = "Udaraljke" },
                new VrstaInstrumenta { Id = 4, Naziv = "Instrument s tipkama" },
                new VrstaInstrumenta { Id = 5, Naziv = "Elektronički" }
            );
        }

        public static void SeedInstruments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrumenti>().HasData(
               new Instrumenti { Id = 1, Model = "J-45", Proizvodjac = "Gibson", Opis = "Ikonična akustična gitara poznata po bogatom, punom zvuku.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 2, Model = "214ce", Proizvodjac = "Taylor", Opis = "Popularna grand auditorium akustična gitara sa svijetlim, jasnim tonom.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 3, Model = "CD-60S", Proizvodjac = "Fender", Opis = "Pristupačna akustična gitara savršena za početnike i srednje napredne svirače.", KorisnikId = 4, VrstaInstrumentaId = 1 },

               new Instrumenti { Id = 4, Model = "Stratocaster", Proizvodjac = "Fender", Opis = "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 5, Model = "Les Paul", Proizvodjac = "Gibson", Opis = "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 6, Model = "RG", Proizvodjac = "Ibanez", Opis = "Visokoperformansna električna gitara popularna među rok i metal sviračima.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 7, Model = "Custom 24", Proizvodjac = "PRS", Opis = "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 8, Model = "Pacifica", Proizvodjac = "Yamaha", Opis = "Svestrana električna gitara pogodna za različite žanrove.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 9, Model = "Dinky", Proizvodjac = "Jackson", Opis = "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 10, Model = "C-1", Proizvodjac = "Schecter", Opis = "Električna gitara poznata po svojoj čvrstoj izradi i teškim tonovima.", KorisnikId = 4, VrstaInstrumentaId = 1 },

               new Instrumenti { Id = 11, Model = "Precision Bass", Proizvodjac = "Fender", Opis = "Industrijski standard bas gitara poznata po dubokom, udarnom zvuku.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 12, Model = "SR", Proizvodjac = "Ibanez", Opis = "Elegantna bas gitara popularna zbog svog brzog vrata i svestranih tonova.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 13, Model = "Thunderbird", Proizvodjac = "Gibson", Opis = "Ikonična bas gitara poznata po jedinstvenom dizajnu i snažnom zvuku.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 14, Model = "BB", Proizvodjac = "Yamaha", Opis = "Pouzdana bas gitara sa velikim balansom svirljivosti i tona.", KorisnikId = 4, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 15, Model = "RockBass", Proizvodjac = "Warwick", Opis = "Bas gitara poznata po svom jedinstvenom 'growl' tonu i ergonomskoj izradi.", KorisnikId = 4, VrstaInstrumentaId = 1 },

               new Instrumenti { Id = 16, Model = "Export", Proizvodjac = "Pearl", Opis = "Pristupačan bubanj set savršen za početnike i srednje napredne bubnjare.", KorisnikId = 4, VrstaInstrumentaId = 3 },
               new Instrumenti { Id = 17, Model = "Imperialstar", Proizvodjac = "Tama", Opis = "Svestran bubanj set sa izvrsnom izradom i zvukom.", KorisnikId = 4, VrstaInstrumentaId = 3 },
               new Instrumenti { Id = 18, Model = "Breakbeats", Proizvodjac = "Ludwig", Opis = "Kompaktni bubanj set dizajniran za prenosivost i odličan ton.", KorisnikId = 4, VrstaInstrumentaId = 3 },

               new Instrumenti { Id = 19, Model = "Mark VI", Proizvodjac = "Selmer", Opis = "Legendarni saksofon poznat po izvrsnom tonu i svirljivosti.", KorisnikId = 4, VrstaInstrumentaId = 2 },
               new Instrumenti { Id = 20, Model = "YAS-280", Proizvodjac = "Yamaha", Opis = "Popularni saksofon među studentima i srednje naprednim sviračima.", KorisnikId = 4, VrstaInstrumentaId = 2 },

               new Instrumenti { Id = 21, Model = "Minilogue", Proizvodjac = "Korg", Opis = "Analogni sintisajzer poznat po svom bogatom, toplom zvuku.", KorisnikId = 4, VrstaInstrumentaId = 4 },
               new Instrumenti { Id = 22, Model = "Juno-DS", Proizvodjac = "Roland", Opis = "Svestrani sintisajzer popularan za žive nastupe i studijsku upotrebu.", KorisnikId = 4, VrstaInstrumentaId = 4 },
               new Instrumenti { Id = 23, Model = "Sub Phatty", Proizvodjac = "Moog", Opis = "Analogni sintisajzer poznat po svom snažnom basu i lead tonovima.", KorisnikId = 4, VrstaInstrumentaId = 4 },

               new Instrumenti { Id = 24, Model = "Stradivarius", Proizvodjac = "Bach", Opis = "Profesionalni trombon poznat po bogatom tonu i preciznoj intonaciji.", KorisnikId = 4, VrstaInstrumentaId = 2 },
               new Instrumenti { Id = 25, Model = "YSL-354", Proizvodjac = "Yamaha", Opis = "Studentski trombon poznat po svojoj izdržljivosti i lakoći sviranja.", KorisnikId = 4, VrstaInstrumentaId = 2 }
            );
        }     
                      
    }
}
