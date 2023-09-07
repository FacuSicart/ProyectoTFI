using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class DonacionViewModel
    {
        public DonacionViewModel()
        {

        }

        public DonacionViewModel(Donacion pDonacion)
        {
            ID = pDonacion.ID;
            NombreEmpresa = pDonacion.NombreEmpresa;
            Email = pDonacion.Email;
            PrefijoTelefono = pDonacion.PrefijoTelefono;
            Telefono = pDonacion.Telefono;
            Monto = pDonacion.Monto;
        }

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
       
        [Display(Name = "Monto a Donar")]
        public int Monto { get; set; }

        //Datos de la Tarjeta

        [Required]        
        [Display(Name = "Número de Tarjeta")]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Fecha de Caducidad")]
        public int FechaCaducidad { get; set; }

        [Required]
        [Display(Name = "Código de Seguridad")]
        public int CVV { get; set; }

        [Required]
        [Display(Name = "Tipo de Tarjeta")]
        public string TipoTarjeta { get; set; }
    }
}