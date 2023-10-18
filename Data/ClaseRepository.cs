using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;
using ProyectoTFI.Tools;

namespace ProyectoTFI.Data
{
    public class ClaseRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public ClaseRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Clase> ListarClases(string pBusqueda, string pEstado, int pCursoID)
        {
            List<Clase> LC = new List<Clase>();

            if (pEstado ==  "Activo" || pEstado is null)
            {
                LC = new List<Clase>();
                LC = context.Clase
                            .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Titulo.ToString().Contains(pBusqueda))
                            .Where(c => c.CursoID == pCursoID && c.Activo == true)
                            .ToList();
            }
            else
            {
                LC = new List<Clase>();
                LC = context.Clase
                            .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Titulo.ToString().Contains(pBusqueda))
                            .Where(c => c.CursoID == pCursoID && c.Activo == false)
                            .ToList();
            }

            return LC;
        }

        public List<Clase> ListarClasesSinQuiz(int pCursoID)
        {
            List<Clase> LC = new List<Clase>();

            LC = context.Clase
                        .Where(c => c.CursoID == pCursoID && c.Activo)
                        .Where(c => !context.Quiz.Any(q => q.ClaseID == c.ID))
                        .ToList();

            return LC;
        }

        public List<Clase> ListarClasesAlumno(int pCurso)
        {
            List<Clase> LC = new List<Clase>();

            LC = context.Clase.Where(x => ((x.Curso.ID == pCurso))).ToList();

            return LC;
        }
        public bool AgregarClase(Clase pClase)
        {
            context.Clase.Add(pClase);

            return context.SaveChanges() > 0;
        }

        public void BajaClase(int id)
        {
            Clase Clase= context.Clase.Where(u => u.ID == id).FirstOrDefault();
            Clase.Activo = false;
            context.SaveChanges();
        }

        public Clase VerClase(int id)
        {
            Clase Clase = context.Clase.Where(u => u.ID == id).FirstOrDefault();

            return Clase;
        }

        public void EditarClase(Clase clase)
        {
            Clase C = context.Clase.Where(u => u.ID == clase.ID).FirstOrDefault();
            C.Titulo = clase.Titulo;
            C.Descripcion = clase.Descripcion;
            C.LinkVideo = clase.LinkVideo;
            context.SaveChanges();
        }

        public void RehabilitarClase(int id)
        {
            Clase Clase = context.Clase.Where(u => u.ID == id).FirstOrDefault();
            Clase.Activo = true;
            context.SaveChanges();
        }
    }
}