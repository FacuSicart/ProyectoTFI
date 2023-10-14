using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;
using ProyectoTFI.Tools;

namespace ProyectoTFI.Data
{
    public class Solicitud_MensajeRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public Solicitud_MensajeRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Solicitud_Mensaje> ListarMensajesSolicitudesSoporte(string pBusqueda, int pSolicitudID)
        {
            try
            {
                List<Solicitud_Mensaje> LM = new List<Solicitud_Mensaje>();
                LM = context.Solicitud_Mensaje
                            .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.ID.ToString().Contains(pBusqueda))
                            .Where(c => c.SolicitudID == pSolicitudID)
                            .ToList();

                return LM;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
             
        public Solicitud_Mensaje VerSolicitud(int pID)
        {
            Solicitud_Mensaje Solicitud = context.Solicitud_Mensaje.Where(u => u.ID == pID).FirstOrDefault();

            return Solicitud;
        }
        public bool AgregarMensaje(Solicitud_Mensaje pMensaje)
        {
            context.Solicitud_Mensaje.Add(pMensaje);
            return context.SaveChanges() > 0;
        }
        public bool Responder(Solicitud_Mensaje pMensaje)
        {
            Solicitud_Mensaje Mensaje = context.Solicitud_Mensaje.Where(u => u.ID == pMensaje.ID).FirstOrDefault();
            Mensaje.RespuestaAdministrador = pMensaje.RespuestaAdministrador;
            Mensaje.FechaRespuesta = DateTime.Now;
            Mensaje.AdministradorID = pMensaje.AdministradorID;
            return context.SaveChanges() > 0;
        }
    }
}