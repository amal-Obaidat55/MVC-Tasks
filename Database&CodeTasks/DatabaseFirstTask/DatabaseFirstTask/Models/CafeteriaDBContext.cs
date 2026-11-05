using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstTask.Models;

public partial class CafeteriaDBContext : DbContext
{
    public CafeteriaDBContext(DbContextOptions<CafeteriaDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC073AA906F1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cdescription)
                .IsUnicode(false)
                .HasColumnName("CDescription");
            entity.Property(e => e.Cname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CName");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07CD2529D2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.Pname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PName");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SuppId).HasColumnName("SuppID");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__Products__CID__4F7CD00D");

            entity.HasOne(d => d.Supp).WithMany(p => p.Products)
                .HasForeignKey(d => d.SuppId)
                .HasConstraintName("FK__Products__SuppID__5070F446");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC0757B343BE");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Pstatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PStatus");
            entity.Property(e => e.SuppId).HasColumnName("SuppID");

            entity.HasOne(d => d.Supp).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SuppId)
                .HasConstraintName("FK__PurchaseO__SuppI__534D60F1");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC0738DD3AF9");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PurchId).HasColumnName("PurchID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__PurchaseO__Produ__5812160E");

            entity.HasOne(d => d.Purch).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.PurchId)
                .HasConstraintName("FK__PurchaseO__Purch__571DF1D5");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07C4316B97");

            entity.HasIndex(e => e.Email, "UQ__Supplier__A9D105340E21B8D9").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
