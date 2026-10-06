using Microsoft.EntityFrameworkCore;
using MobilyaTakip.Models;

namespace MobilyaTakip.Data
{
    public class StokDbContext : DbContext
    {
        // Veritabanı tabloları
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Tur> Turlar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Kaplama> Kaplamalar { get; set; }
        public DbSet<Kalinlik> Kalinliklar { get; set; }
        public DbSet<Malzeme> Malzemeler { get; set; }
        public DbSet<StokHareketi> StokHareketleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.\SQLEXPRESS;Database=MobilyaStokTakipDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // StokHareketi'nin primary key'ini açık olarak tanımla
            modelBuilder.Entity<StokHareketi>()
                .HasKey(x => x.HareketID);

            // Foreign key ilişkilerini açık olarak tanımla
            modelBuilder.Entity<StokHareketi>()
                .HasOne(x => x.Malzeme)
                .WithMany(x => x.StokHareketleri)
                .HasForeignKey(x => x.MalzemeID);

            modelBuilder.Entity<StokHareketi>()
                .HasOne(x => x.Kullanici)
                .WithMany(x => x.StokHareketleri)
                .HasForeignKey(x => x.KullaniciID);
        }
    }
}