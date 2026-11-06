using System;
using System.Collections.Generic;
using AGCSMS.Models;
using Microsoft.EntityFrameworkCore;

namespace AGCSMS.Data;

public partial class AcademyDBContext : DbContext
{
    public AcademyDBContext()
    {
    }

    public AcademyDBContext(DbContextOptions<AcademyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GraduationCertificate> GraduationCertificates { get; set; }

    public virtual DbSet<GraduationGift> GraduationGifts { get; set; }

    public virtual DbSet<Hospitality> Hospitalities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GraduationCertificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Graduati__3214EC07B3C6AA8A");

            entity.HasIndex(e => e.SupplierName, "UQ__Graduati__9C5DF66F1AC6EE78").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OfferName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<GraduationGift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Graduati__3214EC079FE5577E");

            entity.HasIndex(e => e.SupplierName, "UQ__Graduati__9C5DF66FDC60CF4F").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OfferName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Hospitality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hospital__3214EC074ACBDB7A");

            entity.ToTable("Hospitality");

            entity.HasIndex(e => e.SupplierName, "UQ__Hospital__9C5DF66F0CA633F7").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OfferName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
