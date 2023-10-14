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
    public class Solicitud_MensajeController : Controller
    {

        Solicitud_MensajeService solicitud_mensajeService;
        Solicitud_SoporteService solicitud_soporteService;
        // GET: Clase
        public ActionResult Index()
        {
            return View();
        }

        // GET: Solicitud_Respuesta/Details/5
        public ActionResult Detalle(int id)
        {
            solicitud_mensajeService = new Solicitud_MensajeService();
            var solicitud = solicitud_mensajeService.VerMensaje(id);
            return View(solicitud);
        }

        public ActionResult DetalleResponder(int id)
        {
            solicitud_mensajeService = new Solicitud_MensajeService();
            var solicitud = solicitud_mensajeService.VerMensaje(id);
            return View(solicitud);
        }

        public ActionResult Ver(string pBusqueda, string asunto, int solicitudId, int? page)
        {
            solicitud_mensajeService = new Solicitud_MensajeService();
            var listaSolicitudes = solicitud_mensajeService.ListarMensajesSolicitudesSoporte(pBusqueda, solicitudId);
            ViewBag.SolicitudID = solicitudId;
            ViewBag.Asunto = asunto;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaSolicitudes.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult VerResponder(string pBusqueda, string asunto, int solicitudId, int? page)
        {
            solicitud_mensajeService = new Solicitud_MensajeService();
            var listaSolicitudes = solicitud_mensajeService.ListarMensajesSolicitudesSoporte(pBusqueda, solicitudId);
            ViewBag.SolicitudID = solicitudId;
            ViewBag.Asunto = asunto;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaSolicitudes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Solicitud_Respuesta/Create
        public ActionResult Agregar(int solicitudId, int mensajeId)
        {
            ViewBag.SolicitudID = solicitudId;
            ViewBag.MensajeID = mensajeId;
            return View();
        }

        // POST: Solicitud_Respuesta/Create
        [HttpPost]
        public ActionResult Agregar(Solicitud_MensajeViewModel solicitud)
        {
            solicitud_mensajeService = new Solicitud_MensajeService();
            solicitud.FechaEmision = DateTime.Now;
            solicitud_mensajeService.AgregarMensaje(solicitud);
            //return RedirectToAction("Ver", "Solicitud_Mensaje");
            return RedirectToAction("Ver", new { pBusqueda = "", pTipoUsuario = "", solicitudId = solicitud.SolicitudID });
        }

        public ActionResult FinalizarCaso(int solicitudId, int mensajeId)
        {
            ViewBag.SolicitudID = solicitudId;
            ViewBag.MensajeID = mensajeId;
            solicitud_mensajeService = new Solicitud_MensajeService();
            var solicitud = solicitud_mensajeService.VerMensaje(mensajeId);
            return View(solicitud);
        }

        [HttpPost]
        public ActionResult FinalizarCaso(Solicitud_MensajeViewModel solicitud)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            solicitud_soporteService.FinalizarCaso(solicitud);
            return RedirectToAction("Ver", "Solicitud_Soporte");
        }

        public ActionResult Responder(int solicitudId, int id)
        {
            solicitud_mensajeService = new Solicitud_MensajeService();
            var solicitud = solicitud_mensajeService.VerMensaje(id);
            return View(solicitud);
        }

        // POST: Solicitud_Respuesta/Create
        [HttpPost]
        public ActionResult Responder(Solicitud_MensajeViewModel solicitud)
        {
            solicitud_mensajeService = new Solicitud_MensajeService();

            solicitud.Administrador = (Administrador)((Usuario)Session["user"]).Administrador.First();
            solicitud.AdministradorID = solicitud.Administrador.ID;
            solicitud_mensajeService.Responder(solicitud);
            return RedirectToAction("VerResponder", new { pBusqueda = "", pTipoUsuario = "", solicitudId = solicitud.SolicitudID });
            //return RedirectToAction("VerPendientes", "Solicitud_Soporte");

        }

    }
}
