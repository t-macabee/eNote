using eNote.Model.Enums;
using eNote.Services.Database;
using eNote.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Configurations
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedAddresses(modelBuilder);
            SeedUsers(modelBuilder);            
            SeedCourses(modelBuilder);
            SeedInstruments(modelBuilder);
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

            modelBuilder.Entity<Korisnik>().HasData(
                new Korisnik { Id = 1, KorisnickoIme = "admin", Email = "admin@outlook.com", Telefon = "000000000", LozinkaHash = adminHash, LozinkaSalt = adminSalt, Uloga = Uloge.Administrator, AdresaId = 1, Ime = "Admin", Prezime = "Admin", DatumRodjenja = new DateTime(1996, 07, 29), Status = true },
                new Korisnik { Id = 2, KorisnickoIme = "instruktor", Email = "john.doe@outlook.com", Telefon = "111111111", LozinkaHash = instruktorHash, LozinkaSalt = instruktorSalt, Uloga = Uloge.Instruktor, AdresaId = 4, Ime = "John", Prezime = "Doe", DatumRodjenja = new DateTime(1997, 06, 15), Status = true },
                new Korisnik { Id = 3, KorisnickoIme = "polaznik", Email = "jane.doe@outlook.com", Telefon = "222222222", LozinkaHash = ucenikHash, LozinkaSalt = ucenikSalt, Uloga = Uloge.Polaznik, AdresaId = 5, Ime = "Jane", Prezime = "Doe", DatumRodjenja = new DateTime(1967, 03, 17), Status = true }               
            );

            modelBuilder.Entity<MusicShop>().HasData(
                 new MusicShop { Id = 1, KorisnickoIme = "shop1", Email = "shop1@outlook.com", Telefon = "333333333", LozinkaHash = musicShopHash, LozinkaSalt = musicShopSalt, Uloga = Uloge.MusicShop, AdresaId = 2, Naziv = "Bonemeal Music Shop", Status = true }
            );
        }

        public static void SeedCourses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kurs>().HasData(
                new Kurs
                {
                    Id = 1,
                    Naziv = "Osnove teorije muzike",
                    Opis = "Testni opis kursa osnova teorije muzke.",
                    DatumPocetka = new DateTime(2024, 08, 10),
                    DatumZavrsetka = new DateTime(2024, 10, 10),
                    Cijena = 800,
                    InstruktorId = 2
                },

                new Kurs
                {
                    Id = 2,
                    Naziv = "Napredne tehnike gitare",
                    Opis = "Otkrijte napredne tehnike gitare, uključujući kompleksne akorde, improvizaciju i solo sviranje, kako biste unaprijedili svoje vještine i kreativnost na gitari.",
                    DatumPocetka = new DateTime(2024, 09, 12),
                    DatumZavrsetka = new DateTime(2024, 10, 12),
                    Cijena = 800,
                    InstruktorId = 2
                }
            );                                   
        }       

        public static void SeedInstruments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrumenti>().HasData(
               new Instrumenti { Id = 1, Model = "J-45", Proizvodjac = "Gibson", Opis = "Ikonična akustična gitara poznata po bogatom, punom zvuku.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 2, Model = "214ce", Proizvodjac = "Taylor", Opis = "Popularna grand auditorium akustična gitara sa svijetlim, jasnim tonom.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 3, Model = "CD-60S", Proizvodjac = "Fender", Opis = "Pristupačna akustična gitara savršena za početnike i srednje napredne svirače.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },

               new Instrumenti { Id = 4, Model = "Stratocaster", Proizvodjac = "Fender", Opis = "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 5, Model = "Les Paul", Proizvodjac = "Gibson", Opis = "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 6, Model = "RG", Proizvodjac = "Ibanez", Opis = "Visokoperformansna električna gitara popularna među rok i metal sviračima.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 7, Model = "Custom 24", Proizvodjac = "PRS", Opis = "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 8, Model = "Pacifica", Proizvodjac = "Yamaha", Opis = "Svestrana električna gitara pogodna za različite žanrove.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 9, Model = "Dinky", Proizvodjac = "Jackson", Opis = "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 10, Model = "C-1", Proizvodjac = "Schecter", Opis = "Električna gitara poznata po svojoj čvrstoj izradi i teškim tonovima.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },

               new Instrumenti { Id = 11, Model = "Precision Bass", Proizvodjac = "Fender", Opis = "Industrijski standard bas gitara poznata po dubokom, udarnom zvuku.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 12, Model = "SR", Proizvodjac = "Ibanez", Opis = "Elegantna bas gitara popularna zbog svog brzog vrata i svestranih tonova.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 13, Model = "Thunderbird", Proizvodjac = "Gibson", Opis = "Ikonična bas gitara poznata po jedinstvenom dizajnu i snažnom zvuku.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 14, Model = "BB", Proizvodjac = "Yamaha", Opis = "Pouzdana bas gitara sa velikim balansom svirljivosti i tona.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },
               new Instrumenti { Id = 15, Model = "RockBass", Proizvodjac = "Warwick", Opis = "Bas gitara poznata po svom jedinstvenom 'growl' tonu i ergonomskoj izradi.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Zicani },

               new Instrumenti { Id = 16, Model = "Export", Proizvodjac = "Pearl", Opis = "Pristupačan bubanj set savršen za početnike i srednje napredne bubnjare.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Udaraljke },
               new Instrumenti { Id = 17, Model = "Imperialstar", Proizvodjac = "Tama", Opis = "Svestran bubanj set sa izvrsnom izradom i zvukom.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Udaraljke },
               new Instrumenti { Id = 18, Model = "Breakbeats", Proizvodjac = "Ludwig", Opis = "Kompaktni bubanj set dizajniran za prenosivost i odličan ton.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Udaraljke },

               new Instrumenti { Id = 19, Model = "Mark VI", Proizvodjac = "Selmer", Opis = "Legendarni saksofon poznat po izvrsnom tonu i svirljivosti.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Limeni },
               new Instrumenti { Id = 20, Model = "YAS-280", Proizvodjac = "Yamaha", Opis = "Popularni saksofon među studentima i srednje naprednim sviračima.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Limeni },
               new Instrumenti { Id = 24, Model = "Stradivarius", Proizvodjac = "Bach", Opis = "Profesionalni trombon poznat po bogatom tonu i preciznoj intonaciji.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Limeni },
               new Instrumenti { Id = 25, Model = "YSL-354", Proizvodjac = "Yamaha", Opis = "Studentski trombon poznat po svojoj izdržljivosti i lakoći sviranja.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Limeni },

               new Instrumenti { Id = 21, Model = "Minilogue", Proizvodjac = "Korg", Opis = "Analogni sintisajzer poznat po svom bogatom, toplom zvuku.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Tipke },
               new Instrumenti { Id = 22, Model = "Juno-DS", Proizvodjac = "Roland", Opis = "Svestrani sintisajzer popularan za žive nastupe i studijsku upotrebu.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Tipke },
               new Instrumenti { Id = 23, Model = "Sub Phatty", Proizvodjac = "Moog", Opis = "Analogni sintisajzer poznat po svom snažnom basu i lead tonovima.", MusicShopId = 1, VrstaInstrumenta = VrstaInstrumenta.Tipke }               
            );
        }
    }
}
