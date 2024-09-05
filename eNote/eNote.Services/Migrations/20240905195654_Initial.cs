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
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaInstrumenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaInstrumenta", x => x.Id);
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
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Korisnici_Uloge_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
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
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_MusicShops_Uloge_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
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
                    Cijena = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    BrojUpisanih = table.Column<int>(type: "int", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Dostupan = table.Column<bool>(type: "bit", nullable: false),
                    VrstaInstrumentaId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Instrumenti_VrstaInstrumenta_VrstaInstrumentaId",
                        column: x => x.VrstaInstrumentaId,
                        principalTable: "VrstaInstrumenta",
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
                    DatumVrijemePredavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrajanjeMinute = table.Column<int>(type: "int", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    TipPredavanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StanjePredavanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    StanjeUpisa = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Upisi_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IznajmljivanjeInstrumenata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIznajmljivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPovratka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CijenaIznajmljivanja = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    StanjeIznajmljivanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                    DatumVrijemePredaje = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                table: "Uloge",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Instruktor" },
                    { 3, "Polaznik" },
                    { 4, "Shop" }
                });

            migrationBuilder.InsertData(
                table: "VrstaInstrumenta",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Zicani" },
                    { 2, "Udaraljke" },
                    { 3, "Limeni" },
                    { 4, "Tipke" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "AdresaId", "DatumRodjenja", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Slika", "SlikaThumb", "Status", "Telefon", "UlogaId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1996, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@outlook.com", "Admin", "admin", "WKTfkbdGWV1pTiu38dMWepmAJGklzxrsWJtdwn0RlAk=", "O6p/En0PA0iT0lRGDe2LtQ==", "Admin", null, null, true, "000000000", 1 },
                    { 2, 4, new DateTime(1997, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@outlook.com", "John", "instruktor", "Kcsd0uSoaQjbx8U6l0U52ipNUzB2rmKOS55TuZbtgmY=", "tKD8q8f+GHfxp6Gs5SJ1wA==", "Doe", null, null, true, "111111111", 2 },
                    { 3, 5, new DateTime(1967, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.doe@outlook.com", "Jane", "polaznik", "CDOx+fhzWzr7wDExfgEAM32Ws7L93gH/vXqm8WPeK0I=", "y1WRZMZQ5bwExCHOmNY5QA==", "Doe", null, null, true, "222222222", 3 }
                });

            migrationBuilder.InsertData(
                table: "MusicShops",
                columns: new[] { "Id", "AdresaId", "Email", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Naziv", "Slika", "SlikaThumb", "Status", "Telefon", "UlogaId" },
                values: new object[] { 1, 2, "shop1@outlook.com", "shop1", "wg1ff1ZjQ2isUlT8snaHQm5a7GWJEa+x1M3YhSM5ZhU=", "GUTxMPnemBUcO9Hn/4kEYA==", "Bonemeal Music Shop", null, null, true, "333333333", 4 });

            migrationBuilder.InsertData(
                table: "Instrumenti",
                columns: new[] { "Id", "Dostupan", "Model", "MusicShopId", "Opis", "Proizvodjac", "Slika", "SlikaThumb", "VrstaInstrumentaId" },
                values: new object[,]
                {
                    { 1, true, "Stratocaster", 1, "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", "Fender", null, null, 1 },
                    { 2, true, "Les Paul", 1, "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", "Gibson", null, null, 1 },
                    { 3, true, "RG", 1, "Visokoperformansna električna gitara popularna među rok i metal sviračima.", "Ibanez", null, null, 1 },
                    { 4, true, "Custom 24", 1, "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", "PRS", null, null, 1 },
                    { 5, true, "Pacifica", 1, "Svestrana električna gitara pogodna za različite žanrove.", "Yamaha", null, null, 1 },
                    { 6, true, "Dinky", 1, "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", "Jackson", null, null, 1 },
                    { 7, true, "Precision Bass", 1, "Industrijski standard bas gitara poznata po dubokom, udarnom zvuku.", "Fender", null, null, 1 },
                    { 8, true, "Thunderbird", 1, "Ikonična bas gitara poznata po jedinstvenom dizajnu i snažnom zvuku.", "Gibson", null, null, 1 },
                    { 9, true, "Export", 1, "Pristupačan bubanj set savršen za početnike i srednje napredne bubnjare.", "Pearl", null, null, 2 },
                    { 10, true, "Imperialstar", 1, "Svestran bubanj set sa izvrsnom izradom i zvukom.", "Tama", null, null, 2 },
                    { 11, true, "Breakbeats", 1, "Kompaktni bubanj set dizajniran za prenosivost i odličan ton.", "Ludwig", null, null, 2 },
                    { 12, true, "Mark VI", 1, "Legendarni saksofon poznat po izvrsnom tonu i svirljivosti.", "Selmer", null, null, 3 },
                    { 13, true, "YAS-280", 1, "Popularni saksofon među studentima i srednje naprednim sviračima.", "Yamaha", null, null, 3 },
                    { 14, true, "Stradivarius", 1, "Profesionalni trombon poznat po bogatom tonu i preciznoj intonaciji.", "Bach", null, null, 3 },
                    { 15, true, "Minilogue", 1, "Analogni sintisajzer poznat po svom bogatom, toplom zvuku.", "Korg", null, null, 4 },
                    { 16, true, "Juno-DS", 1, "Svestrani sintisajzer popularan za žive nastupe i studijsku upotrebu.", "Roland", null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Kurs",
                columns: new[] { "Id", "BrojUpisanih", "Cijena", "DatumPocetka", "DatumZavrsetka", "InstruktorId", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, 0, 800m, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Osnove teorije muzike", "Testni opis kursa osnova teorije muzke." },
                    { 2, 0, 800m, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Napredne tehnike gitare", "Otkrijte napredne tehnike gitare, uključujući kompleksne akorde, improvizaciju i solo sviranje, kako biste unaprijedili svoje vještine i kreativnost na gitari." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrumenti_MusicShopId",
                table: "Instrumenti",
                column: "MusicShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumenti_VrstaInstrumentaId",
                table: "Instrumenti",
                column: "VrstaInstrumentaId");

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
                name: "IX_Korisnici_UlogaId",
                table: "Korisnici",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurs_InstruktorId",
                table: "Kurs",
                column: "InstruktorId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicShops_AdresaId",
                table: "MusicShops",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicShops_UlogaId",
                table: "MusicShops",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijesti_PredavanjeId",
                table: "Obavijesti",
                column: "PredavanjeId");

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
                name: "VrstaInstrumenta");

            migrationBuilder.DropTable(
                name: "Predavanja");

            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Uloge");
        }
    }
}
