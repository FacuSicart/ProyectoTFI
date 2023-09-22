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
        public ActionResult DetalleClase(int id)
        {
            claseService = new ClaseService();
            var clase = claseService.VerClase(id);
            return View(clase);
        }

        public ActionResult VerClases(string pBusqueda, string pTipoUsuario, int pClaseID, int? page)
        {
            claseService = new ClaseService();
            var listaClases = claseService.ListarClases(pBusqueda, pTipoUsuario, pClaseID);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaClases.ToPagedList(pageNumber,pageSize));
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
            claseService = new ClaseService();
            if (ModelState.IsValid)
            {
                var respuesta = claseService.AgregarClase(clase);
                return RedirectToAction("VerAdministradores", "Admin");
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
                return RedirectToAction("VerAdministradores", "Admin");
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

            bool baja = claseService.BajaClase(clase.ID);
            if (baja == true)
            {
                return RedirectToAction("VerAdministradores", "Admin");
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
        public ActionResult RehabilitarAdministrador(ClaseViewModel pClase)
        {
            claseService = new ClaseService();
            claseService.RehabilitarClase(pClase.ID);
            return RedirectToAction("VerAdministradores", "Admin");
        }
    }
}
