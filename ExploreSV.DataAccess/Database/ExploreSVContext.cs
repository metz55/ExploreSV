using System;
using System.Collections.Generic;
using ExploreSV.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExploreSV.DataAccess;

public partial class ExploreSVContext : DbContext
{
    public ExploreSVContext()
    {
    }

    public ExploreSVContext(DbContextOptions<ExploreSVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gastronomy> Gastronomies { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TouristDestination> TouristDestinations { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-VU4B7EB; Database=ExploreSV; User Id=Val; Password=cometa; Encrypt=False; TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BF5D00E37");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED125FC874");

            entity.Property(e => e.DepartamentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C810F26F7F12");

            entity.Property(e => e.EventDescription).IsUnicode(false);
            entity.Property(e => e.EventTitle)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.TouristDestination).WithMany(p => p.Events)
                .HasForeignKey(d => d.TouristDestinationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__TouristD__4AB81AF0");
        });

        modelBuilder.Entity<Gastronomy>(entity =>
        {
            entity.HasKey(e => e.GastronomyId).HasName("PK__Gastrono__16B78AB4CB0630F6");

            entity.Property(e => e.GastronomyDescription).IsUnicode(false);
            entity.Property(e => e.GastronomyTitle)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TouristDestination).WithMany(p => p.Gastronomies)
                .HasForeignKey(d => d.TouristDestinationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Gastronom__Touri__47DBAE45");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Images__7516F70C67CBD698");

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");

            entity.HasOne(d => d.Event).WithMany(p => p.Images)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Images__EventId__4F7CD00D");

            entity.HasOne(d => d.Gastronomy).WithMany(p => p.Images)
                .HasForeignKey(d => d.GastronomyId)
                .HasConstraintName("FK__Images__Gastrono__4E88ABD4");

            entity.HasOne(d => d.TouristDestination).WithMany(p => p.Images)
                .HasForeignKey(d => d.TouristDestinationId)
                .HasConstraintName("FK__Images__TouristD__4D94879B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A060EDD01");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE206347238925");

            entity.ToTable("Status");

            entity.Property(e => e.StatusName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TouristDestination>(entity =>
        {
            entity.HasKey(e => e.TouristDestinationId).HasName("PK__TouristD__81B80E312A0B1262");

            entity.Property(e => e.TouristDestinationDescription).IsUnicode(false);
            entity.Property(e => e.TouristDestinationLocation).IsUnicode(false);
            entity.Property(e => e.TouristDestinationSchedule)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TouristDestinationTitle)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.TouristDestinations)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TouristDe__Categ__4316F928");

            entity.HasOne(d => d.Department).WithMany(p => p.TouristDestinations)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TouristDe__Depar__440B1D61");

            entity.HasOne(d => d.Status).WithMany(p => p.TouristDestinations)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TouristDe__Statu__4222D4EF");

            entity.HasOne(d => d.User).WithMany(p => p.TouristDestinations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TouristDe__UserI__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C3675977C");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}