
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VeroToursApi.Models;

namespace VeroToursApi.Context;

public partial class VeroToursContext : DbContext
{
    public VeroToursContext()
    {
    }

    public VeroToursContext(DbContextOptions<VeroToursContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aerolinea> Aerolineas { get; set; }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aerolinea>(entity =>
        {
            entity.HasIndex(e => e.Codigo, "UQ__Aeroline__06370DACC25DAFE8").IsUnique();

            entity.Property(e => e.AerolineaId).HasColumnName("AerolineaID");
            entity.Property(e => e.Codigo).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasIndex(e => e.Codigo, "UQ__Aeropuer__06370DAC92679462").IsUnique();

            entity.Property(e => e.AeropuertoId).HasColumnName("AeropuertoID");
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.Codigo).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Pais).HasMaxLength(100);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.VueloId).HasColumnName("VueloID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Reservas_Usuarios");

            entity.HasOne(d => d.Vuelo).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.VueloId)
                .HasConstraintName("FK_Reservas_Vuelos");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534E34E913F").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.Property(e => e.VueloId).HasColumnName("VueloID");
            entity.Property(e => e.AerolineaId).HasColumnName("AerolineaID");
            entity.Property(e => e.DestinoId).HasColumnName("DestinoID");
            entity.Property(e => e.FechaHoraLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraSalida).HasColumnType("datetime");
            entity.Property(e => e.OrigenId).HasColumnName("OrigenID");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Aerolinea).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.AerolineaId)
                .HasConstraintName("FK_Vuelos_Aerolineas");

            entity.HasOne(d => d.Destino).WithMany(p => p.VueloDestinos)
                .HasForeignKey(d => d.DestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vuelos_Destino");

            entity.HasOne(d => d.Origen).WithMany(p => p.VueloOrigens)
                .HasForeignKey(d => d.OrigenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vuelos_Origen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
