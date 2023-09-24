﻿using System;
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

        public List<Curso> ListarCursos(string pBusqueda)
        {
            List<Curso> LC = new List<Curso>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                LC = context.Curso
                    .Include("Cursada_de_Alumno")
                    .Where(c => c.Activo == true && c.Nombre.Contains(pBusqueda) &&
                                !context.Cursada_de_Alumno.Any(ca => ca.CursoID == c.ID))
                    .ToList();
            }
            else
            {
                LC = context.Curso
                    .Include("Cursada_de_Alumno")
                    .Where(c => c.Activo == true &&
                                !context.Cursada_de_Alumno.Any(ca => ca.CursoID == c.ID))
                    .ToList();
            }
            return LC;
            
        }
        public List<Curso> ListarCursosUsuario(int id, string pBusqueda)
        {
            List<Curso> LC = new List<Curso>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                LC = context.Curso.Where((c => (c.Activo == true) && (c.Nombre.Contains(pBusqueda)))).ToList();
            }
            else
            {
                 LC = context.Curso.Where(c => c.Activo == true).ToList();
            }
            return LC;
            
        }

        public Curso VerCurso(int id)
        {
            Curso curso = context.Curso.Where(c => c.ID == id).FirstOrDefault();

            return curso;
        }

        public bool AltaCurso(int id, int idAlumno)
        {
            Cursada_de_Alumno a = new Cursada_de_Alumno();
            a.AlumnoID = idAlumno;
            a.CursoID = id;
            context.Set<Cursada_de_Alumno>().Add(a);

            return context.SaveChanges() > 0;
        }
    }
}