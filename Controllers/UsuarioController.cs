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
    public class UsuarioController : Controller
    {
        UsuarioService usuarioService;

        public ActionResult CrearAlumno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearAlumno(UsuarioViewModel usuario)
        {
            usuarioService = new UsuarioService();
            if (ModelState.IsValid)
            {
                //si el resultado es false existe, por lo tanto no se puede usar
                if (usuarioService.VerificarNombreUsuario(usuario) == false)
                {
                    ViewData["ErrorMensaje"] = "El Nombre de Usuario ingresado ya está en uso, intente con otro";
                    return View();
                    //return View("Error", model: "Ya existe ese nombre de usuario");
                }

                var respuesta = usuarioService.CrearAlumno(usuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
    }
}