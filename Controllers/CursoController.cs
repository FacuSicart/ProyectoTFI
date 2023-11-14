﻿using System;
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

        public ActionResult VerCursos(string pBusqueda, string pEstado, int? page)
        {
            cursoService = new CursoService();
            var listaCursos = cursoService.ListarCursos(pBusqueda, pEstado);

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
                    List<Usuario> LD = new List<Usuario>();
                    viewModel.SelectedDocentes = LD.ToList();

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
        //public ActionResult AgregarCurso(AgregarCursoViewModel viewModel)//(string pNombre, string pDesc)//, string[] pDocentes)
        public JsonResult AgregarCurso(string pNombre, string pDesc, List<string> docentesId)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Usuario usuarioSesion = (Usuario)Session["user"];
                    if (usuarioSesion.Rol.Nombre != "Administrador") { return null;/*return "Error de permisos, intente de nuevo";*/ }

                    docenteService = new DocenteService();
                    List<Usuario> docentes = docenteService.GetDocentesByIds(docentesId);

                    cursoService = new CursoService();
                    cursoService.AgregarCurso(pNombre, pDesc, usuarioSesion, docentes);

                    var listaCursos = cursoService.ListarCursos("", "Activo");

                    int pageSize = 10;
                    int pageNumber = 1;

                    //string lresult = JsonConvert.SerializeObject(new { redirectToUrl = Url.Action("VerCursos", "Curso", listaCursos.ToPagedList(pageNumber, pageSize))});

                    return Json(new { redirectToUrl = Url.Action("VerCursos", "Curso", listaCursos.ToPagedList(pageNumber, pageSize)) });
                    //return lresult;
                    //return View("VerCursos", listaCursos.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return null;
                    //return "Error: No se encuentra logueado";
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public ActionResult EditarCurso(int id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    cursoService = new CursoService();
                    CursoViewModel curso = cursoService.VerCurso(id);
                    return View(curso);
                }
                else
                {
                    return View("Error", model: "No se encuentra logueado");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPost]
        public ActionResult EditarCurso(CursoViewModel cvm)
        {
            try
            {
                if (Session["user"] != null)
                {
                    cursoService = new CursoService();
                    cursoService.EditarCurso(cvm);
                    return RedirectToAction("VerCursos");
                }
                else
                {
                    return View("Error", model: "No se encuentra logueado");
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // GET: Curso/Details/5
        public ActionResult Ver(int id)
        {
            cursoService = new CursoService();
            var curso = cursoService.VerCurso(id);
            curso.Docentes = cursoService.VerDocenteCurso(id);

            return View(curso);
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
        public ActionResult Baja(int id)
        {
            cursoService = new CursoService();
            var curso = cursoService.VerCurso(id);
            curso.Docentes = cursoService.VerDocenteCurso(id);            

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost]
        public ActionResult Baja(CursoViewModel VM)
        {
            try
            {
                cursoService = new CursoService();
                Curso C = new Curso();
                C.ID = VM.ID;
                cursoService.DeshabilitarCurso(C);
                return RedirectToAction("VerCursos");
            }
            catch
            {
                return View(VM.ID);
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Rehabilitar(int id)
        {
            cursoService = new CursoService();
            var curso = cursoService.VerCurso(id);
            curso.Docentes = cursoService.VerDocenteCurso(id);

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost]
        public ActionResult Rehabilitar(CursoViewModel VM)
        {
            try
            {
                cursoService = new CursoService();
                Curso C = new Curso();
                C.ID = VM.ID;
                cursoService.RehabilitarCurso(C);
                return RedirectToAction("VerCursos");
            }
            catch
            {
                return View(VM.ID);
            }
        }
    }
}
