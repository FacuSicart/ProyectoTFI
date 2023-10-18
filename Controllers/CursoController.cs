using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTFI.Entities;
using ProyectoTFI.Service;
using ProyectoTFI.Models;
using Newtonsoft.Json;
using PagedList;
using System.Web.UI;
using Antlr.Runtime;
using log4net;

namespace ProyectoTFI.Controllers
{
    public class CursoController : Controller
    {
        CursoService cursoService;
        AlumnoService alumnoService;
        ClaseService claseService;
        DocenteService docenteService;

        public List<Usuario> ListarDocentes()
        {
            try
            {
                docenteService = new DocenteService();
                var rta = docenteService.ListarDocentes("", "Activo");
                //string json = JsonConvert.SerializeObject(rta);

                return rta;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public ActionResult VerCursos(string pBusqueda, int? page)
        {
            cursoService = new CursoService();
            var listaCursos = cursoService.ListarCursos(pBusqueda);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaCursos.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult VerCursosDocente(string pBusqueda, int? page)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Usuario usuarioSesion = (Usuario)Session["user"];
                    cursoService = new CursoService();

                    List<CursoViewModel> listaCursos = cursoService.ListarCursosDocente(usuarioSesion.Docente.FirstOrDefault().ID, pBusqueda);

                    int pageSize = 10;
                    int pageNumber = (page ?? 1);
                    return View(listaCursos.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return View("Error", model: "No se encuentra logueado");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public ActionResult VerCursosAlumno(string pBusqueda, int? page)
        {
            if (Session["user"] != null)
            {
                Usuario usuarioSesion = (Usuario)Session["user"];
                cursoService = new CursoService();

                List<CursoViewModel> listaCursos = cursoService.ListarCursosAlumno(usuarioSesion.Alumno.FirstOrDefault().ID, pBusqueda);

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(listaCursos.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        public ActionResult VerCursosDisponibles(string pBusqueda, int? page)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Usuario usuarioSesion = (Usuario)Session["user"];
                    cursoService = new CursoService();

                    List<CursoViewModel> listaCursos = cursoService.ListarCursosDisponiblesAlumno(usuarioSesion.Alumno.FirstOrDefault().ID, pBusqueda);

                    int pageSize = 10;
                    int pageNumber = (page ?? 1);
                    return View(listaCursos.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return View("Error", model: "No se encuentra logueado");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public ActionResult VerClasesCurso(int ID, string NombreCurso, string pBusqueda, string pEstado, int? page)
        {
            if (Session["user"] != null)
            {
                claseService = new ClaseService();
                List<Clase> LC = claseService.ListarClases(pBusqueda, pEstado, ID);
                ViewBag.CursoID = ID;
                ViewBag.NombreCurso = NombreCurso;
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(LC.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        public ActionResult VerClasesSinQuiz(int ID)
        {
            claseService = new ClaseService();
            List<Clase> LC = claseService.ListarClasesSinQuiz(ID);
            return View(LC);
        }


        public ActionResult VerClasesCursoAlumno(int ID, string NombreCurso, string pBusqueda, int? page)
        {
            if (Session["user"] != null)
            {
                claseService = new ClaseService();
                List<Clase> LC = claseService.ListarClasesAlumno(pBusqueda, ID);
                ViewBag.CursoID = ID;
                ViewBag.NombreCurso = NombreCurso;
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(LC.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
        public ActionResult RegistrarCurso(int id)
        {
            if (Session["user"] != null)
            {
                cursoService = new CursoService();
                var curso = cursoService.VerCurso(id);
                return View(curso);
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
        [HttpPost]
        public ActionResult RegistrarCurso(CursoViewModel curso)
        {
            if (Session["user"] != null)
            {
                Usuario usuarioSesion = (Usuario)Session["user"];
                cursoService = new CursoService();
                alumnoService = new AlumnoService();
                cursoService.AltaCurso(curso.ID, usuarioSesion.Alumno.FirstOrDefault().ID);
                
                return RedirectToAction("VerCursosDisponibles", "Curso");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        public ActionResult AgregarCurso()
        {
            try
            {
                if (Session["user"] != null)
                {
                    Usuario usuarioSesion = (Usuario)Session["user"];
                    if (usuarioSesion.Rol.Nombre != "Administrador") { return View("Error", model: "Error de permisos, intente de nuevo"); }

                    AgregarCursoViewModel viewModel = new AgregarCursoViewModel();
                    viewModel.Docentes = ListarDocentes();

                    return View(viewModel);
                }
                else
                {
                    return View("Error", model: "No se encuentra logueado");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPost]
        public ActionResult AgregarCurso(AgregarCursoViewModel viewModel)//(string pNombre, string pDesc)//, string[] pDocentes)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Usuario usuarioSesion = (Usuario)Session["user"];
                    if (usuarioSesion.Rol.Nombre != "Administrador") { return View("Error", model: "Error de permisos, intente de nuevo"); }

                    cursoService = new CursoService();
                    //cursoService.AgregarCurso(viewModel, usuarioSesion);

                    return RedirectToAction("VerCursosDisponibles", "Curso");
                }
                else
                {
                    return View("Error", model: "No se encuentra logueado");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // GET: Curso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Curso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Curso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
