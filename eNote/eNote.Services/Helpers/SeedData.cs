using eNote.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eNote.Services.Helpers
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uloge>().HasData(
                new Uloge { Id = 1, Naziv = "Administrator" },
                new Uloge { Id = 2, Naziv = "Instruktor" },
                new Uloge { Id = 3, Naziv = "Učenik" }
            );

            modelBuilder.Entity<VrstaInstrumenta>().HasData(
                new VrstaInstrumenta { Id = 1, Naziv = "Žičani instrument" },                
                new VrstaInstrumenta { Id = 2, Naziv = "Limeni instrument" },
                new VrstaInstrumenta { Id = 3, Naziv = "Udaraljke" },
                new VrstaInstrumenta { Id = 4, Naziv = "Instrument s tipkama"},
                new VrstaInstrumenta { Id = 5, Naziv = "Elektronički instrumenti" }
            );

            modelBuilder.Entity<MusicShop>().HasData(
                new MusicShop { Id = 1, Naziv = "Bonemeal Music Shop", Adresa = "Ferhadija 15, Sarajevo" },
                new MusicShop { Id = 2, Naziv = "Harmonia Music Store", Adresa = "Maršala Tita 45, Sarajevo" }
            );

            modelBuilder.Entity<Instrumenti>().HasData(                
                new Instrumenti { Id = 1, Model = "J-45", Proizvodjac = "Gibson", Opis = "Ikonična akustična gitara poznata po bogatom, punom zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1 },
                new Instrumenti { Id = 2, Model = "214ce", Proizvodjac = "Taylor", Opis = "Popularna grand auditorium akustična gitara sa svijetlim, jasnim tonom.", MusicShopId = 2, VrstaInstrumentaId = 1 },
                new Instrumenti { Id = 3, Model = "CD-60S", Proizvodjac = "Fender", Opis = "Pristupačna akustična gitara savršena za početnike i srednje napredne svirače.", MusicShopId = 1, VrstaInstrumentaId = 1 },
                
                new Instrumenti { Id = 4,  Model = "Stratocaster", Proizvodjac = "Fender", Opis = "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", MusicShopId = 2, VrstaInstrumentaId = 1 },
                new Instrumenti { Id = 5,  Model = "Les Paul", Proizvodjac = "Gibson", Opis = "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", MusicShopId = 1, VrstaInstrumentaId = 1 },
                new Instrumenti { Id = 6,  Model = "RG", Proizvodjac = "Ibanez", Opis = "Visokoperformansna električna gitara popularna među rok i metal sviračima.", MusicShopId = 2, VrstaInstrumentaId = 1 },
                new Instrumenti { Id = 7,  Model = "Custom 24", Proizvodjac = "PRS", Opis = "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", MusicShopId = 1, VrstaInstrumentaId = 1 },
                new Instrumenti { Id = 8,  Model = "Pacifica", Proizvodjac = "Yamaha", Opis = "Svestrana električna gitara pogodna za različite žanrove.", MusicShopId = 2, VrstaInstrumentaId = 1 },
                new Instrumenti { Id = 9,  Model = "Dinky", Proizvodjac = "Jackson", Opis = "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", MusicShopId = 1, VrstaInstrumentaId = 1 },
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
