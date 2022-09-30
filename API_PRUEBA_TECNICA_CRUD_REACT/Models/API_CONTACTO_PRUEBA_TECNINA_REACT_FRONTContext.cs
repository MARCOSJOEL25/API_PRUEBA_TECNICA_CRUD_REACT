using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_PRUEBA_TECNICA_CRUD_REACT.Models
{
    public partial class API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext : DbContext
    {
        public API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext()
        {
        }

        public API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext(DbContextOptions<API_CONTACTO_PRUEBA_TECNINA_REACT_FRONTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RAFDGVR\\SQLEXPRESS; DataBase=API_CONTACTO_PRUEBA_TECNINA_REACT_FRONT;User Id=Joel;Password=123456;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto)
                    .HasName("PK__Contacto__4B1329C7A5D77F67");

                entity.ToTable("Contacto");

                entity.Property(e => e.IdContacto).HasColumnName("idContacto");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
