using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class Solicitud_RespuestaRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public Solicitud_RespuestaRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Solicitud_Respuesta> ListarSolicitudes(string pBusqueda, string pEstado)
        {
            List<Solicitud_Respuesta> LSR = new List<Solicitud_Respuesta>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pEstado == "Activo" || pEstado is null)
                {
                    LSR = context.Solicitud_Respuesta.Where(x => (x.Solicitud_Soporte.Activo == true && x.SolicitudID == null) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Solicitud_Soporte.Asunto.Contains(pBusqueda)) || (x.Solicitud_Soporte.TipoConsulta.Contains(pBusqueda)))).ToList();
                }
                else
                {
                    LSR = context.Solicitud_Respuesta.Where(x => (x.Solicitud_Soporte.Activo == true && x.SolicitudID == null) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Solicitud_Soporte.Asunto.Contains(pBusqueda)) || (x.Solicitud_Soporte.TipoConsulta.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pEstado == "Activo" || pEstado is null)
                {
                    LSR = context.Solicitud_Respuesta.Where(x => (x.Solicitud_Soporte.Activo == true && x.SolicitudID == null)).ToList();
                }
                else
                {
                    LSR = context.Solicitud_Respuesta.Where(x => (x.Solicitud_Soporte.Activo == true && x.SolicitudID == null)).ToList();
                }
            }
            return LSR;
        }

        //public List<Solicitud_Respuesta> ListarSolicitudes(string pBusqueda, string pEstado)
        //{
        //    List<Solicitud_Respuesta> LSR = new List<Solicitud_Respuesta>();
        //    if (!String.IsNullOrEmpty(pBusqueda))
        //    {
        //        if (pEstado == "Activo" || pEstado is null)
        //        {
        //            LSR = context.Solicitud_Respuesta.Where(x => x.Solicitud_Soporte.Activo == true && ((x.ID.ToString().Contains(pBusqueda)) || (x.Solicitud_Soporte.Asunto.Contains(pBusqueda)) || (x.Solicitud_Soporte.TipoConsulta.Contains(pBusqueda)))).ToList();
        //        }
        //        else
        //        {
        //            LSR = context.Solicitud_Respuesta.Where(x => x.Solicitud_Soporte.Activo == false && ((x.ID.ToString().Contains(pBusqueda)) || (x.Solicitud_Soporte.Asunto.Contains(pBusqueda)) || (x.Solicitud_Soporte.TipoConsulta.Contains(pBusqueda)))).ToList();
        //        }
        //    }
        //    else
        //    {
        //        if (pEstado == "Activo" || pEstado is null)
        //        {
        //            LSR = context.Solicitud_Respuesta.Where(x => x.Solicitud_Soporte.Activo == true).ToList();
        //        }
        //        else
        //        {
        //            LSR = context.Solicitud_Respuesta.Where(x => x.Solicitud_Soporte.Activo == false).ToList();
        //        }
        //    }
        //    return LSR;
        //}

        public bool AgregarSolicitudRespuesta(Solicitud_Respuesta pSolicitud_Respuesta)
        {
            context.Solicitud_Respuesta.Add(pSolicitud_Respuesta);

            return context.SaveChanges() > 0;
        }

        public Solicitud_Respuesta VerSolicitud(int id)
        {
            Solicitud_Respuesta Solicitud = context.Solicitud_Respuesta.Where(u => u.ID == id).FirstOrDefault();

            return Solicitud;
        }
    }
}