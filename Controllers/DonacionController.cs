using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTFI.Entities;
using ProyectoTFI.Service;

namespace ProyectoTFI.Controllers
{
    public class DonacionController : Controller
    {
        DonacionService donacionService;
        public ActionResult RealizarDonacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RealizarDonacion(Donacion pDonacion)
        {
            donacionService = new DonacionService();
            if (ModelState.IsValid)
            {
                var respuesta = donacionService.RealizarDonacion(pDonacion);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error", model: "Se ha producido un error");
            }
        }
    }
}