using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class Solicitud_MensajeViewModel
    {
        public Solicitud_MensajeViewModel()
        {

        }

        public Solicitud_MensajeViewModel(Solicitud_Mensaje pSoliMensaje)
        {
            ID = pSoliMensaje.ID;
            DescripcionAlumno = pSoliMensaje.DescripcionAlumno;
            RespuestaAdministrador = pSoliMensaje.RespuestaAdministrador;
            FechaEmision = pSoliMensaje.FechaEmision;
            FechaRespuesta = pSoliMensaje.FechaRespuesta;
            SolicitudID = pSoliMensaje.SolicitudID;
            AdministradorID = pSoliMensaje.AdministradorID;

            if (pSoliMensaje.Administrador != null)
            {
                Administrador = pSoliMensaje.Administrador;
            }

            if (pSoliMensaje.Solicitud_Soporte != null)
            {
                Solicitud_Soporte = pSoliMensaje.Solicitud_Soporte;
            }
        }

        public int ID { get; set; }
        [Display(Name = "Descripción del Problema")]
        [Required]
        public string DescripcionAlumno { get; set; }
        [Display(Name = "Respuesta del Administrador")]
        [Required]
        public string RespuestaAdministrador { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Emisión")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaEmision { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "Fecha de Respuesta")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaRespuesta { get; set; }
        public int SolicitudID { get; set; }
        public Nullable<int> AdministradorID { get; set; }

        public virtual Administrador Administrador { get; set; }
        public virtual Solicitud_Soporte Solicitud_Soporte { get; set; }
    }
}