using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi1.Models;

public partial class DbinventarioContext : DbContext
{
    public DbinventarioContext()
    {
    }

    public DbinventarioContext(DbContextOptions<DbinventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empeado> Empeados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empeado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empeado__CE6D8B9E64C0693A");

            entity.ToTable("Empeado");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
