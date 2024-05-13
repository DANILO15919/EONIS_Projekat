using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SportskaOpremaIT322020.Models;

public partial class ProdavnicaOdeceIt322020Context : DbContext
{
    public ProdavnicaOdeceIt322020Context()
    {
    }

    public ProdavnicaOdeceIt322020Context(DbContextOptions<ProdavnicaOdeceIt322020Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblBrand> TblBrands { get; set; }

    public virtual DbSet<TblCart> TblCarts { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblType> TblTypes { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= .\\SQLExpress;Database=ProdavnicaOdeceIT322020;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblAdmin");

            entity.Property(e => e.AdminId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AdminID");
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(20);
        });

        modelBuilder.Entity<TblBrand>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblBrand");

            entity.Property(e => e.BrandId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BrandID");
            entity.Property(e => e.BrandName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblCart>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblCart");

            entity.Property(e => e.CartItemId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CartItemID");
            entity.Property(e => e.ItemBrand).HasMaxLength(20);
            entity.Property(e => e.ItemDescription).HasMaxLength(2000);
            entity.Property(e => e.ItemImage).HasMaxLength(50);
            entity.Property(e => e.ItemName).HasMaxLength(20);
            entity.Property(e => e.ItemSize).HasMaxLength(10);
            entity.Property(e => e.ItemType).HasMaxLength(20);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblProduct");

            entity.Property(e => e.BrandName).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ImageSource).HasMaxLength(50);
            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(20);
            entity.Property(e => e.Size).HasMaxLength(10);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<TblType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblType");

            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.TypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TypeID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblUser");

            entity.Property(e => e.Adress).HasMaxLength(30);
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.Country).HasMaxLength(20);
            entity.Property(e => e.Date).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Surname).HasMaxLength(20);
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
            entity.Property(e => e.Username).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
