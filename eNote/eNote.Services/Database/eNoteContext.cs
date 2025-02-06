using eNote.Services.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace eNote.Services.Database
{
    public class ENoteContext(DbContextOptions<ENoteContext> options) : DbContext(options)
    {
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Instruktor> Instruktor { get; set; }
        public DbSet<Polaznik> Polaznik { get; set; }
        public DbSet<MusicShop> MusicShop { get; set; }
        public DbSet<Adresa> Adresa { get; set; }
        public DbSet<Kurs> Kurs { get; set; }
        public DbSet<Predavanje> Predavanje { get; set; }
        public DbSet<Upis> Upis { get; set; }
        public DbSet<Instrumenti> Instrumenti { get; set; }
        public DbSet<VrstaInstrumenta> VrstaInstrumenta { get; set; }
        public DbSet<IznajmljivanjeInstrumenta> IznajmljivanjeInstrumenata { get; set; }
        public DbSet<Napomena> Napomena { get; set; }
        public DbSet<PredajaZadatka> PredajaZadatka { get; set; }
        public DbSet<Zadatak> Zadatak { get; set; }
        public DbSet<Prisustvo> Prisustvo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Administrator-adresa
            modelBuilder.Entity<Administrator>()
                .HasOne(k => k.Adresa)
                .WithMany(a => a.Administratori)
                .HasForeignKey(k => k.AdresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Instruktor-adresa
            modelBuilder.Entity<Instruktor>()
                .HasOne(k => k.Adresa)
                .WithMany(a => a.Instruktori)
                .HasForeignKey(k => k.AdresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Polaznik-adresa
            modelBuilder.Entity<Polaznik>()
                .HasOne(k => k.Adresa)
                .WithMany(a => a.Polaznici)
                .HasForeignKey(k => k.AdresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // MusicShop-adresa
            modelBuilder.Entity<MusicShop>()
                .HasOne(k => k.Adresa)
                .WithMany(a => a.MusicShops)
                .HasForeignKey(k => k.AdresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // MusicShop-instrumenti
            modelBuilder.Entity<Instrumenti>()
                .HasOne(i => i.MusicShop)
                .WithMany(ms => ms.Instrumenti)
                .HasForeignKey(i => i.MusicShopId)
                .OnDelete(DeleteBehavior.Cascade);

            // Instrumenti-vrsta instrumenta
            modelBuilder.Entity<Instrumenti>()
                .HasOne(i => i.VrstaInstrumenta)
                .WithMany(v => v.Instrumenti)
                .HasForeignKey(i => i.VrstaInstrumentaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Kurs-instruktor
            modelBuilder.Entity<Kurs>()
                .HasOne(k => k.Instruktor)
                .WithMany(i => i.Kurs)
                .HasForeignKey(k => k.InstruktorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Upis
            modelBuilder.Entity<Upis>()
                .HasOne(u => u.Polaznik)
                .WithMany(s => s.Upis)
                .HasForeignKey(u => u.PolaznikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Upis>()
                .HasOne(u => u.Kurs)
                .WithMany(k => k.Upis)
                .HasForeignKey(u => u.KursId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kurs>()
                .Property(k => k.Cijena)
                .HasColumnType("decimal(8, 2)");

            // Kurs-predavanje
            modelBuilder.Entity<Predavanje>()
                .HasOne(p => p.Kurs)
                .WithMany(k => k.Predavanje)
                .HasForeignKey(p => p.KursId)
                .OnDelete(DeleteBehavior.Cascade);

            // Prisustvo
            modelBuilder.Entity<Prisustvo>()
                .HasOne(p => p.Polaznik)
                .WithMany(s => s.Prisustvo)
                .HasForeignKey(p => p.PolaznikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prisustvo>()
                .HasOne(p => p.Predavanje)
                .WithMany(p => p.Prisustvo)
                .HasForeignKey(p => p.PredavanjeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Predavanje-obavijest
            modelBuilder.Entity<Napomena>()
                .HasOne(o => o.Predavanje)
                .WithMany(p => p.Napomena)
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
                .HasOne(p => p.Polaznik)
                .WithMany(s => s.PredajaZadatka)
                .HasForeignKey(p => p.PolaznikId)
                .OnDelete(DeleteBehavior.Restrict);

            // Iznajmljivanje
            modelBuilder.Entity<IznajmljivanjeInstrumenta>()
                .HasOne(r => r.Polaznik)
                .WithMany(s => s.IznajmljivanjeInstrumenta)
                .HasForeignKey(r => r.PolaznikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IznajmljivanjeInstrumenta>()
                .HasOne(r => r.Instrument)
                .WithMany(i => i.IznajmljivanjeInstrumenta)
                .HasForeignKey(r => r.InstrumentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IznajmljivanjeInstrumenta>()
                .Property(k => k.CijenaIznajmljivanja)
                .HasColumnType("decimal(8, 2)");

            base.OnModelCreating(modelBuilder);

            SeedData.Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}