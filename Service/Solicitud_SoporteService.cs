using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class Solicitud_SoporteService
    {
        Solicitud_SoporteRepository solicitud_soporteRepository;
        public Solicitud_SoporteService()
        {
            solicitud_soporteRepository = new Solicitud_SoporteRepository();
        }

        public List<Solicitud_Soporte> ListarSolicitudesSoporte(string pBusqueda, string pEstado, int pAlumnoID)
        {
            return solicitud_soporteRepository.ListarSolicitudes(pBusqueda, pEstado, pAlumnoID);
        }

        public bool AgregarSolicitudSoporte(Solicitud_SoporteViewModel solicitud)
        {
            Solicitud_Soporte SolicitudReal = new Solicitud_Soporte(solicitud);
            bool Respuesta = solicitud_soporteRepository.AgregarSolicitudSoporte(SolicitudReal);
            return Respuesta;
        }

        public Solicitud_SoporteViewModel VerSolicitud(int id)
        {
            Solicitud_Soporte solicitud = solicitud_soporteRepository.VerSolicitud(id);
            Solicitud_SoporteViewModel solicitudV = new Solicitud_SoporteViewModel(solicitud);
            return solicitudV;
        }
        public List<Solicitud_Soporte> ListarSolicitudesAdministrador(string pBusqueda, string pEstado)
        {
            return solicitud_soporteRepository.ListarSolicitudesAdministrador(pBusqueda, pEstado);
        }

        public bool ResponderSolicitudSoporte(Solicitud_SoporteViewModel solicitud)
        {
            Solicitud_Soporte SolicitudReal = new Solicitud_Soporte(solicitud);
            SolicitudReal.Solicitud_Respuesta.Add(solicitud.Solicitud_Respuesta.FirstOrDefault());
            bool Respuesta = solicitud_soporteRepository.ResponderSolicitudSoporte(SolicitudReal);
            return Respuesta;
        }
    }
}