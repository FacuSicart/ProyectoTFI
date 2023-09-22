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
    public class Solicitud_SoporteController : Controller
    {

        Solicitud_SoporteService solicitud_soporteService;
        // GET: Clase
        public ActionResult Index()
        {
            return View();
        }

        // GET: Solicitud_Soporte/Details/5
        public ActionResult Detalle(int id)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            var solicitud = solicitud_soporteService.VerSolicitud(id);
            return View(solicitud);
        }

        public ActionResult Ver(string pBusqueda, string pTipoUsuario, int? page)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            var listaSolicitudes = solicitud_soporteService.ListarSolicitudesSoporte(pBusqueda, pTipoUsuario, ((Usuario)Session["user"]).ID);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaSolicitudes.ToPagedList(pageNumber,pageSize));
        }

        // GET: Solicitud_Soporte/Create
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: Solicitud_Soporte/Create
        [HttpPost]
        public ActionResult Agregar(Solicitud_SoporteViewModel solicitud)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            if (ModelState.IsValid)
            {
                var respuesta = solicitud_soporteService.AgregarSolicitudSoporte(solicitud);
                return RedirectToAction("Ver", "Solicitud_Soporte");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
        
    }
}
