namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tarjeta")]
    public partial class Tarjeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarjeta()
        {
            Donacion = new HashSet<Donacion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public bool? Tipo { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "N�mero de Tarjeta")]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Fecha de Caducidad")]
        public int? FechaCaducidad { get; set; }

        [Required]
        [Display(Name = "C�digo de Seguridad")]
        public int? CVV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donacion> Donacion { get; set; }
    }
}
