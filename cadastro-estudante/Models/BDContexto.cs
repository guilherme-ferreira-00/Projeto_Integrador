using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cadastro_estudante.Models
{
    public partial class BDContexto : DbContext
    {
        public BDContexto()
        {
        }

        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Cursodisciplina> Cursodisciplina { get; set; }
        public virtual DbSet<Cursoestudante> Cursoestudante { get; set; }
        public virtual DbSet<Estudante> Estudante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=12345678;database=cadastro_estudante");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PRIMARY");

                entity.ToTable("area");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PRIMARY");

                entity.ToTable("curso");

                entity.HasIndex(e => e.IdArea)
                    .HasName("IdArea");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("curso_ibfk_1");
            });

            modelBuilder.Entity<Cursodisciplina>(entity =>
            {
                entity.HasKey(e => e.IdcursoDisciplina)
                    .HasName("PRIMARY");

                entity.ToTable("cursodisciplina");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Cursoestudante>(entity =>
            {
                entity.HasKey(e => e.IdcursoEstudante)
                    .HasName("PRIMARY");

                entity.ToTable("cursoestudante");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<Estudante>(entity =>
            {
                entity.ToTable("estudante");

                entity.HasIndex(e => e.IdCurso)
                    .HasName("IdCurso");

                entity.HasIndex(e => e.IdcursoDisciplina)
                    .HasName("IdcursoDisciplina");

                entity.HasIndex(e => e.IdcursoEstudante)
                    .HasName("IdcursoEstudante");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Estudante)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("estudante_ibfk_1");

                entity.HasOne(d => d.IdcursoDisciplinaNavigation)
                    .WithMany(p => p.Estudante)
                    .HasForeignKey(d => d.IdcursoDisciplina)
                    .HasConstraintName("estudante_ibfk_2");

                entity.HasOne(d => d.IdcursoEstudanteNavigation)
                    .WithMany(p => p.Estudante)
                    .HasForeignKey(d => d.IdcursoEstudante)
                    .HasConstraintName("estudante_ibfk_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
