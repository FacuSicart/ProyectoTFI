using PagedList;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;
using ProyectoTFI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTFI.Controllers
{
    public class ClaseController : Controller
    {

        ClaseService claseService;
        // GET: Clase
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult VerClase(int id)
        {
            claseService = new ClaseService();
            var clase = claseService.VerClase(id);
            return View(clase);
        }

        // GET: Clase/Create
        public ActionResult AgregarClase()
        {
            return View();
        }

        // POST: Clase/Create
        [HttpPost]
        public ActionResult AgregarClase(ClaseViewModel clase)
        {
            clase.CursoID = (int?)Session["Curso"];
            claseService = new ClaseService();
            if (ModelState.IsValid)
            {
                var respuesta = claseService.AgregarClase(clase);
                return RedirectToAction("VerClasesCurso", "Curso", new { id = clase.CursoID });
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        // GET: Clase/Edit/5
        public ActionResult EditarClase(int id)
        {
            claseService = new ClaseService();
            var clase = claseService.VerClase(id);
            return View(clase);
        }

        // POST: Clase/Edit/5
        [HttpPost]
        public ActionResult EditarClase(ClaseViewModel clase)
        {
            claseService = new ClaseService();
            if (ModelState.IsValid)
            {
                claseService.EditarClase(clase);
                return RedirectToAction("VerClasesCurso", "Curso", new { id = clase.CursoID });
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        // GET: Clase/Delete/5
        public ActionResult BajaClase(int id)
        {
            claseService = new ClaseService();
            var clase = claseService.VerClase(id);
            return View(clase);
        }

        // POST: Clase/Delete/5
        [HttpPost]
        public ActionResult BajaClase(ClaseViewModel clase)
        {
            claseService = new ClaseService();
            clase.CursoID = (int?)Session["Curso"];
            bool baja = claseService.BajaClase(clase.ID);
            if (baja == true)
            {
                return RedirectToAction("VerClasesCurso", "Curso", new { id = clase.CursoID });
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        public ActionResult RehabilitarClase(int id)
        {
            claseService = new ClaseService();
            var clase = claseService.VerClase(id);
            return View(clase);
        }

        [HttpPost]
        public ActionResult RehabilitarClase(ClaseViewModel clase)
        {
            claseService = new ClaseService();
            claseService.RehabilitarClase(clase.ID);
            clase.CursoID = (int?)Session["Curso"];
            return RedirectToAction("VerClasesCurso", "Curso", new { id = clase.CursoID });
        }
    }
}
