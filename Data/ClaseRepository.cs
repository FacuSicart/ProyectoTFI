using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class ClaseRepository
    {
        TFIContext context;
        public ClaseRepository()
        {
            context = new TFIContext();
        }

        public List<Clase> ListarClases(string pBusqueda, string pEstado, int pCurso)
        {
            List<Clase> LC = new List<Clase>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pEstado == "Activo" || pEstado is null)
                {
                    LC = context.Clase.Where(x => ((x.Curso.ID == pCurso) && (x.Activo == true)) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Descripcion.Contains(pBusqueda)))).ToList();     
                }
                else
                {
                    LC = context.Clase.Where(x => ((x.Curso.ID == pCurso) && (x.Activo == false)) && ((x.ID.ToString().Contains(pBusqueda)) || (x.Descripcion.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pEstado == "Activo" || pEstado is null)
                {
                    LC = context.Clase.Where(x => (x.Curso.ID == pCurso) && (x.Activo == true)).ToList();
                }
                else
                {
                    LC = context.Clase.Where(x => (x.Curso.ID == pCurso) && (x.Activo == false)).ToList();
                }
            }
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