namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clase")]
    public partial class Clase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public bool? Activo { get; set; }

        public int? CursoID { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
