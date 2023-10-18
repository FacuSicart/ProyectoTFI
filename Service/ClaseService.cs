using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class ClaseService
    {
        ClaseRepository claseRepository;
        public ClaseService()
        {
            claseRepository = new ClaseRepository();
        }


        public List<Clase> ListarClases(string pBusqueda, string pTipoUsuario, int pCursoID)
        {
            return claseRepository.ListarClases(pBusqueda, pTipoUsuario, pCursoID);
        }
        public List<Clase> ListarClasesSinQuiz(int pCursoID)
        {
            return claseRepository.ListarClasesSinQuiz(pCursoID);
        }

        public List<Clase> ListarClasesAlumno(int pCursoID)
        public List<Clase> ListarClasesAlumno(string pBusqueda, int pCursoID)
        {
            return claseRepository.ListarClasesAlumno(pBusqueda, pCursoID);
        }
        public bool AgregarClase(ClaseViewModel clase)
        {
            Clase ClaseReal = new Clase
            {
                ID = clase.ID,
                Titulo = clase.Titulo,
                Descripcion = clase.Descripcion,
                LinkVideo = clase.LinkVideo == null ? "" : clase.LinkVideo,
                Activo = true,
                CursoID = clase.CursoID,
                ClaseAnteriorID = clase.ClaseAnteriorID
            };
            bool Respuesta = claseRepository.AgregarClase(ClaseReal);
            return Respuesta;
        }

        public bool BajaClase(int id)
        {
            claseRepository.BajaClase(id);
            return true;
        }

        public ClaseViewModel VerClase(int id, string orden = null)
        {
            Clase clase = claseRepository.VerClase(id, orden);
            ClaseViewModel claseV = new ClaseViewModel(clase);
            return claseV;
        }

        public void EditarClase(ClaseViewModel clase)
        {
            Clase Clase = new Clase
            {
                ID = clase.ID,
                Titulo = clase.Titulo,
                Descripcion = clase.Descripcion,
                LinkVideo = clase.LinkVideo == null? "" : clase.LinkVideo,
                Activo = clase.Activo,
                CursoID = clase.CursoID
            };
            claseRepository.EditarClase(Clase);
        }

        public void RehabilitarClase(int pID)
        {
            claseRepository.RehabilitarClase(pID);
        }
    }
}