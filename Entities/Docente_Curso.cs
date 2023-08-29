namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Docente_Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public bool? Activo { get; set; }

        public int? CursoID { get; set; }

        public int? DocenteID { get; set; }

        public virtual Docente Docente { get; set; }
    }
}
