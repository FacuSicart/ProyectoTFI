//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using ProyectoTFI.Models;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Alumno = new HashSet<Alumno>();
            this.Bitacora = new HashSet<Bitacora>();
            this.Docente = new HashSet<Docente>();
        }

        public Usuario(UsuarioViewModel pUsuarioViewModel)
        {
            ID = pUsuarioViewModel.ID;
            Username = pUsuarioViewModel.Username;
            Password = pUsuarioViewModel.Password;
            Nombre = pUsuarioViewModel.Nombre;
            Apellido = pUsuarioViewModel.Apellido;
            DNI = pUsuarioViewModel.DNI;
            FechaNacimiento = pUsuarioViewModel.FechaNacimiento;
            Email = pUsuarioViewModel.Email;
            Activo = pUsuarioViewModel.Activo;

            this.Alumno = new HashSet<Alumno>();
            this.Bitacora = new HashSet<Bitacora>();
            this.Docente = new HashSet<Docente>();
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> RolID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bitacora> Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Docente> Docente { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
