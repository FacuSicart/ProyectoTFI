﻿using System;
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
            Solicitud_Soporte SolicitudReal = new Solicitud_Soporte 
            {
                ID = solicitud.ID,
                Asunto = solicitud.Asunto,
                TipoConsulta = solicitud.TipoConsulta,
                Fecha = solicitud.Fecha,
                Activo = solicitud.Activo,
                AlumnoID = solicitud.AlumnoID,
                Alumno = solicitud.Alumno
            };
            Solicitud_Mensaje PrimerMensaje = new Solicitud_Mensaje
            {
                DescripcionAlumno = solicitud.Descripcion,
                FechaEmision = solicitud.Fecha
            };
            SolicitudReal.Solicitud_Mensaje.Add(PrimerMensaje);
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
            Solicitud_Soporte SolicitudReal = new Solicitud_Soporte
            {
                ID = solicitud.ID,
                Asunto = solicitud.Asunto,
                TipoConsulta = solicitud.TipoConsulta,
                //Descripcion = solicitud.Descripcion,
                Fecha = solicitud.Fecha,
                Activo = solicitud.Activo,
                AlumnoID = solicitud.AlumnoID,
                Alumno = solicitud.Alumno
            };
            //SolicitudReal.Solicitud_Respuesta.Add(solicitud.Solicitud_Respuesta.FirstOrDefault());
            //bool Respuesta = solicitud_soporteRepository.ResponderSolicitudSoporte(SolicitudReal);
            //return Respuesta;
            return true;
        }

        public void FinalizarCaso(Solicitud_MensajeViewModel solicitud)
        {
            solicitud_soporteRepository.FinalizarCaso(solicitud.ID);
        }
    }
}