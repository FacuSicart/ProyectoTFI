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
        TFIContext context;
        public Solicitud_SoporteRepository()
        {
            context = new TFIContext();
        }

        public List<Solicitud_Soporte> ListarSolicitudes(string pBusqueda, string pEstado, int pAlumnoID)
        {
            List<Solicitud_Soporte> LSS = new List<Solicitud_Soporte>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pEstado == "Activo" || pEstado is null)
                {
                    LSS = context.Solicitud_Soporte.Where(x => ((x.AlumnoID == pAlumnoID) && (x.Activo == true)) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Descripcion.Contains(pBusqueda)))).ToList();     
                }
                else
                {
                    LSS = context.Solicitud_Soporte.Where(x => ((x.AlumnoID == pAlumnoID) && (x.Activo == false)) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Descripcion.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pEstado == "Activo" || pEstado is null)
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
            context.Solicitud_Soporte.Add(pSolicitud_Soporte);

            return context.SaveChanges() > 0;
        }

        public Solicitud_Soporte VerSolicitud(int id)
        {
            Solicitud_Soporte Solicitud = context.Solicitud_Soporte.Where(u => u.ID == id).FirstOrDefault();

            return Solicitud;
        }
    }
}