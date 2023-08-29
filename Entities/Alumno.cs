namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Cursada_de_Alumno = new HashSet<Cursada_de_Alumno>();
            Solicitud_Soporte = new HashSet<Solicitud_Soporte>();
        }
        public Alumno(Usuario user)
        {
            Cursada_de_Alumno = new HashSet<Cursada_de_Alumno>();
            Solicitud_Soporte = new HashSet<Solicitud_Soporte>();

            Usuario = user;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cursada_de_Alumno> Cursada_de_Alumno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Soporte> Solicitud_Soporte { get; set; }
    }
}
