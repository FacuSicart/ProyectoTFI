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
    public class Solicitud_RespuestaController : Controller
    {

        Solicitud_RespuestaService solicitud_respuestaService;
        Solicitud_SoporteService solicitud_soporteService;
        // GET: Clase
        public ActionResult Index()
        {
            return View();
        }

        // GET: Solicitud_Respuesta/Details/5
        public ActionResult Detalle(int id)
        {
            solicitud_respuestaService = new Solicitud_RespuestaService();
            var solicitud = solicitud_respuestaService.VerSolicitud(id);
            return View(solicitud);
        }

        public ActionResult Ver(string pBusqueda, string pTipoUsuario, int? page)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            var listaSolicitudes = solicitud_soporteService.ListarSolicitudesAdministrador(pBusqueda, pTipoUsuario);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaSolicitudes.ToPagedList(pageNumber,pageSize));
        }

        // GET: Solicitud_Respuesta/Create
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: Solicitud_Respuesta/Create
        [HttpPost]
        public ActionResult Agregar(Solicitud_RespuestaViewModel solicitud)
        {
            solicitud_respuestaService = new Solicitud_RespuestaService();
            if (ModelState.IsValid)
            {
                solicitud.Fecha = DateTime.Now;
                solicitud.Solicitud_Soporte.Activo = true;
                solicitud.Administrador = (Administrador)((Usuario)Session["user"]).Administrador.First();
                solicitud.AdministradorID = solicitud.Administrador.ID;
                var respuesta = solicitud_respuestaService.AgregarSolicitudRespuesta(solicitud);
                return RedirectToAction("Ver", "Solicitud_Respuesta");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
        
    }
}
