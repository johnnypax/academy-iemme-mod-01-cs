﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_lez06_ef_introduzione.Models;

public partial class AccLez07OtmCartaContext : DbContext
{
    public AccLez07OtmCartaContext()
    {
    }

    public AccLez07OtmCartaContext(DbContextOptions<AccLez07OtmCartaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cartum> Carta { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;Database=acc_lez07_otm_carta;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cartum>(entity =>
        {
            entity.HasKey(e => e.CartaId).HasName("PK__Carta__30780D4DACC9204F");

            entity.HasIndex(e => e.Codice, "UQ__Carta__40F9C18B591A3701").IsUnique();

            entity.Property(e => e.CartaId).HasColumnName("cartaID");
            entity.Property(e => e.Codice)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.Negozio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("negozio");
            entity.Property(e => e.PersonaRif).HasColumnName("personaRIF");

            entity.HasOne(d => d.PersonaRifNavigation).WithMany(p => p.Carta)
                .HasForeignKey(d => d.PersonaRif)
                .HasConstraintName("FK__Carta__personaRI__3C69FB99");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PersonaId).HasName("PK__Persona__54B758F55DD7ACF0");

            entity.ToTable("Persona");

            entity.HasIndex(e => e.Email, "UQ__Persona__AB6E6164B72BA352").IsUnique();

            entity.Property(e => e.PersonaId).HasColumnName("personaID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
