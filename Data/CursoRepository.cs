using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;
using ProyectoTFI.Tools;

namespace ProyectoTFI.Data
{
    public class CursoRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public CursoRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Curso> ListarCursos(string pBusqueda, string pEstado)
        {
            try
            {
                if (pEstado=="Activo" || pEstado == null)
                {
                    List<Curso> LC = new List<Curso>();
                    LC = context.Curso
                                .Where(c => c.Activo == true)
                                .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Nombre.Contains(pBusqueda))
                                .ToList();

                    return LC;
                }
                else
                {
                    List<Curso> LC = new List<Curso>();
                    LC = context.Curso
                                .Where(c => c.Activo == false)
                                .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Nombre.Contains(pBusqueda))
                                .ToList();

                    return LC;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<Curso> ListarCursosDocente(int id, string pBusqueda)
        {
            try
            {
                List<Curso> LC = new List<Curso>();

                //LC = context.Curso.Include("Docente_Curso")
                //                  .Include("Docente_Curso.Docente")
                //                  .Where(c => c.Activo == true && c.Docente_Curso.FirstOrDefault().DocenteID == id)
                //                  .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Nombre.Contains(pBusqueda))
                //                  .ToList();

                LC = context.Curso.Include("Docente_Curso")
                                  .Include("Docente_Curso.Docente")
                                  .Where(c => c.Activo == true && c.Docente_Curso.Any(dc => dc.DocenteID == id))
                                  .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Nombre.Contains(pBusqueda))
                                  .ToList();
                return LC;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<Curso> ListarCursosAlumno(int id, string pBusqueda)
        {
            try
            {
                List<Curso> LC = new List<Curso>();
                LC = context.Curso
                            .Include("Cursada_de_Alumno")
                            .Where(c => c.Activo == true && c.Cursada_de_Alumno.Any(ca => ca.AlumnoID == id))
                            .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Nombre.Contains(pBusqueda))
                            .ToList();

                return LC;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<Curso> ListarCursosDisponiblesAlumno(int id, string pBusqueda)
        {
            try
            {
                List<Curso> LC = new List<Curso>();
                LC = context.Curso
                            .Include("Cursada_de_Alumno")
                            .Where(c => c.Activo == true && !c.Cursada_de_Alumno.Any(ca => ca.AlumnoID == id))
                            .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Nombre.Contains(pBusqueda))
                            .ToList();

                return LC;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
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

        public bool DeshabilitarCurso(Curso C)
        {
            try
            {
                Curso Curso = context.Curso.Where(c => c.ID == C.ID).FirstOrDefault();
                Curso.Activo = false;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool RehabilitarCurso(Curso C)
        {
            try
            {
                Curso Curso = context.Curso.Where(c => c.ID == C.ID).FirstOrDefault();
                Curso.Activo = true;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<Docente> VerDocentesCurso(int pID)
        {
            List<Docente> LD = new List<Docente>();
            LD = context.Docente
                            .Where(d => d.Docente_Curso.Any(dc => dc.CursoID == pID && dc.Activo == true))
                            .ToList();

            return LD;
        }

        public bool AgregarCurso(Curso C)
        {
            try
            {
                context.Curso.Add(C);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void AgregarDocenteCursos(List<Docente_Curso> dcs)
        {
            try
            {
                context.Docente_Curso.AddRange(dcs);
                context.SaveChanges();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void EditarCurso(Curso nuevo)
        {
            try
            {
                Curso viejo = context.Curso.Where(c => c.ID == nuevo.ID).FirstOrDefault();

                viejo.Nombre = nuevo.Nombre;
                viejo.Descripcion = nuevo.Descripcion;
                context.SaveChanges();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}