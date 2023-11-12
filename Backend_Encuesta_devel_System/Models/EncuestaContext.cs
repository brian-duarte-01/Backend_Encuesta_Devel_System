using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_Encuesta_devel_System.Models;

public partial class EncuestaContext : DbContext
{
    public EncuestaContext()
    {
    }

    public EncuestaContext(DbContextOptions<EncuestaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.; database=Encuesta; integrated security=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.Pidpreguntas).HasName("PK__pregunta__4D98BFB2E06A1F13");

            entity.ToTable("preguntas");

            entity.Property(e => e.Ppregunta1)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Ppregunta2)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Ppregunta3)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Uusuario)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Uidusuario).HasName("PK__usuario__E3B3CF091616009F");

            entity.ToTable("usuario");

            entity.Property(e => e.Upassword)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Uusuario)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
