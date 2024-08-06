using eNote.Services.Configurations;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Database
{
    public class ENoteContext(DbContextOptions<ENoteContext> options) : DbContext(options)
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Uloge> Uloge { get; set; }
        public DbSet<Adresa> Adresa { get; set; }
        public DbSet<Kurs> Kursevi { get; set; }
        public DbSet<Predavanje> Predavanja { get; set; }
        public DbSet<Upis> Upisi { get; set; }
        public DbSet<Instrumenti> Instrumenti { get; set; }
        public DbSet<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenata { get; set; }
        public DbSet<Obavijest> Obavijesti { get; set; }
        public DbSet<PredajaZadatka> PredajaZadatka { get; set; }
        public DbSet<Zadatak> Zadaci { get; set; }
        public DbSet<Prisustvo> Prisustva { get; set; }
        public DbSet<OglasnaTabla> OglasnaTabla { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Korisnik-uloga
            modelBuilder.Entity<Korisnik>()
                .HasOne(k => k.Uloga)
                .WithMany(u => u.Korisnici)
                .HasForeignKey(k => k.UlogaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Korisnik-adresa
            modelBuilder.Entity<Korisnik>()
                .HasOne(k => k.Adresa)
                .WithMany(a => a.Korisnici)
                .HasForeignKey(k => k.AdresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Upis
            modelBuilder.Entity<Upis>()
                .HasOne(u => u.Student)
                .WithMany(s => s.Upis)
                .HasForeignKey(u => u.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Upis>()
                .HasOne(u => u.Kurs)
                .WithMany(k => k.Upis)
                .HasForeignKey(u => u.KursId)
                .OnDelete(DeleteBehavior.Cascade);

            // Kurs-instruktor
            modelBuilder.Entity<Kurs>()
                .HasOne(k => k.Instruktor)
                .WithMany(i => i.Kurs)
                .HasForeignKey(k => k.InstruktorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Kurs-predavanje
            modelBuilder.Entity<Predavanje>()
                .HasOne(p => p.Kurs)
                .WithMany(k => k.Predavanje)
                .HasForeignKey(p => p.KursId)
                .OnDelete(DeleteBehavior.Cascade);

            // Prisustvo
            modelBuilder.Entity<Prisustvo>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Prisustvo)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prisustvo>()
                .HasOne(p => p.Predavanje)
                .WithMany(p => p.Prisustvo)
                .HasForeignKey(p => p.PredavanjeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Predavanje-obavijest
            modelBuilder.Entity<Obavijest>()
                .HasOne(o => o.Predavanje)
                .WithMany(p => p.Obavijesti)
                .HasForeignKey(o => o.PredavanjeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Predavanje-zadatak
            modelBuilder.Entity<Zadatak>()
                .HasOne(z => z.Predavanje)
                .WithMany(p => p.Zadaci)
                .HasForeignKey(z => z.PredavanjeId)
                .OnDelete(DeleteBehavior.Cascade);

            // PredajaZadatka
            modelBuilder.Entity<PredajaZadatka>()
                .HasOne(p => p.Zadatak)
                .WithMany(z => z.PredajaZadatka)
                .HasForeignKey(p => p.ZadatakId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PredajaZadatka>()
                .HasOne(p => p.Student)
                .WithMany(s => s.PredajaZadatka)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // MusicShop-instrument
            modelBuilder.Entity<Instrumenti>()
                .HasOne(i => i.MusicShop)
                .WithMany(ms => ms.Instrumenti)
                .HasForeignKey(i => i.KorisnikId)
                .OnDelete(DeleteBehavior.Cascade);

            // Instrument-tipInstrumenta
            modelBuilder.Entity<Instrumenti>()
                .HasOne(i => i.VrstaInstrumenta)
                .WithMany(v => v.Instrumenti)
                .HasForeignKey(i => i.VrstaInstrumentaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Iznajmljivanje
            modelBuilder.Entity<IznajmljivanjeInstrumenta>()
                .HasOne(r => r.Student)
                .WithMany(s => s.IznajmljivanjeInstrumenta)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IznajmljivanjeInstrumenta>()
                .HasOne(r => r.Instrument)
                .WithMany(i => i.IznajmljivanjeInstrumenta)
                .HasForeignKey(r => r.InstrumentId)
                .OnDelete(DeleteBehavior.Cascade);

            // OglasnaTabla-instruktor
            modelBuilder.Entity<OglasnaTabla>()
                .HasOne(o => o.Autor)
                .WithMany(u => u.PostavljeneObavijesti)
                .HasForeignKey(o => o.AutorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            SeedData.Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
