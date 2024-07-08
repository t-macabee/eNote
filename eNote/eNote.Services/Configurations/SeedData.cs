using eNote.Services.Database;
using eNote.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
            SeedMusicShop(modelBuilder);
            SeedInstruments(modelBuilder);
        }

        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uloge>().HasData(
                new Uloge { Id = (int)UserRoles.Administrator, Naziv = UserRoles.Administrator },
                new Uloge { Id = (int)UserRoles.Instruktor, Naziv = UserRoles.Instruktor },
                new Uloge { Id = (int)UserRoles.Ucenik, Naziv = UserRoles.Ucenik }
            );
        }

        public static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresa>().HasData(
                new Adresa { Id = 1, Grad = "Gradacac", Ulica = "7. bataljon", Broj = "11" },
                new Adresa { Id = 2, Grad = "Sarajevo", Ulica = "Ferhadija", Broj = "15" },
                new Adresa { Id = 3, Grad = "Sarajevo", Ulica = "Maršala Tita", Broj = "45" },
                new Adresa { Id = 4, Grad = "Mostar", Ulica = "Mazoljice", Broj = "17A" },
                new Adresa { Id = 5, Grad = "Mostar", Ulica = "Muje Pašića", Broj = "7C" }
            );
        }

        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            var adminSalt = PasswordBuilder.GenerateSalt();
            var adminHash = PasswordBuilder.GenerateHash(adminSalt, "admin");

            var instructorSalt = PasswordBuilder.GenerateSalt();
            var instructorHash = PasswordBuilder.GenerateHash(instructorSalt, "instructor");

            var studentSalt = PasswordBuilder.GenerateSalt();
            var studentHash = PasswordBuilder.GenerateHash(studentSalt, "student");

            modelBuilder.Entity<Korisnik>().HasData(
                new Korisnik { Id = 1, Ime = "Admin", Prezime = "Admin", DatumRodjenja = DateTime.Now, Email = "admin@outlook.com", Telefon = "000000000", KorisnickoIme = "admin", LozinkaSalt = adminSalt, LozinkaHash = adminHash, UlogaId = (int)UserRoles.Administrator, AdresaId = 1 },
                new Korisnik { Id = 2, Ime = "John", Prezime = "Doe", DatumRodjenja = DateTime.Now, Email = "john.doe@outlook.com", Telefon = "111111111", KorisnickoIme = "johnDoe", LozinkaSalt = instructorSalt, LozinkaHash = instructorHash, UlogaId = (int)UserRoles.Instruktor, AdresaId = 4 },
                new Korisnik { Id = 3, Ime = "Jane", Prezime = "Doe", DatumRodjenja = DateTime.Now, Email = "jane.doe@outlook.com", Telefon = "222222222", KorisnickoIme = "janeDoe", LozinkaSalt = studentSalt, LozinkaHash = studentHash, UlogaId = (int)UserRoles.Ucenik, AdresaId = 5 }
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

        public static void SeedMusicShop(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicShop>().HasData(
               new MusicShop { Id = 1, Naziv = "Bonemeal Music Shop", AdresaId = 2 },
               new MusicShop { Id = 2, Naziv = "Harmonia Music Store", AdresaId = 3 }
            );
        }

        public static void SeedInstruments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrumenti>().HasData(
               new Instrumenti { Id = 1, Model = "J-45", Proizvodjac = "Gibson", Opis = "Ikonična akustična gitara poznata po bogatom, punom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 2, Model = "214ce", Proizvodjac = "Taylor", Opis = "Popularna grand auditorium akustična gitara sa svijetlim, jasnim tonom.", MusicShopId = 2, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 3, Model = "CD-60S", Proizvodjac = "Fender", Opis = "Pristupačna akustična gitara savršena za početnike i srednje napredne svirače.", MusicShopId = 1, VrstaInstrumentaId = 1 },

               new Instrumenti { Id = 4, Model = "Stratocaster", Proizvodjac = "Fender", Opis = "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", MusicShopId = 2, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 5, Model = "Les Paul", Proizvodjac = "Gibson", Opis = "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", MusicShopId = 1, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 6, Model = "RG", Proizvodjac = "Ibanez", Opis = "Visokoperformansna električna gitara popularna među rok i metal sviračima.", MusicShopId = 2, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 7, Model = "Custom 24", Proizvodjac = "PRS", Opis = "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 8, Model = "Pacifica", Proizvodjac = "Yamaha", Opis = "Svestrana električna gitara pogodna za različite žanrove.", MusicShopId = 2, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 9, Model = "Dinky", Proizvodjac = "Jackson", Opis = "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", MusicShopId = 1, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 10, Model = "C-1", Proizvodjac = "Schecter", Opis = "Električna gitara poznata po svojoj čvrstoj izradi i teškim tonovima.", MusicShopId = 2, VrstaInstrumentaId = 1 },

               new Instrumenti { Id = 11, Model = "Precision Bass", Proizvodjac = "Fender", Opis = "Industrijski standard bas gitara poznata po dubokom, udarnom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 12, Model = "SR", Proizvodjac = "Ibanez", Opis = "Elegantna bas gitara popularna zbog svog brzog vrata i svestranih tonova.", MusicShopId = 2, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 13, Model = "Thunderbird", Proizvodjac = "Gibson", Opis = "Ikonična bas gitara poznata po jedinstvenom dizajnu i snažnom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 14, Model = "BB", Proizvodjac = "Yamaha", Opis = "Pouzdana bas gitara sa velikim balansom svirljivosti i tona.", MusicShopId = 2, VrstaInstrumentaId = 1 },
               new Instrumenti { Id = 15, Model = "RockBass", Proizvodjac = "Warwick", Opis = "Bas gitara poznata po svom jedinstvenom 'growl' tonu i ergonomskoj izradi.", MusicShopId = 1, VrstaInstrumentaId = 1 },

               new Instrumenti { Id = 16, Model = "Export", Proizvodjac = "Pearl", Opis = "Pristupačan bubanj set savršen za početnike i srednje napredne bubnjare.", MusicShopId = 2, VrstaInstrumentaId = 3 },
               new Instrumenti { Id = 17, Model = "Imperialstar", Proizvodjac = "Tama", Opis = "Svestran bubanj set sa izvrsnom izradom i zvukom.", MusicShopId = 1, VrstaInstrumentaId = 3 },
               new Instrumenti { Id = 18, Model = "Breakbeats", Proizvodjac = "Ludwig", Opis = "Kompaktni bubanj set dizajniran za prenosivost i odličan ton.", MusicShopId = 2, VrstaInstrumentaId = 3 },

               new Instrumenti { Id = 19, Model = "Mark VI", Proizvodjac = "Selmer", Opis = "Legendarni saksofon poznat po izvrsnom tonu i svirljivosti.", MusicShopId = 1, VrstaInstrumentaId = 2 },
               new Instrumenti { Id = 20, Model = "YAS-280", Proizvodjac = "Yamaha", Opis = "Popularni saksofon među studentima i srednje naprednim sviračima.", MusicShopId = 2, VrstaInstrumentaId = 2 },

               new Instrumenti { Id = 21, Model = "Minilogue", Proizvodjac = "Korg", Opis = "Analogni sintisajzer poznat po svom bogatom, toplom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 4 },
               new Instrumenti { Id = 22, Model = "Juno-DS", Proizvodjac = "Roland", Opis = "Svestrani sintisajzer popularan za žive nastupe i studijsku upotrebu.", MusicShopId = 2, VrstaInstrumentaId = 4 },
               new Instrumenti { Id = 23, Model = "Sub Phatty", Proizvodjac = "Moog", Opis = "Analogni sintisajzer poznat po svom snažnom basu i lead tonovima.", MusicShopId = 1, VrstaInstrumentaId = 4 },

               new Instrumenti { Id = 24, Model = "Stradivarius", Proizvodjac = "Bach", Opis = "Profesionalni trombon poznat po bogatom tonu i preciznoj intonaciji.", MusicShopId = 1, VrstaInstrumentaId = 2 },
               new Instrumenti { Id = 25, Model = "YSL-354", Proizvodjac = "Yamaha", Opis = "Studentski trombon poznat po svojoj izdržljivosti i lakoći sviranja.", MusicShopId = 2, VrstaInstrumentaId = 2 }
            );
        }              
    }
}
