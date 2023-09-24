using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class CursoRepository
    {
        TFIContext context;
        public CursoRepository()
        {
            context = new TFIContext();
        }

        public List<Curso> ListarCursos(string pBusqueda, string pActivo)
        {
            List<Curso> LU = new List<Curso>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pActivo == "Activo" || pActivo is null)
                {
                    LU = context.Curso.Where((c => (c.Activo == true) && (c.Nombre.Contains(pBusqueda)))).ToList();
                }
                else
                {
                    LU = context.Curso.Where((c => (c.Activo == false) && (c.Nombre.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pActivo == "Activo" || pActivo is null)
                {
                    LU = context.Curso.Where(c => c.Activo == true).ToList();
                }
                else
                {
                    LU = context.Curso.Where(c => c.Activo == false).ToList();
                }
            }
            return LU;
            //return context.Usuario.Where(u => u.RolID == 2 && (u.Nombre.Contains(pBusqueda) || u.Apellido.Contains(pBusqueda) || u.Username.Contains(pBusqueda)) || pBusqueda == null).ToList();
        }
        public List<Curso> ListarCursosUsuario(int id, string pBusqueda, string pActivo)
        {
            List<Curso> LC = new List<Curso>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pActivo == "Activo" || pActivo is null)
                {
                    LC = context.Curso.Include("Cursada_de_Alumno").Where((c => (c.Activo == true && id == c.ID) && (c.Nombre.Contains(pBusqueda)))).ToList();
                }
                else
                {
                    LC = context.Curso.Where((c => (c.Activo == false) && (c.Nombre.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pActivo == "Activo" || pActivo is null)
                {
                    LC = context.Curso.Where(c => c.Activo == true).ToList();
                }
                else
                {
                    LC = context.Curso.Where(c => c.Activo == false).ToList();
                }
            }
            return LC;
            //return context.Usuario.Where(u => u.RolID == 2 && (u.Nombre.Contains(pBusqueda) || u.Apellido.Contains(pBusqueda) || u.Username.Contains(pBusqueda)) || pBusqueda == null).ToList();
        }

        public Curso VerCurso(int id)
        {
            Curso curso = context.Curso.Where(c => c.ID == id).FirstOrDefault();

            return curso;
        }
    }
}