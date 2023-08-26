namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Solicitud_Soporte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud_Soporte()
        {
            Solicitud_Respuesta = new HashSet<Solicitud_Respuesta>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Asunto { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoConsulta { get; set; }

        [Required]
        [StringLength(450)]
        public string Descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public bool Activo { get; set; }

        public int AlumnoID { get; set; }

        public virtual Alumno Alumno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Respuesta> Solicitud_Respuesta { get; set; }
    }
}
