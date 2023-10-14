using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class Solicitud_SoporteRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public Solicitud_SoporteRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Solicitud_Soporte> ListarSolicitudes(string pBusqueda, string pEstado, int pAlumnoID)
        {
            List<Solicitud_Soporte> LSS = new List<Solicitud_Soporte>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pEstado == "Abierto" || pEstado is null)
                {
                    LSS = context.Solicitud_Soporte.Where(x => ((x.AlumnoID == pAlumnoID) && (x.Activo == true)) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Asunto.Contains(pBusqueda)) || (x.TipoConsulta.Contains(pBusqueda)))).ToList();     
                }
                else
                {
                    LSS = context.Solicitud_Soporte.Where(x => ((x.AlumnoID == pAlumnoID) && (x.Activo == false)) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Asunto.Contains(pBusqueda)) || (x.TipoConsulta.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pEstado == "Abierto" || pEstado is null)
                {
                    LSS = context.Solicitud_Soporte.Where(x => (x.AlumnoID == pAlumnoID) && (x.Activo == true)).ToList();
                }
                else
                {
                    LSS = context.Solicitud_Soporte.Where(x => (x.AlumnoID == pAlumnoID) && (x.Activo == false)).ToList();
                }
            }
            return LSS;
        }

        public bool AgregarSolicitudSoporte(Solicitud_Soporte pSolicitud_Soporte)
        {
            pSolicitud_Soporte.Alumno = context.Alumno.Find(pSolicitud_Soporte.AlumnoID); //Hay que pasarle el Alumno con el contexto de Alumno sí o sí, sino explota
            context.Solicitud_Soporte.Add(pSolicitud_Soporte);

            return context.SaveChanges() > 0;
        }

        public Solicitud_Soporte VerSolicitud(int id)
        {
            Solicitud_Soporte Solicitud = context.Solicitud_Soporte.Where(u => u.ID == id).FirstOrDefault();
            //Solicitud_Respuesta Respuesta = context.Solicitud_Respuesta.Where(u => u.SolicitudID == Solicitud.ID).FirstOrDefault();
            //if (Respuesta != null)
            //{
            //    Solicitud.Solicitud_Respuesta.Add(Respuesta);
            //}

            return Solicitud;
        }

        public List<Solicitud_Soporte> ListarSolicitudesAdministrador(string pBusqueda, string pEstado)
        {
            List<Solicitud_Soporte> LSS = new List<Solicitud_Soporte>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pEstado == "Abierto" || pEstado is null)
                {
                    LSS = context.Solicitud_Soporte.Where(x => (x.Activo == true) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Asunto.Contains(pBusqueda)) || (x.TipoConsulta.Contains(pBusqueda)))).ToList();
                }
                else
                {
                    LSS = context.Solicitud_Soporte.Where(x => (x.Activo == false) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Asunto.Contains(pBusqueda)) || (x.TipoConsulta.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pEstado == "Abierto" || pEstado is null)
                {
                    LSS = context.Solicitud_Soporte.Where(x => (x.Activo == true)).ToList();
                }
                else
                {
                    LSS = context.Solicitud_Soporte.Where(x => (x.Activo == false)).ToList();
                }
            }
            return LSS;
        }

        public bool ResponderSolicitudSoporte(Solicitud_Soporte pSolicitud_Soporte)
        {
            //context.Solicitud_Respuesta.Add(pSolicitud_Soporte.Solicitud_Respuesta.FirstOrDefault());
            Solicitud_Soporte Solicitud = context.Solicitud_Soporte.Where(u => u.ID == pSolicitud_Soporte.ID).FirstOrDefault();
            Solicitud.Activo = false;

            return context.SaveChanges() > 0;
        }

        public bool FinalizarCaso(int pID)
        {
            Solicitud_Mensaje Mensaje = context.Solicitud_Mensaje.Where(u => u.ID == pID).FirstOrDefault();
            Mensaje.Solicitud_Soporte.Activo = false;
            return context.SaveChanges() > 0;
        }
    }
}