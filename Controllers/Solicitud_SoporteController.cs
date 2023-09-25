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

        public ActionResult DetalleRespondido(int id)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            var solicitud = solicitud_soporteService.VerSolicitud(id);
            return View(solicitud);
        }

        public ActionResult Ver(string pBusqueda, string pEstado, int? page)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            var listaSolicitudes = solicitud_soporteService.ListarSolicitudesSoporte(pBusqueda, pEstado, ((Alumno)((Usuario)Session["user"]).Alumno.First()).ID);

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
            ModelState.Remove("DescripcionRespuesta");
            solicitud_soporteService = new Solicitud_SoporteService();
            if (ModelState.IsValid)
            {
                solicitud.Fecha = DateTime.Now;
                solicitud.Activo = true;
                solicitud.Alumno = (Alumno)((Usuario)Session["user"]).Alumno.First();
                solicitud.AlumnoID = solicitud.Alumno.ID;
                var respuesta = solicitud_soporteService.AgregarSolicitudSoporte(solicitud);
                return RedirectToAction("Ver", "Solicitud_Soporte");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        public ActionResult VerPendientes(string pBusqueda, string pEstado, int? page)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            var listaSolicitudes = solicitud_soporteService.ListarSolicitudesAdministrador(pBusqueda, pEstado);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaSolicitudes.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Responder(int id)
        {
            solicitud_soporteService = new Solicitud_SoporteService();
            var solicitud = solicitud_soporteService.VerSolicitud(id);
            return View(solicitud);
        }

        // POST: Clase/Edit/5
        [HttpPost]
        public ActionResult Responder(Solicitud_SoporteViewModel solicitud, string DescripcionRespuesta)
        {
            Solicitud_Respuesta SR = new Solicitud_Respuesta
            {
                Descripcion = DescripcionRespuesta,
                Fecha = DateTime.Now,
                SolicitudID = solicitud.ID,
                AdministradorID = ((Usuario)Session["user"]).Administrador.First().ID
            };
            solicitud.Solicitud_Respuesta.Add(SR);
            solicitud_soporteService = new Solicitud_SoporteService();
            solicitud_soporteService.ResponderSolicitudSoporte(solicitud);
            return RedirectToAction("VerPendientes", "Solicitud_Soporte");
            //if (ModelState.IsValid)
            //{

            //}
            //else
            //{
            //    return View("Error", model: "No se encuentra logueado");
            //}
        }

    }
}
