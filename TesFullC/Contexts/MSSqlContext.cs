using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TesFullC.Models;

#nullable disable

namespace TesFullC.Contexts
{
    public partial class MSSqlContext : DbContext
    {
        public MSSqlContext()
        {
        }

        public MSSqlContext(DbContextOptions<MSSqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TableStock> TableStocks { get; set; }
        public virtual DbSet<User> Users { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TableStock>(entity =>
            {
                entity.ToTable("TableStock");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BanG1).HasColumnName("Ban_G1");

                entity.Property(e => e.BanG2).HasColumnName("Ban_G2");

                entity.Property(e => e.BanG3).HasColumnName("Ban_G3");

                entity.Property(e => e.BanKl1).HasColumnName("Ban_Kl1");

                entity.Property(e => e.BanKl2).HasColumnName("Ban_Kl2");

                entity.Property(e => e.BanKl3).HasColumnName("Ban_Kl3");

                entity.Property(e => e.MuaG1).HasColumnName("Mua_G1");

                entity.Property(e => e.MuaG2).HasColumnName("Mua_G2");

                entity.Property(e => e.MuaG3).HasColumnName("Mua_G3");

                entity.Property(e => e.MuaKl1).HasColumnName("Mua_KL1");

                entity.Property(e => e.MuaKl2).HasColumnName("Mua_Kl2");

                entity.Property(e => e.MuaKl3).HasColumnName("Mua_Kl3");

                entity.Property(e => e.Nnban).HasColumnName("NNBan");

                entity.Property(e => e.Nnmua).HasColumnName("NNMua");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TempPass)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
