namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bitacora")]
    public partial class Bitacora
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime Fecha { get; set; }

        public int Importancia { get; set; }

        [Required]
        [StringLength(80)]
        public string Descripcion { get; set; }

        public int UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
