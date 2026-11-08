using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MasterDatabaseFirst.Models;

public partial class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpertProfile> ExpertProfiles { get; set; }

    public virtual DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSetting> UserSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpertProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ExpertPr__1788CC4C7F5C35A1");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Bio).IsUnicode(false);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("JD");
            entity.Property(e => e.Headline)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HourlyRate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IsListed).HasDefaultValue(true);
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Organization)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.ExpertProfile)
                .HasForeignKey<ExpertProfile>(d => d.UserId)
                .HasConstraintName("FK__ExpertPro__UserI__619B8048");
        });

        modelBuilder.Entity<JobSeekerProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__JobSeeke__1788CC4C9418FAB6");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.DesiredRole)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Headline)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LinkedInUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PortfolioUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Summary).IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.YearsExperience).HasColumnType("decimal(4, 1)");

            entity.HasOne(d => d.User).WithOne(p => p.JobSeekerProfile)
                .HasForeignKey<JobSeekerProfile>(d => d.UserId)
                .HasConstraintName("FK__JobSeeker__UserI__5165187F");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E127EE921CA");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.TargetUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__5CD6CB2B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C16809058");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AFFBEFC1").IsUnique();

            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<UserSetting>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserSett__1788CC4C8664DD9C");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.EmailNotifications).HasDefaultValue(true);
            entity.Property(e => e.LanguageCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("en");
            entity.Property(e => e.PushNotifications).HasDefaultValue(true);
            entity.Property(e => e.Theme)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("light");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithOne(p => p.UserSetting)
                .HasForeignKey<UserSetting>(d => d.UserId)
                .HasConstraintName("FK__UserSetti__UserI__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
