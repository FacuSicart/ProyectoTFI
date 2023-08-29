namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Alumno = new HashSet<Alumno>();
            Bitacora = new HashSet<Bitacora>();
            Docente = new HashSet<Docente>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(40)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Número de Documento")]
        public string DNI { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El Formato del Correo Electrónico es incorrecto.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El Formato del Correo Electrónico es incorrecto.")]
        public string Email { get; set; }

        public bool? Activo { get; set; }

        public int? RolID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bitacora> Bitacora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Docente> Docente { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
