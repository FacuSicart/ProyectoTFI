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
            AdministradorID = pSoliRespuesta.AdministradorID;

            this.Solicitud_Soporte = new Solicitud_Soporte();
        }


        public int ID { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public int SolicitudID { get; set; }
        public int AdministradorID { get; set; }
        public virtual Solicitud_Soporte Solicitud_Soporte { get; set; }

    }
}