using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTFI.Service
{
    public class CursoService
    {
        CursoRepository cursoRepository;
        public CursoService()
        {
            cursoRepository = new CursoRepository();
        }

        public List<CursoViewModel> ListarCursos(string pBusqueda)
        {
            List<CursoViewModel> lresult = new List<CursoViewModel>();
            try
            {
                List<Curso> cursos = cursoRepository.ListarCursos(pBusqueda);

                foreach (Curso c in cursos)
                {
                    lresult.Add(new CursoViewModel(c));
                }
                return lresult;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<CursoViewModel> ListarCursosDocente(int id, string pBusqueda)
        {
            List<CursoViewModel> lresult = new List<CursoViewModel>();
            try
            {
                List<Curso> cursos = cursoRepository.ListarCursosDocente(id, pBusqueda);

                foreach (Curso c in cursos)
                {
                    lresult.Add(new CursoViewModel(c));
                }
                return lresult;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<CursoViewModel> ListarCursosAlumno(int id, string pBusqueda)
        {
            List<CursoViewModel> lresult = new List<CursoViewModel>();
            try
            {
                List<Curso> cursos = cursoRepository.ListarCursosAlumno(id, pBusqueda);

                foreach (Curso c in cursos)
                {
                    lresult.Add(new CursoViewModel(c));
                }
                return lresult;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<CursoViewModel> ListarCursosDisponiblesAlumno(int id, string pBusqueda)
        {
            List<CursoViewModel> lresult = new List<CursoViewModel>();
            try
            {
                List<Curso> cursos = cursoRepository.ListarCursosDisponiblesAlumno(id, pBusqueda);

                foreach (Curso c in cursos)
                {
                    lresult.Add(new CursoViewModel(c));
                }
                return lresult;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public CursoViewModel VerCurso(int id)
        {
            Curso curso = cursoRepository.VerCurso(id);
            CursoViewModel cursovm = new CursoViewModel(curso);
            return cursovm;
        }

        /// <summary>
        /// Agregar al alumno al curso
        /// </summary>
        /// <param name="idCurso"></param>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        public bool AltaCurso(int idCurso, int idAlumno)
        {
            bool alta = cursoRepository.AltaCurso(idCurso, idAlumno);
            return alta;
        }

        public void AgregarCurso(CursoViewModel curso, Usuario user)
        {
            try
            {
                Curso c = new Curso()
                {
                    Nombre = curso.Nombre,
                    Descripcion = curso.Descripcion,
                    Administrador = user.Administrador.FirstOrDefault(),
                    Activo = true
                };
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}