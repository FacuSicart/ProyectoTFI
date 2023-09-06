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
        public Donacion()
        {
            Tarjeta = new Tarjeta();
        }

        public Donacion(Tarjeta pTarjeta)
        {
            Tarjeta = pTarjeta;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        [StringLength(50)]
        public string NombreEmpresa { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Correo Electr�nico")]
        [EmailAddress(ErrorMessage = "El Formato del Correo Electr�nico es incorrecto.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El Formato del Correo Electr�nico es incorrecto.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Prefijo Telef�nico")]
        public int PrefijoTelefono { get; set; }

        [Required]
        [Display(Name = "N�mero de Tel�fono")]
        public int Telefono { get; set; }

        [StringLength(5)]
        [Required]
        [Display(Name = "Monto a Donar")]
        public decimal Monto { get; set; }

        public int TarjetaID { get; set; }

        public virtual Tarjeta Tarjeta { get; set; }
    }
}
