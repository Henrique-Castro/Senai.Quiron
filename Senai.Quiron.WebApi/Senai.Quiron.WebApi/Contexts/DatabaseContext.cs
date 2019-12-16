using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Quiron.WebApi.Domains
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doutores> Doutores { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=T_Quiron;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doutores>(entity =>
            {
                entity.HasKey(e => e.IdDoutores);

                entity.HasIndex(e => e.Crm)
                    .HasName("UQ__Doutores__C1FF83F7C78338DF")
                    .IsUnique();

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CrmUf)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.IdPacientes);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Paciente__C1FF93099C8A4324")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
