using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProyectoTFI.Entities
{
    public partial class TFIContext : DbContext
    {
        public TFIContext()
            : base("name=TFIContext")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Clase> Clase { get; set; }
        public virtual DbSet<Cursada_de_Alumno> Cursada_de_Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Docente_Curso> Docente_Curso { get; set; }
        public virtual DbSet<Donacion> Donacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud_Respuesta> Solicitud_Respuesta { get; set; }
        public virtual DbSet<Solicitud_Soporte> Solicitud_Soporte { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>()
                .HasMany(e => e.Solicitud_Respuesta)
                .WithRequired(e => e.Administrador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Solicitud_Soporte)
                .WithRequired(e => e.Alumno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bitacora>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Clase>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Donacion>()
                .Property(e => e.NombreEmpresa)
                .IsUnicode(false);

            modelBuilder.Entity<Donacion>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Donacion>()
                .Property(e => e.Monto)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Respuesta>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Soporte>()
                .Property(e => e.Asunto)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Soporte>()
                .Property(e => e.TipoConsulta)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Soporte>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Soporte>()
                .HasMany(e => e.Solicitud_Respuesta)
                .WithRequired(e => e.Solicitud_Soporte)
                .HasForeignKey(e => e.SolicitudID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarjeta>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta>()
                .HasMany(e => e.Donacion)
                .WithRequired(e => e.Tarjeta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Bitacora)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
