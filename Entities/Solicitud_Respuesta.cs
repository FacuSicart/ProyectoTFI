//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    using ProyectoTFI.Models;

    public partial class Solicitud_Respuesta
    {
        public Solicitud_Respuesta()
        {

        }

        public Solicitud_Respuesta(string pDescripcion, DateTime pFecha, int pSoliID, int pAdminID)
        {
            Descripcion = pDescripcion;
            Fecha = pFecha;
            SolicitudID = pSoliID;
            AdministradorID = pAdminID;
        }

        public Solicitud_Respuesta(Solicitud_RespuestaViewModel pSoliRespVM)
        {
            ID = pSoliRespVM.ID;
            Descripcion = pSoliRespVM.Descripcion;
            Fecha = pSoliRespVM.Fecha;
            SolicitudID = pSoliRespVM.SolicitudID;
            AdministradorID = pSoliRespVM.AdministradorID;
            Administrador = pSoliRespVM.Administrador;
        }

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public int SolicitudID { get; set; }
        public int AdministradorID { get; set; }
    
        public virtual Administrador Administrador { get; set; }
        public virtual Solicitud_Soporte Solicitud_Soporte { get; set; }
    }
}
