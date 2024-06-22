﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eNote.Services.Database;

#nullable disable

namespace eNote.Services.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eNote.Services.Database.Instrumenti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MusicShopId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MusicShopId");

                    b.ToTable("Instrumenti");
                });

            modelBuilder.Entity("eNote.Services.Database.IznajmljivanjeInstrumenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIznajmljivanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumVracanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstrumentId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<bool>("Vracen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentId");

                    b.HasIndex("StudentId");

                    b.ToTable("IznajmljivanjeInstrumenata");
                });

            modelBuilder.Entity("eNote.Services.Database.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UlogaId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("eNote.Services.Database.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InstruktorId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstruktorId");

                    b.ToTable("Kursevi");
                });

            modelBuilder.Entity("eNote.Services.Database.MusicShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MusicShops");
                });

            modelBuilder.Entity("eNote.Services.Database.Obavijest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumPostavljanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredavanjeId")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PredavanjeId");

                    b.ToTable("Obavijesti");
                });

            modelBuilder.Entity("eNote.Services.Database.OglasnaTabla", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumPostavljanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("OglasnaTabla");
                });

            modelBuilder.Entity("eNote.Services.Database.PredajaZadatka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumPredaje")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Ocjena")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("ZadatakId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("ZadatakId");

                    b.ToTable("PredajaZadatka");
                });

            modelBuilder.Entity("eNote.Services.Database.Predavanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<string>("Lokacija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrijeme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KursId");

                    b.ToTable("Predavanja");
                });

            modelBuilder.Entity("eNote.Services.Database.Prisustvo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("PotvrdaPrisustva")
                        .HasColumnType("bit");

                    b.Property<int>("PredavanjeId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredavanjeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Prisustva");
                });

            modelBuilder.Entity("eNote.Services.Database.Uloge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("eNote.Services.Database.Upis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KursId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KursId");

                    b.HasIndex("StudentId");

                    b.ToTable("Upisi");
                });

            modelBuilder.Entity("eNote.Services.Database.Zadatak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredavanjeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RokPredaje")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PredavanjeId");

                    b.ToTable("Zadaci");
                });

            modelBuilder.Entity("eNote.Services.Database.Instrumenti", b =>
                {
                    b.HasOne("eNote.Services.Database.MusicShop", "MusicShop")
                        .WithMany("Instrumenti")
                        .HasForeignKey("MusicShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicShop");
                });

            modelBuilder.Entity("eNote.Services.Database.IznajmljivanjeInstrumenta", b =>
                {
                    b.HasOne("eNote.Services.Database.Instrumenti", "Instrument")
                        .WithMany("IznajmljivanjeInstrumenta")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eNote.Services.Database.Korisnik", "Student")
                        .WithMany("IznajmljivanjeInstrumenta")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrument");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("eNote.Services.Database.Korisnik", b =>
                {
                    b.HasOne("eNote.Services.Database.Uloge", "Uloga")
                        .WithMany("Korisnici")
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("eNote.Services.Database.Kurs", b =>
                {
                    b.HasOne("eNote.Services.Database.Korisnik", "Instruktor")
                        .WithMany("Kurs")
                        .HasForeignKey("InstruktorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instruktor");
                });

            modelBuilder.Entity("eNote.Services.Database.Obavijest", b =>
                {
                    b.HasOne("eNote.Services.Database.Predavanje", "Predavanje")
                        .WithMany("Obavijesti")
                        .HasForeignKey("PredavanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predavanje");
                });

            modelBuilder.Entity("eNote.Services.Database.OglasnaTabla", b =>
                {
                    b.HasOne("eNote.Services.Database.Korisnik", "Autor")
                        .WithMany("PostavljeneObavijesti")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("eNote.Services.Database.PredajaZadatka", b =>
                {
                    b.HasOne("eNote.Services.Database.Korisnik", "Student")
                        .WithMany("PredajaZadatka")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eNote.Services.Database.Zadatak", "Zadatak")
                        .WithMany("PredajaZadatka")
                        .HasForeignKey("ZadatakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Zadatak");
                });

            modelBuilder.Entity("eNote.Services.Database.Predavanje", b =>
                {
                    b.HasOne("eNote.Services.Database.Kurs", "Kurs")
                        .WithMany("Predavanje")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");
                });

            modelBuilder.Entity("eNote.Services.Database.Prisustvo", b =>
                {
                    b.HasOne("eNote.Services.Database.Predavanje", "Predavanje")
                        .WithMany("Prisustvo")
                        .HasForeignKey("PredavanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eNote.Services.Database.Korisnik", "Student")
                        .WithMany("Prisustvo")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predavanje");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("eNote.Services.Database.Upis", b =>
                {
                    b.HasOne("eNote.Services.Database.Kurs", "Kurs")
                        .WithMany("Upis")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eNote.Services.Database.Korisnik", "Studenti")
                        .WithMany("Upis")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Studenti");
                });

            modelBuilder.Entity("eNote.Services.Database.Zadatak", b =>
                {
                    b.HasOne("eNote.Services.Database.Predavanje", "Predavanje")
                        .WithMany("Zadaci")
                        .HasForeignKey("PredavanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predavanje");
                });

            modelBuilder.Entity("eNote.Services.Database.Instrumenti", b =>
                {
                    b.Navigation("IznajmljivanjeInstrumenta");
                });

            modelBuilder.Entity("eNote.Services.Database.Korisnik", b =>
                {
                    b.Navigation("IznajmljivanjeInstrumenta");

                    b.Navigation("Kurs");

                    b.Navigation("PostavljeneObavijesti");

                    b.Navigation("PredajaZadatka");

                    b.Navigation("Prisustvo");

                    b.Navigation("Upis");
                });

            modelBuilder.Entity("eNote.Services.Database.Kurs", b =>
                {
                    b.Navigation("Predavanje");

                    b.Navigation("Upis");
                });

            modelBuilder.Entity("eNote.Services.Database.MusicShop", b =>
                {
                    b.Navigation("Instrumenti");
                });

            modelBuilder.Entity("eNote.Services.Database.Predavanje", b =>
                {
                    b.Navigation("Obavijesti");

                    b.Navigation("Prisustvo");

                    b.Navigation("Zadaci");
                });

            modelBuilder.Entity("eNote.Services.Database.Uloge", b =>
                {
                    b.Navigation("Korisnici");
                });

            modelBuilder.Entity("eNote.Services.Database.Zadatak", b =>
                {
                    b.Navigation("PredajaZadatka");
                });
#pragma warning restore 612, 618
        }
    }
}