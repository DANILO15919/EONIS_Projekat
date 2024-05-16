using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EONISIT32020.Models;

public partial class ProdavnicaOdeceIt322020Context : DbContext
{
    public ProdavnicaOdeceIt322020Context()
    {
    }

    public ProdavnicaOdeceIt322020Context(DbContextOptions<ProdavnicaOdeceIt322020Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Brend> Brends { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<Kupac> Kupacs { get; set; }

    public virtual DbSet<PorProi> PorProis { get; set; }

    public virtual DbSet<Porudzbina> Porudzbinas { get; set; }

    public virtual DbSet<Proizvod> Proizvods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProdavnicaOdeceIT322020;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmina).HasName("PK__Admin__1F642EAB6CE5C22D");

            entity.ToTable("Admin", "SportskaOprema");

            entity.Property(e => e.IdAdmina).HasColumnName("ID_admina");
            entity.Property(e => e.IdKorisnika).HasColumnName("ID_korisnika");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdKorisnikaNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.IdKorisnika)
                .HasConstraintName("FK__Admin__ID_korisn__0CA5D9DE");
        });

        modelBuilder.Entity<Brend>(entity =>
        {
            entity.HasKey(e => e.IdBrenda).HasName("PK__Brend__35F8139753BC3CD8");

            entity.ToTable("Brend", "SportskaOprema");

            entity.Property(e => e.IdBrenda).HasColumnName("ID_brenda");
            entity.Property(e => e.NazivBrenda)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.IdKorisnika).HasName("PK__Korisnik__EC6F83B8C4B1D80C");

            entity.ToTable("Korisnik", "SportskaOprema");

            entity.Property(e => e.IdKorisnika).HasColumnName("ID_korisnika");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lozinka)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Uloga)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kupac>(entity =>
        {
            entity.HasKey(e => e.IdKupca).HasName("PK__Kupac__9AE721DCCDF8D55F");

            entity.ToTable("Kupac", "SportskaOprema", tb => tb.HasTrigger("DatumRegistracijeTrigger"));

            entity.Property(e => e.IdKupca).HasColumnName("ID_kupca");
            entity.Property(e => e.Adresa)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DatumRegistracije).HasColumnName("Datum_registracije");
            entity.Property(e => e.IdKorisnika).HasColumnName("ID_korisnika");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdKorisnikaNavigation).WithMany(p => p.Kupacs)
                .HasForeignKey(d => d.IdKorisnika)
                .HasConstraintName("FK__Kupac__ID_korisn__06ED0088");
        });

        modelBuilder.Entity<PorProi>(entity =>
        {
            entity.HasKey(e => new { e.IdPorudzbine, e.IdProizvoda }).HasName("PK__PorProi__8F8A8A020ED66C17");

            entity.ToTable("PorProi", "SportskaOprema");

            entity.Property(e => e.IdPorudzbine).HasColumnName("ID_porudzbine");
            entity.Property(e => e.IdProizvoda).HasColumnName("ID_proizvoda");

            entity.HasOne(d => d.IdPorudzbineNavigation).WithMany(p => p.PorProis)
                .HasForeignKey(d => d.IdPorudzbine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PorProi__ID_poru__1446FBA6");

            entity.HasOne(d => d.IdProizvodaNavigation).WithMany(p => p.PorProis)
                .HasForeignKey(d => d.IdProizvoda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PorProi__ID_proi__153B1FDF");
        });

        modelBuilder.Entity<Porudzbina>(entity =>
        {
            entity.HasKey(e => e.IdPorudzbine).HasName("PK__Porudzbi__17EAB80641D25CDB");

            entity.ToTable("Porudzbina", "SportskaOprema");

            entity.Property(e => e.IdPorudzbine).HasColumnName("ID_porudzbine");
            entity.Property(e => e.IdKupca).HasColumnName("ID_kupca");

            entity.HasOne(d => d.IdKupcaNavigation).WithMany(p => p.Porudzbinas)
                .HasForeignKey(d => d.IdKupca)
                .HasConstraintName("FK__Porudzbin__Ukupn__09C96D33");
        });

        modelBuilder.Entity<Proizvod>(entity =>
        {
            entity.HasKey(e => e.IdProizvoda).HasName("PK__Proizvod__860320480FEEA185");

            entity.ToTable("Proizvod", "SportskaOprema");

            entity.Property(e => e.IdProizvoda).HasColumnName("ID_proizvoda");
            entity.Property(e => e.Boja)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IdBrenda).HasColumnName("ID_brenda");
            entity.Property(e => e.KoličinaNaStanju).HasColumnName("Količina_na_stanju");
            entity.Property(e => e.Naziv)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Opis).HasColumnType("text");
            entity.Property(e => e.Slika)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Veličina)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBrendaNavigation).WithMany(p => p.Proizvods)
                .HasForeignKey(d => d.IdBrenda)
                .HasConstraintName("FK__Proizvod__ID_bre__116A8EFB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
