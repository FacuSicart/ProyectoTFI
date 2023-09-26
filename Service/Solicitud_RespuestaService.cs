using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class Solicitud_RespuestaService
    {
        Solicitud_RespuestaRepository solicitud_respuestaRepository;
        public Solicitud_RespuestaService()
        {
            solicitud_respuestaRepository = new Solicitud_RespuestaRepository();
        }

        public List<Solicitud_Respuesta> ListarSolicitudesSoporte(string pBusqueda, string pEstado)
        {
            return solicitud_respuestaRepository.ListarSolicitudes(pBusqueda, pEstado);
        }

        public bool AgregarSolicitudRespuesta(Solicitud_RespuestaViewModel solicitud)
        {
            Solicitud_Respuesta SolicitudReal = new Solicitud_Respuesta
            {
                ID = solicitud.ID,
                Descripcion = solicitud.Descripcion,
                Fecha = solicitud.Fecha,
                SolicitudID = solicitud.SolicitudID,
                AdministradorID = solicitud.AdministradorID,
                Administrador = solicitud.Administrador
            };
            bool Respuesta = solicitud_respuestaRepository.AgregarSolicitudRespuesta(SolicitudReal);
            return Respuesta;
        }

        public Solicitud_RespuestaViewModel VerSolicitud(int id)
        {
            Solicitud_Respuesta solicitud = solicitud_respuestaRepository.VerSolicitud(id);
            Solicitud_RespuestaViewModel solicitudV = new Solicitud_RespuestaViewModel(solicitud);
            return solicitudV;
        }
    }
}