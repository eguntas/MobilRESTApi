using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilApi.Models
{
    public class MobilApiContext : DbContext
    {
        public MobilApiContext()
        {
        }

        public MobilApiContext(DbContextOptions<MobilApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmbarTbl> AmbarTbl { get; set; }
        public virtual DbSet<BolumTbl> BolumTbl { get; set; }
        public virtual DbSet<FirmaTbl> FirmaTbl { get; set; }
        public virtual DbSet<HareketTbl> HareketTbl { get; set; }
        public virtual DbSet<KayitTbl> KayitTbl { get; set; }
        public virtual DbSet<KullaniciTbl> KullaniciTbl { get; set; }
        public virtual DbSet<TupTanimTbl> TupTanimTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=STIBRSNBIM029;Database=MobilApi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmbarTbl>(entity =>
            {
                entity.HasKey(e => e.AmbarId);

                entity.Property(e => e.AmbarId).HasColumnName("AmbarID");

                entity.Property(e => e.AmbarAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<BolumTbl>(entity =>
            {
                entity.HasKey(e => e.BolumId);

                entity.Property(e => e.BolumId).HasColumnName("BolumID");

                entity.Property(e => e.BolumAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<FirmaTbl>(entity =>
            {
                entity.HasKey(e => e.FirmaId);

                entity.Property(e => e.FirmaId).HasColumnName("FirmaID");

                entity.Property(e => e.FirmaAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<HareketTbl>(entity =>
            {
                entity.HasKey(e => e.HareketId);

                entity.Property(e => e.HareketId).HasColumnName("HareketID");

                entity.Property(e => e.AmbarIds).HasColumnName("AmbarIDs");

                entity.Property(e => e.BolumIds).HasColumnName("BolumIDs");

                entity.Property(e => e.HareketTipi).HasMaxLength(50);

                entity.Property(e => e.KayitIds).HasColumnName("KayitIDs");

                entity.HasOne(d => d.AmbarIdsNavigation)
                    .WithMany(p => p.HareketTbl)
                    .HasForeignKey(d => d.AmbarIds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HareketTbl_AmbarTbl");

                entity.HasOne(d => d.KayitIdsNavigation)
                    .WithMany(p => p.HareketTbls)
                    .HasForeignKey(d => d.KayitIds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HareketTbl_KayitTbl");
            });

            modelBuilder.Entity<KayitTbl>(entity =>
            {
                entity.HasKey(e => e.KayitId);

                entity.Property(e => e.KayitId).HasColumnName("KayitID");

                entity.Property(e => e.CikisTarih).HasColumnType("datetime");

                entity.Property(e => e.CikisYapanKisi).HasMaxLength(50);

                entity.Property(e => e.FirmaIds).HasColumnName("FirmaIDs");

                entity.Property(e => e.GirisTarih).HasColumnType("datetime");

                entity.Property(e => e.TupIds).HasColumnName("TupIDs");

                entity.Property(e => e.UserIds).HasColumnName("UserIDs");

                entity.HasOne(d => d.FirmaIdsNavigation)
                    .WithMany(p => p.KayitTbl)
                    .HasForeignKey(d => d.FirmaIds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KayitTbl_FirmaTbl");

                entity.HasOne(d => d.TupIdsNavigation)
                    .WithMany(p => p.KayitTbl)
                    .HasForeignKey(d => d.TupIds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KayitTbl_TupTanimTbl");

                entity.HasOne(d => d.UserIdsNavigation)
                    .WithMany(p => p.KayitTbls)
                    .HasForeignKey(d => d.UserIds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KayitTbl_KullaniciTbl");
            });

            modelBuilder.Entity<KullaniciTbl>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.BolumIds).HasColumnName("BolumIDs");

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.Username).HasMaxLength(30);

                entity.HasOne(d => d.BolumIdsNavigation)
                    .WithMany(p => p.KullaniciTbl)
                    .HasForeignKey(d => d.BolumIds)
                    .HasConstraintName("FK_KullaniciTbl_BolumTbl");
            });

            modelBuilder.Entity<TupTanimTbl>(entity =>
            {
                entity.HasKey(e => e.TupId);

                entity.Property(e => e.TupId).HasColumnName("TupID");

                entity.Property(e => e.TupDurum).HasMaxLength(50);

                entity.Property(e => e.TupTipi).HasMaxLength(50);

                entity.Property(e => e.UretimTarih).HasColumnType("datetime");

                entity.Property(e => e.SonKullanimTarih).HasColumnType("datetime");
            });
        }
    }
}
