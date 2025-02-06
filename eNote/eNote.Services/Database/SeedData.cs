using eNote.Model.Enums;
using eNote.Services.Database.Entities;
using eNote.Services.Utilities;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Database
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedAddresses(modelBuilder);
            SeedInstrumentTypes(modelBuilder);
            SeedUsers(modelBuilder);
            SeedCourses(modelBuilder);
            SeedClasses(modelBuilder);
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

        public static void SeedInstrumentTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VrstaInstrumenta>().HasData(
                new VrstaInstrumenta { Id = 1, Naziv = "žicani" },
                new VrstaInstrumenta { Id = 2, Naziv = "Udaraljke" },
                new VrstaInstrumenta { Id = 3, Naziv = "Limeni" },
                new VrstaInstrumenta { Id = 4, Naziv = "Tipke" },
                new VrstaInstrumenta { Id = 5, Naziv = "Dodatna oprema" }
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

            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { Id = 1, KorisnickoIme = "admin", Email = "admin@outlook.com", BrojTelefona = "000000000", LozinkaHash = adminHash, LozinkaSalt = adminSalt, Uloga = KorisnikUloga.Administrator, AdresaId = 1, Status = true, Slika = ImageToByteArray("user.webp") }                                
            );

            modelBuilder.Entity<Instruktor>().HasData(
                new Instruktor { Id = 1, KorisnickoIme = "instruktor", Email = "john.doe@outlook.com", BrojTelefona = "111111111", LozinkaHash = instruktorHash, LozinkaSalt = instruktorSalt, Uloga = KorisnikUloga.Instruktor, AdresaId = 4, Ime = "John", Prezime = "Doe", DatumRodjenja = new DateTime(1997, 06, 15), Status = true, Slika = ImageToByteArray("user.webp") }
            );

            modelBuilder.Entity<Polaznik>().HasData(
                new Polaznik { Id = 1, KorisnickoIme = "polaznik", Email = "jane.doe@outlook.com", BrojTelefona = "222222222", LozinkaHash = ucenikHash, LozinkaSalt = ucenikSalt, Uloga = KorisnikUloga.Polaznik, AdresaId = 5, Ime = "Jane", Prezime = "Doe", DatumRodjenja = new DateTime(1967, 03, 17), Status = true, Slika = ImageToByteArray("user.webp") }
            );

            modelBuilder.Entity<MusicShop>().HasData(
                 new MusicShop { Id = 1, KorisnickoIme = "shop1", Email = "shop1@outlook.com", BrojTelefona = "333333333", LozinkaHash = musicShopHash, LozinkaSalt = musicShopSalt, Uloga = KorisnikUloga.MusicShop, AdresaId = 2, Naziv = "Bonemeal Music Shop", RadnoVrijeme = "Ponedjeljak - Petak: 9:00 - 16:00", Status = true, Slika = ImageToByteArray("user.webp") }
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
                    InstruktorId = 1
                },

                new Kurs
                {
                    Id = 2,
                    Naziv = "Napredne tehnike gitare",
                    Opis = "Otkrijte napredne tehnike gitare, uključujući kompleksne akorde, improvizaciju i solo sviranje, kako biste unaprijedili svoje vještine i kreativnost na gitari.",
                    DatumPocetka = new DateTime(2024, 09, 12),
                    DatumZavrsetka = new DateTime(2024, 10, 12),
                    Cijena = 800,
                    InstruktorId = 1
                }
            );
        }

        public static void SeedClasses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Predavanje>().HasData(
                new Predavanje
                {
                    Id = 1,
                    Naziv = "Uvodno predavanje",
                    Lokacija = "Amfiteatar gradskog BKC-a",
                    TrajanjeMinute = 90,
                    DatumVrijemePredavanja = new DateTime(2024, 08, 11, 19, 30, 00),
                    KursId = 1,
                    PredavanjeTip = PredavanjeTip.Teorijsko,
                    PredavanjeStatus = PredavanjeStatus.Zakazano
                },

                 new Predavanje
                 {
                     Id = 2,
                     Naziv = "Uvodno predavanje",
                     Lokacija = "Amfiteatar gradskog BKC-a",
                     DatumVrijemePredavanja = new DateTime(2024, 08, 19, 19, 30, 00),
                     TrajanjeMinute = 60,
                     KursId = 2,
                     PredavanjeTip = PredavanjeTip.Prakticno,
                     PredavanjeStatus = PredavanjeStatus.Zakazano
                 }
            );
        }

        public static void SeedInstruments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrumenti>().HasData(
               new Instrumenti { Id = 1, Model = "Stratocaster", Proizvodjac = "Fender", Opis = "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("strat.webp") },
               new Instrumenti { Id = 2, Model = "Les Paul", Proizvodjac = "Gibson", Opis = "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("les-paul.webp") },
               new Instrumenti { Id = 3, Model = "RG", Proizvodjac = "Ibanez", Opis = "Visokoperformansna električna gitara popularna među rok i metal sviračima.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("rg.webp") },
               new Instrumenti { Id = 4, Model = "Custom 24", Proizvodjac = "PRS", Opis = "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("prs.webp") },
               new Instrumenti { Id = 5, Model = "Pacifica", Proizvodjac = "Yamaha", Opis = "Svestrana električna gitara pogodna za različite žanrove.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("pacifica.webp") },
               new Instrumenti { Id = 6, Model = "Dinky", Proizvodjac = "Jackson", Opis = "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("dinky.webp") },

               new Instrumenti { Id = 7, Model = "214ce", Proizvodjac = "Taylor", Opis = "Svestrana i lijepo izrađena akustična gitara, poznata po svom svijetlom i artikulisanom tonu.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("214ce.webp") },
               new Instrumenti { Id = 8, Model = "D-28", Proizvodjac = "Martin", Opis = "Ikonična dreadnought gitara sa bogatom historijom, poznata po svom dubokom, rezonantnom basu i jasnim visokim tonovima.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("d-28.webp") },
               new Instrumenti { Id = 9, Model = "J-45", Proizvodjac = "Gibson", Opis = "esto nazivan \"radnim konjem\" među akustičnim gitarama, ovaj dreadnought sa zaobljenim ramenima pruža topao, blag ton koji je savršen za kantautore.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("j-45.webp") },
               new Instrumenti { Id = 10, Model = "S6", Proizvodjac = "Seagull", Opis = "S6 proizvodi topao, bogat zvuk sa blago rustičnim karakterom, što je čini omiljenom među muzičarima koji sviraju folk i roots muziku.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("s6.webp") },

               new Instrumenti { Id = 11, Model = "Precision Bass", Proizvodjac = "Fender", Opis = "Industrijski standard bas gitara poznata po dubokom, udarnom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("precision.webp") },
               new Instrumenti { Id = 12, Model = "Thunderbird", Proizvodjac = "Gibson", Opis = "Ikonična bas gitara poznata po jedinstvenom dizajnu i snažnom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("thunderbird.webp") },
               new Instrumenti { Id = 13, Model = "StingRay", Proizvodjac = "Music Man", Opis = "Legendarna električna bas gitara, prepoznatljiva po svom moćnom, artikulisanom zvuku, elegantnom dizajnu i vrhunskoj svirljivosti.", MusicShopId = 1, VrstaInstrumentaId = 1, Dostupan = true, Slika = ImageToByteArray("stingray.webp") },

               new Instrumenti { Id = 14, Model = "Export", Proizvodjac = "Pearl", Opis = "Pristupačan bubanj set savršen za početnike i srednje napredne bubnjare.", MusicShopId = 1, VrstaInstrumentaId = 2, Dostupan = true, Slika = ImageToByteArray("export.webp") },
               new Instrumenti { Id = 15, Model = "Imperialstar", Proizvodjac = "Tama", Opis = "Svestran bubanj set sa izvrsnom izradom i zvukom.", MusicShopId = 1, VrstaInstrumentaId = 2, Dostupan = true, Slika = ImageToByteArray("imperialstar.webp") },
               new Instrumenti { Id = 16, Model = "Breakbeats", Proizvodjac = "Ludwig", Opis = "Kompaktni bubanj set dizajniran za prenosivost i odličan ton.", MusicShopId = 1, VrstaInstrumentaId = 2, Dostupan = true, Slika = ImageToByteArray("breakbeats.webp") },

               new Instrumenti { Id = 17, Model = "YAS-280", Proizvodjac = "Yamaha", Opis = "Popularni saksofon među studentima i srednje naprednim sviračima.", MusicShopId = 1, VrstaInstrumentaId = 3, Dostupan = true, Slika = ImageToByteArray("yas.webp") },
               new Instrumenti { Id = 18, Model = "Stradivarius", Proizvodjac = "Bach", Opis = "Profesionalni trombon poznat po bogatom tonu i preciznoj intonaciji.", MusicShopId = 1, VrstaInstrumentaId = 3, Dostupan = true, Slika = ImageToByteArray("stradivarius.webp") },

               new Instrumenti { Id = 19, Model = "Minilogue", Proizvodjac = "Korg", Opis = "Analogni sintisajzer poznat po svom bogatom, toplom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 4, Dostupan = true, Slika = ImageToByteArray("minilogue.webp") },
               new Instrumenti { Id = 20, Model = "Juno-DS", Proizvodjac = "Roland", Opis = "Svestrani sintisajzer popularan za žive nastupe i studijsku upotrebu.", MusicShopId = 1, VrstaInstrumentaId = 4, Dostupan = true, Slika = ImageToByteArray("juno-ds.webp") },

               new Instrumenti { Id = 21, Model = "Blues Junior IV", Proizvodjac = "Fender", Opis = "Kompaktno, ali snažno cijevno pojačalo koje pruža klasičan Fender ton sa dodanom modernom svestranošću.", MusicShopId = 1, VrstaInstrumentaId = 5, Dostupan = true, Slika = ImageToByteArray("blues-junior.webp") },
               new Instrumenti { Id = 22, Model = "DSL40CR-DS", Proizvodjac = "Marshall", Opis = "Vrlo svestrano cijevno pojačalo koje nudi sve, od klasične rock distorzije do žestokih solaža.", MusicShopId = 1, VrstaInstrumentaId = 5, Dostupan = true, Slika = ImageToByteArray("dsl40cr.webp") },
               new Instrumenti { Id = 23, Model = "AC15C1", Proizvodjac = "Vox", Opis = "Poznato po svojim svijetlim čistim tonovima i karakterističnom \"Top Boost\" overdrive efektu, savršeno je za one koji traže vintage britanski zvuk.", MusicShopId = 1, VrstaInstrumentaId = 5, Dostupan = true, Slika = ImageToByteArray("ac15c1.webp") },
               new Instrumenti { Id = 24, Model = "Rocker 15", Proizvodjac = "Orange", Opis = "Idealno je za kućne probe i manje nastupe, nudeći niz tonova od čistog do prljavog sa jednostavnim i preglednim kontrolama.", MusicShopId = 1, VrstaInstrumentaId = 5, Dostupan = true, Slika = ImageToByteArray("rocker-15.webp") },
               new Instrumenti { Id = 25, Model = "Katana-100 MkII", Proizvodjac = "Boss", Opis = "Moderno digitalno pojačalo koje kombinuje veliku snagu sa nevjerovatnom svestranošću.", MusicShopId = 1, VrstaInstrumentaId = 5, Dostupan = true, Slika = ImageToByteArray("katana-100.webp") }
            );
        }

        private static byte[] ImageToByteArray(string imagePath)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string wwwRootPath = Path.Combine(currentDirectory, "wwwroot");
            string fullImagePath = Path.Combine(wwwRootPath, imagePath);

            try
            {
                if (File.Exists(fullImagePath))
                {
                    return File.ReadAllBytes(fullImagePath);
                }
                else
                {
                    Console.WriteLine($"Image file not found: {fullImagePath}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading image file: {ex.Message}");
                return null;
            }
        }
    }
}
