using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class Solicitud_RespuestaViewModel
    {
        public Solicitud_RespuestaViewModel()
        {
            this.Solicitud_Soporte = new Solicitud_Soporte();
        }

        public Solicitud_RespuestaViewModel(Solicitud_Respuesta pSoliRespuesta)
        {
            ID = pSoliRespuesta.ID;
            Descripcion = pSoliRespuesta.Descripcion;
            Fecha = pSoliRespuesta.Fecha;
            SolicitudID = pSoliRespuesta.SolicitudID;
            Administrador = pSoliRespuesta.Administrador;
            AdministradorID = pSoliRespuesta.AdministradorID;

            this.Solicitud_Soporte = new Solicitud_Soporte();
        }


        public int ID { get; set; }
        [Required]
        [Display(Name = "Descripción de Respuesta")]
        public string Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Respuesta")]
        public System.DateTime Fecha { get; set; }
        public int SolicitudID { get; set; }
        public int AdministradorID { get; set; }
        public virtual Administrador Administrador { get; set; }
        public virtual Solicitud_Soporte Solicitud_Soporte { get; set; }
        [Display(Name = "Respondido por")]
        public string AdministradorUsername { get; set; }

    }
}