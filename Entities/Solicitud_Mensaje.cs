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
    
    public partial class Solicitud_Mensaje
    {
        public int ID { get; set; }
        public string DescripcionAlumno { get; set; }
        public string RespuestaAdministrador { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public Nullable<System.DateTime> FechaRespuesta { get; set; }
        public int SolicitudID { get; set; }
        public Nullable<int> AdministradorID { get; set; }
    
        public virtual Administrador Administrador { get; set; }
        public virtual Solicitud_Soporte Solicitud_Soporte { get; set; }
    }
}