using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTFI.Entities;
using ProyectoTFI.Service;

namespace ProyectoTFI.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService usuarioService;

        //Muestra la vista de Alta de Usuario/Alumno
        public ActionResult CrearAlumno()
        {
            return View();
        }
        //Alta del Usuario/Alumno
        [HttpPost]
        public ActionResult CrearAlumno(Usuario usuario)
        {
            usuarioService = new UsuarioService();
            if (ModelState.IsValid)
            {
                //si el resultado es false existe, por lo tanto no se puede usar
                if (usuarioService.VerificarNombreUsuario(usuario) == false)
                {
                    return View("Error", model: "Ya existe ese nombre de usuario");
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