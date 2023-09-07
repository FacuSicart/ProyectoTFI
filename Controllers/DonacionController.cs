using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTFI.Entities;
using ProyectoTFI.Service;
using ProyectoTFI.Models;

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
        public ActionResult RealizarDonacion(DonacionViewModel pDonacion)
        {
            donacionService = new DonacionService();
            if (ModelState.IsValid)
            {
                var respuesta = donacionService.RealizarDonacion(pDonacion);
                return View("Gracias", model: "La donación se realizó correctamente.");
            }
            else
            {
                return View("Error", model: "Se ha producido un error");
            }
        }

        public string CheckRadioButton(FormCollection pForm)
        {
            return pForm["TipoTarjeta"].ToString();            
        }
    }
}