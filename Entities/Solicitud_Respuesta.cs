namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Solicitud_Respuesta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(450)]
        public string Descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public int SolicitudID { get; set; }

        public int AdministradorID { get; set; }

        public virtual Administrador Administrador { get; set; }

        public virtual Solicitud_Soporte Solicitud_Soporte { get; set; }
    }
}
