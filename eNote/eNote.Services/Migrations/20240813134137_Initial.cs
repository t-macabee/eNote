using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eNote.Services.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Broj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uloga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AdresaId = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SlikaThumb = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uloga = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AdresaId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SlikaThumb = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicShops_Adresa_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivoTezine = table.Column<int>(type: "int", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojPolaznika = table.Column<int>(type: "int", nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CijenaPretplata = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DostupanNaPretplati = table.Column<bool>(type: "bit", nullable: false),
                    InstruktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurs_Korisnici_InstruktorId",
                        column: x => x.InstruktorId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OglasnaTabla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVrijemePostavljanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasnaTabla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OglasnaTabla_Korisnici_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instrumenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proizvodjac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SlikaThumb = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    VrstaInstrumenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrumenti_MusicShops_MusicShopId",
                        column: x => x.MusicShopId,
                        principalTable: "MusicShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predavanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVrijemePredavanja = table.Column<DateOnly>(type: "date", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predavanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predavanja_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upisi_Korisnici_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Upisi_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IznajmljivanjeInstrumenata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIznajmljivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPovratka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vracen = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    InstrumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IznajmljivanjeInstrumenata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IznajmljivanjeInstrumenata_Instrumenti_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrumenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IznajmljivanjeInstrumenata_Korisnici_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obavijesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVrijemePostavljanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredavanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijesti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obavijesti_Predavanja_PredavanjeId",
                        column: x => x.PredavanjeId,
                        principalTable: "Predavanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prisustva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotvrdaPrisustva = table.Column<bool>(type: "bit", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PredavanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisustva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prisustva_Korisnici_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prisustva_Predavanja_PredavanjeId",
                        column: x => x.PredavanjeId,
                        principalTable: "Predavanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zadaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVrijemePredaje = table.Column<DateOnly>(type: "date", nullable: false),
                    PredavanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadaci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zadaci_Predavanja_PredavanjeId",
                        column: x => x.PredavanjeId,
                        principalTable: "Predavanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredajaZadatka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumVrijemePredaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: true),
                    ZadatakId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredajaZadatka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredajaZadatka_Korisnici_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredajaZadatka_Zadaci_ZadatakId",
                        column: x => x.ZadatakId,
                        principalTable: "Zadaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresa",
                columns: new[] { "Id", "Broj", "Grad", "Ulica" },
                values: new object[,]
                {
                    { 1, "12", "Sarajevo", "Bistrik" },
                    { 2, "15", "Sarajevo", "Maršala Tita" },
                    { 3, "8", "Sarajevo", "Mula Mustafe Bašeskije" },
                    { 4, "18", "Sarajevo", "Obala Kulina bana" },
                    { 5, "14", "Sarajevo", "Veliki Alifakovac" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "AdresaId", "DatumRodjenja", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Slika", "SlikaThumb", "Status", "Telefon", "Uloga" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1996, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@outlook.com", "Admin", "admin", "apUAvneoRL2OT7O9DYT4BPqZybhAcKE7TxDQuN2XvfQ=", "6FIBOc9Gbg4aSFJaUeBF0w==", "Admin", null, null, true, "000000000", "Administrator" },
                    { 2, 4, new DateTime(1997, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@outlook.com", "John", "instruktor", "iD/HUccx7syVd8JV+yT81KQ0ZeQ+ladOetnOe8utEjk=", "2runk12c8K4jOZks8zJCgw==", "Doe", null, null, true, "111111111", "Instruktor" },
                    { 3, 5, new DateTime(1967, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.doe@outlook.com", "Jane", "polaznik", "LR1+D12KrBdSWd/SUBLyxbf5PxNyMLeAe2sBOCv8nlk=", "R9pIQrTfJASNradYBYT7KQ==", "Doe", null, null, true, "222222222", "Polaznik" }
                });

            migrationBuilder.InsertData(
                table: "MusicShops",
                columns: new[] { "Id", "AdresaId", "Email", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Naziv", "Slika", "SlikaThumb", "Status", "Telefon", "Uloga" },
                values: new object[] { 1, 2, "shop1@outlook.com", "shop1", "8SSvWRSIaXR0ogeftoi7ITcZuX2RJSN4o3wBp0cliXY=", "2q2qEnMTMIdHxK6490Dz1g==", "Bonemeal Music Shop", null, null, true, "333333333", 4 });

            migrationBuilder.InsertData(
                table: "Instrumenti",
                columns: new[] { "Id", "Model", "MusicShopId", "Opis", "Proizvodjac", "Slika", "SlikaThumb", "VrstaInstrumenta" },
                values: new object[,]
                {
                    { 1, "J-45", 1, "Ikonična akustična gitara poznata po bogatom, punom zvuku.", "Gibson", null, null, "Žičani" },
                    { 2, "214ce", 1, "Popularna grand auditorium akustična gitara sa svijetlim, jasnim tonom.", "Taylor", null, null, "Žičani" },
                    { 3, "CD-60S", 1, "Pristupačna akustična gitara savršena za početnike i srednje napredne svirače.", "Fender", null, null, "Žičani" },
                    { 4, "Stratocaster", 1, "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", "Fender", null, null, "Žičani" },
                    { 5, "Les Paul", 1, "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", "Gibson", null, null, "Žičani" },
                    { 6, "RG", 1, "Visokoperformansna električna gitara popularna među rok i metal sviračima.", "Ibanez", null, null, "Žičani" },
                    { 7, "Custom 24", 1, "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", "PRS", null, null, "Žičani" },
                    { 8, "Pacifica", 1, "Svestrana električna gitara pogodna za različite žanrove.", "Yamaha", null, null, "Žičani" },
                    { 9, "Dinky", 1, "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", "Jackson", null, null, "Žičani" },
                    { 10, "C-1", 1, "Električna gitara poznata po svojoj čvrstoj izradi i teškim tonovima.", "Schecter", null, null, "Žičani" },
                    { 11, "Precision Bass", 1, "Industrijski standard bas gitara poznata po dubokom, udarnom zvuku.", "Fender", null, null, "Žičani" },
                    { 12, "SR", 1, "Elegantna bas gitara popularna zbog svog brzog vrata i svestranih tonova.", "Ibanez", null, null, "Žičani" },
                    { 13, "Thunderbird", 1, "Ikonična bas gitara poznata po jedinstvenom dizajnu i snažnom zvuku.", "Gibson", null, null, "Žičani" },
                    { 14, "BB", 1, "Pouzdana bas gitara sa velikim balansom svirljivosti i tona.", "Yamaha", null, null, "Žičani" },
                    { 15, "RockBass", 1, "Bas gitara poznata po svom jedinstvenom 'growl' tonu i ergonomskoj izradi.", "Warwick", null, null, "Žičani" },
                    { 16, "Export", 1, "Pristupačan bubanj set savršen za početnike i srednje napredne bubnjare.", "Pearl", null, null, "Udaraljke" },
                    { 17, "Imperialstar", 1, "Svestran bubanj set sa izvrsnom izradom i zvukom.", "Tama", null, null, "Udaraljke" },
                    { 18, "Breakbeats", 1, "Kompaktni bubanj set dizajniran za prenosivost i odličan ton.", "Ludwig", null, null, "Udaraljke" },
                    { 19, "Mark VI", 1, "Legendarni saksofon poznat po izvrsnom tonu i svirljivosti.", "Selmer", null, null, "Limeni" },
                    { 20, "YAS-280", 1, "Popularni saksofon među studentima i srednje naprednim sviračima.", "Yamaha", null, null, "Limeni" },
                    { 21, "Minilogue", 1, "Analogni sintisajzer poznat po svom bogatom, toplom zvuku.", "Korg", null, null, "Tipke" },
                    { 22, "Juno-DS", 1, "Svestrani sintisajzer popularan za žive nastupe i studijsku upotrebu.", "Roland", null, null, "Tipke" },
                    { 23, "Sub Phatty", 1, "Analogni sintisajzer poznat po svom snažnom basu i lead tonovima.", "Moog", null, null, "Tipke" },
                    { 24, "Stradivarius", 1, "Profesionalni trombon poznat po bogatom tonu i preciznoj intonaciji.", "Bach", null, null, "Limeni" },
                    { 25, "YSL-354", 1, "Studentski trombon poznat po svojoj izdržljivosti i lakoći sviranja.", "Yamaha", null, null, "Limeni" }
                });

            migrationBuilder.InsertData(
                table: "Kurs",
                columns: new[] { "Id", "BrojPolaznika", "Cijena", "CijenaPretplata", "DatumPocetka", "DatumZavrsetka", "DostupanNaPretplati", "InstruktorId", "Naziv", "NivoTezine", "Opis" },
                values: new object[,]
                {
                    { 1, 10, 800m, 50m, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "Osnove teorije muzike", 1, "Testni opis kursa osnova teorije muzke." },
                    { 2, 10, 800m, 50m, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "Napredne tehnike gitare", 3, "Otkrijte napredne tehnike gitare, uključujući kompleksne akorde, improvizaciju i solo sviranje, kako biste unaprijedili svoje vještine i kreativnost na gitari." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrumenti_MusicShopId",
                table: "Instrumenti",
                column: "MusicShopId");

            migrationBuilder.CreateIndex(
                name: "IX_IznajmljivanjeInstrumenata_InstrumentId",
                table: "IznajmljivanjeInstrumenata",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_IznajmljivanjeInstrumenata_StudentId",
                table: "IznajmljivanjeInstrumenata",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_AdresaId",
                table: "Korisnici",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurs_InstruktorId",
                table: "Kurs",
                column: "InstruktorId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicShops_AdresaId",
                table: "MusicShops",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijesti_PredavanjeId",
                table: "Obavijesti",
                column: "PredavanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasnaTabla_AutorId",
                table: "OglasnaTabla",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_PredajaZadatka_StudentId",
                table: "PredajaZadatka",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PredajaZadatka_ZadatakId",
                table: "PredajaZadatka",
                column: "ZadatakId");

            migrationBuilder.CreateIndex(
                name: "IX_Predavanja_KursId",
                table: "Predavanja",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisustva_PredavanjeId",
                table: "Prisustva",
                column: "PredavanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisustva_StudentId",
                table: "Prisustva",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Upisi_KursId",
                table: "Upisi",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Upisi_StudentId",
                table: "Upisi",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_PredavanjeId",
                table: "Zadaci",
                column: "PredavanjeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IznajmljivanjeInstrumenata");

            migrationBuilder.DropTable(
                name: "Obavijesti");

            migrationBuilder.DropTable(
                name: "OglasnaTabla");

            migrationBuilder.DropTable(
                name: "PredajaZadatka");

            migrationBuilder.DropTable(
                name: "Prisustva");

            migrationBuilder.DropTable(
                name: "Upisi");

            migrationBuilder.DropTable(
                name: "Instrumenti");

            migrationBuilder.DropTable(
                name: "Zadaci");

            migrationBuilder.DropTable(
                name: "MusicShops");

            migrationBuilder.DropTable(
                name: "Predavanja");

            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Adresa");
        }
    }
}
