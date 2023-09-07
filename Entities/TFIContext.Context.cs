﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTFI.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TFIContext : DbContext
    {
        public TFIContext()
            : base("name=TFIContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
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
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Quiz_Conclusion> Quiz_Conclusion { get; set; }
        public virtual DbSet<Quiz_Cursada_de_Alumno> Quiz_Cursada_de_Alumno { get; set; }
        public virtual DbSet<Quiz_Pregunta> Quiz_Pregunta { get; set; }
        public virtual DbSet<Quiz_Pregunta_Opcion> Quiz_Pregunta_Opcion { get; set; }
        public virtual DbSet<Quiz_Respuesta> Quiz_Respuesta { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud_Respuesta> Solicitud_Respuesta { get; set; }
        public virtual DbSet<Solicitud_Soporte> Solicitud_Soporte { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
