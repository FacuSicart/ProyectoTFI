namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donacion")]
    public partial class Donacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int PrefijoTelefono { get; set; }

        public int Telefono { get; set; }

        public decimal Monto { get; set; }

        public int TarjetaID { get; set; }

        public virtual Tarjeta Tarjeta { get; set; }
    }
}
