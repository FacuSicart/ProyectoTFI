using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTFI.Entities;
using ProyectoTFI.Service;
using ProyectoTFI.Models;
using PagedList;
using System.Web.UI;

namespace ProyectoTFI.Controllers
{
    public class CursoController : Controller
    {

        UsuarioService usarioService;
        CursoService cursoService;
        AlumnoService alumnoService;
        ClaseService claseService;
        DocenteService docenteService;

        public ActionResult VerCursosDocente(string pBusqueda, int? page)
        {
            if (Session["user"] != null)
            {
                Usuario usuarioSesion = (Usuario)Session["user"];
                //UsuarioViewModel usuarioModel = new UsuarioViewModel(usuarioSesion);
                usarioService = new UsuarioService();
                cursoService = new CursoService();
                alumnoService = new AlumnoService();
                docenteService = new DocenteService();
                var idDocente = docenteService.VerDocente(usuarioSesion.ID).ID;
                var listaCursos = cursoService.ListarCursosUsuario(idDocente, pBusqueda);

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(listaCursos.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
        public ActionResult VerCursos(string pBusqueda, int? page)
        {
            cursoService = new CursoService();
            var listaCursos = cursoService.ListarCursos(pBusqueda);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaCursos.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult VerCursosUsuario(string pBusqueda, int? page)
        {
            if (Session["user"] != null)
            {
                Usuario usuarioSesion = (Usuario)Session["user"];
                //UsuarioViewModel usuarioModel = new UsuarioViewModel(usuarioSesion);
                usarioService = new UsuarioService();
                cursoService = new CursoService();
                alumnoService = new AlumnoService();
                var idAlumno = alumnoService.ObtenterIdAlumno(usuarioSesion.ID);
                var listaCursos = cursoService.ListarCursosUsuario(idAlumno, pBusqueda);

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(listaCursos.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
            
        }
        
        public ActionResult VerClasesCurso(int ID, int? page)
        {
            if (Session["user"] != null)
            {
                claseService = new ClaseService();
                var listaClases = claseService.ListarClasesAlumno(ID);
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(listaClases.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
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
