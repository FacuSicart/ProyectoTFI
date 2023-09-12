using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {

        }

        public UsuarioViewModel(Usuario pUsuario)
        {
            ID = pUsuario.ID;
            Username = pUsuario.Username;
            Password = pUsuario.Password;
            ConfirmarPassword = pUsuario.Password;
            Nombre = pUsuario.Nombre;
            Apellido = pUsuario.Apellido;
            DNI = pUsuario.DNI;
            FechaNacimiento = pUsuario.FechaNacimiento;
            Email = pUsuario.Email;
            Activo = pUsuario.Activo;
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Número de Documento")]
        public string DNI { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "El Formato del Correo Electrónico es incorrecto.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El Formato del Correo Electrónico es incorrecto.")]
        public string Email { get; set; }
        public bool? Activo { get; set; }
    }
}