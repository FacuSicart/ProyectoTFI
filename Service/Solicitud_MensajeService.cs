using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class Solicitud_MensajeService
    {
        Solicitud_MensajeRepository solicitud_mensajeRepository;
        public Solicitud_MensajeService()
        {
            solicitud_mensajeRepository = new Solicitud_MensajeRepository();
        }

        public List<Solicitud_Mensaje> ListarMensajesSolicitudesSoporte(string pBusqueda, int pSolicitudID)
        {
            return solicitud_mensajeRepository.ListarMensajesSolicitudesSoporte(pBusqueda, pSolicitudID);
        }

        public void AgregarMensaje(Solicitud_MensajeViewModel solicitud)
        {
            Solicitud_Mensaje MensajeReal = new Solicitud_Mensaje
            {
                ID = solicitud.ID,
                DescripcionAlumno = solicitud.DescripcionAlumno,
                FechaEmision = solicitud.FechaEmision,
                SolicitudID = solicitud.SolicitudID,
            };
            solicitud_mensajeRepository.AgregarMensaje(MensajeReal);
        }

        public Solicitud_MensajeViewModel VerMensaje(int id)
        {
            Solicitud_Mensaje solicitud = solicitud_mensajeRepository.VerSolicitud(id);
            Solicitud_MensajeViewModel solicitudM = new Solicitud_MensajeViewModel(solicitud);
            return solicitudM;
        }

        public void Responder(Solicitud_MensajeViewModel solicitud)
        {
            Solicitud_Mensaje MensajeReal = new Solicitud_Mensaje
            {
                ID = solicitud.ID,
                RespuestaAdministrador = solicitud.RespuestaAdministrador,
                FechaRespuesta = solicitud.FechaRespuesta,
                AdministradorID = solicitud.AdministradorID,
                SolicitudID = solicitud.SolicitudID
            };
            solicitud_mensajeRepository.Responder(MensajeReal);
        }
    }
}