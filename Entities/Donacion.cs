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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        [StringLength(50)]
        public string NombreEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El Formato del Correo Electrónico es incorrecto.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El Formato del Correo Electrónico es incorrecto.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Prefijo Telefónico")]
        public int PrefijoTelefono { get; set; }

        [Required]
        [Display(Name = "Número de Teléfono")]
        public int Telefono { get; set; }

        [StringLength(5)]
        [Required]
        [Display(Name = "Monto a Donar")]
        public decimal Monto { get; set; }

        public int TarjetaID { get; set; }

        public virtual Tarjeta Tarjeta { get; set; }
    }
}
