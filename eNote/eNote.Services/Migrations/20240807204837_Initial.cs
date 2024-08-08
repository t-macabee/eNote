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
                    AdresaId = table.Column<int>(type: "int", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    VrstaInstrumentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrumenti_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instrumenti_VrstaInstrumenta_VrstaInstrumentaId",
                        column: x => x.VrstaInstrumentaId,
                        principalTable: "VrstaInstrumenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstruktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kursevi_Korisnici_InstruktorId",
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
                    DatumPostavljanja = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "IznajmljivanjeInstrumenata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIznajmljivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVracanja = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Predavanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vrijeme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predavanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predavanja_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
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
                        name: "FK_Upisi_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijesti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPostavljanja = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    RokPredaje = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    DatumPredaje = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                table: "Uloge",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Instruktor" },
                    { 3, "Ucenik" },
                    { 4, "Shop" }
                });

            migrationBuilder.InsertData(
                table: "VrstaInstrumenta",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Žičani" },
                    { 2, "Limeni" },
                    { 3, "Udaraljke" },
                    { 4, "Instrument s tipkama" },
                    { 5, "Elektronički" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "AdresaId", "DatumRodjenja", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Naziv", "Prezime", "Slika", "SlikaThumb", "Telefon", "UlogaId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 7, 22, 48, 37, 330, DateTimeKind.Local).AddTicks(3716), "admin@outlook.com", "Admin", "admin", "S6Am/GcIgLEOSKRYuJAzx7jQRj3pXksuWVntHs8y2ZY=", "K9Hjw25QuUR3P9wObLihwA==", null, "Admin", null, null, "000000000", 1 },
                    { 2, 4, new DateTime(2024, 8, 7, 22, 48, 37, 330, DateTimeKind.Local).AddTicks(3770), "john.doe@outlook.com", "John", "instruktor", "BvBeZLNQQAzSxjyYJW5W7uM8pcGoVRZ7c7iOkrmkDf0=", "f0ExeVY0OkIBTaJmGPjqAA==", null, "Doe", null, null, "111111111", 2 },
                    { 3, 5, new DateTime(2024, 8, 7, 22, 48, 37, 330, DateTimeKind.Local).AddTicks(3773), "jane.doe@outlook.com", "Jane", "ucenik", "/rQuT6ol5/8TkO0Lg+1l2r1s1sJBJqVZYqK9OWa7hzE=", "5Vv5tyi0K4w14VmNjRABMQ==", null, "Doe", null, null, "222222222", 3 },
                    { 4, 2, null, "shop1@outlook.com", null, "shop1", "Ay+AGhg0jOgLvjFBuXQygID52VajzLW/AsqQXWFJsKQ=", "E+thHmY6wnvabOvXdOcALg==", "Bonemeal Music Shop", null, null, null, "333333333", 4 }
                });

            migrationBuilder.InsertData(
                table: "Instrumenti",
                columns: new[] { "Id", "KorisnikId", "Model", "Opis", "Proizvodjac", "Slika", "SlikaThumb", "VrstaInstrumentaId" },
                values: new object[,]
                {
                    { 1, 4, "J-45", "Ikonična akustična gitara poznata po bogatom, punom zvuku.", "Gibson", null, null, 1 },
                    { 2, 4, "214ce", "Popularna grand auditorium akustična gitara sa svijetlim, jasnim tonom.", "Taylor", null, null, 1 },
                    { 3, 4, "CD-60S", "Pristupačna akustična gitara savršena za početnike i srednje napredne svirače.", "Fender", null, null, 1 },
                    { 4, 4, "Stratocaster", "Klasična električna gitara poznata po svojoj svestranosti i glatkoj svirljivosti.", "Fender", null, null, 1 },
                    { 5, 4, "Les Paul", "Legendarna električna gitara omiljena zbog bogatog tona i održavanja.", "Gibson", null, null, 1 },
                    { 6, 4, "RG", "Visokoperformansna električna gitara popularna među rok i metal sviračima.", "Ibanez", null, null, 1 },
                    { 7, 4, "Custom 24", "Visokokvalitetna električna gitara poznata po svojoj prelijepoj izradi i zvuku.", "PRS", null, null, 1 },
                    { 8, 4, "Pacifica", "Svestrana električna gitara pogodna za različite žanrove.", "Yamaha", null, null, 1 },
                    { 9, 4, "Dinky", "Električna gitara dizajnirana za brzo sviranje i snažan zvuk.", "Jackson", null, null, 1 },
                    { 10, 4, "C-1", "Električna gitara poznata po svojoj čvrstoj izradi i teškim tonovima.", "Schecter", null, null, 1 },
                    { 11, 4, "Precision Bass", "Industrijski standard bas gitara poznata po dubokom, udarnom zvuku.", "Fender", null, null, 1 },
                    { 12, 4, "SR", "Elegantna bas gitara popularna zbog svog brzog vrata i svestranih tonova.", "Ibanez", null, null, 1 },
                    { 13, 4, "Thunderbird", "Ikonična bas gitara poznata po jedinstvenom dizajnu i snažnom zvuku.", "Gibson", null, null, 1 },
                    { 14, 4, "BB", "Pouzdana bas gitara sa velikim balansom svirljivosti i tona.", "Yamaha", null, null, 1 },
                    { 15, 4, "RockBass", "Bas gitara poznata po svom jedinstvenom 'growl' tonu i ergonomskoj izradi.", "Warwick", null, null, 1 },
                    { 16, 4, "Export", "Pristupačan bubanj set savršen za početnike i srednje napredne bubnjare.", "Pearl", null, null, 3 },
                    { 17, 4, "Imperialstar", "Svestran bubanj set sa izvrsnom izradom i zvukom.", "Tama", null, null, 3 },
                    { 18, 4, "Breakbeats", "Kompaktni bubanj set dizajniran za prenosivost i odličan ton.", "Ludwig", null, null, 3 },
                    { 19, 4, "Mark VI", "Legendarni saksofon poznat po izvrsnom tonu i svirljivosti.", "Selmer", null, null, 2 },
                    { 20, 4, "YAS-280", "Popularni saksofon među studentima i srednje naprednim sviračima.", "Yamaha", null, null, 2 },
                    { 21, 4, "Minilogue", "Analogni sintisajzer poznat po svom bogatom, toplom zvuku.", "Korg", null, null, 4 },
                    { 22, 4, "Juno-DS", "Svestrani sintisajzer popularan za žive nastupe i studijsku upotrebu.", "Roland", null, null, 4 },
                    { 23, 4, "Sub Phatty", "Analogni sintisajzer poznat po svom snažnom basu i lead tonovima.", "Moog", null, null, 4 },
                    { 24, 4, "Stradivarius", "Profesionalni trombon poznat po bogatom tonu i preciznoj intonaciji.", "Bach", null, null, 2 },
                    { 25, 4, "YSL-354", "Studentski trombon poznat po svojoj izdržljivosti i lakoći sviranja.", "Yamaha", null, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrumenti_KorisnikId",
                table: "Instrumenti",
                column: "KorisnikId");

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
                name: "IX_Kursevi_InstruktorId",
                table: "Kursevi",
                column: "InstruktorId");

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
                name: "VrstaInstrumenta");

            migrationBuilder.DropTable(
                name: "Predavanja");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Uloge");
        }
    }
}
