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
                return View("Error", model: "Hay un error en alguno de los campos");
            }
        }

        public ActionResult Details()
        {
            if (Session["user"] != null)
            {
                Usuario usuarioSesion = (Usuario)Session["user"];
                //UsuarioViewModel usuarioModel = new UsuarioViewModel(usuarioSesion);
                usuarioService = new UsuarioService();
                var usuario = usuarioService.VerPerfil(usuarioSesion.ID);
                return View(usuario);
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        public ActionResult Edit()
        {
            if (Session["user"] != null)
            {
                Usuario usuarioSesion = (Usuario)Session["user"];
                //UsuarioViewModel usuarioModel = new UsuarioViewModel(usuarioSesion);
                usuarioService = new UsuarioService();
                var usuario = usuarioService.VerPerfil(usuarioSesion.ID);
                return View(usuario);
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }

        }
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            bool Palanca = false; //Si está en false, no permito que modifique. Si está en true sí.
            usuarioService = new UsuarioService();
            if (ModelState.IsValid)
            {
                if (!(usuarioService.ObtenerUsername(usuario.ID) == usuario.Username)) //Primero verificamos que el Nombre de Usuario no se haya modificado. Si no se modificó, no validamos el username
                {
                    //si el resultado es false existe, por lo tanto no se puede usar
                    if (usuarioService.VerificarNombreUsuario(usuario) == false)
                    {
                        ViewData["ErrorMensaje"] = "El Nombre de Usuario ingresado ya está en uso, intente con otro";
                    }
                    else { Palanca = true; } //Si todo ok, habilitamos la palanca
                }
                else { Palanca = true; } //Si todo ok, habilitamos la palanca

                if (Palanca) //Si no hay problemas de nombre o lo que sea, permitimos Editar
                {
                    usuarioService.EditarUsuario(usuario);
                    return RedirectToAction("Details", "Usuario");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        public ActionResult ReestablecerPassword()
        {
            if (Session["user"] != null)
            {
                Usuario usuarioSesion = (Usuario)Session["user"];
                //UsuarioViewModel usuarioModel = new UsuarioViewModel(usuarioSesion);
                usuarioService = new UsuarioService();
                var usuario = usuarioService.VerPerfil(usuarioSesion.ID);
                return View(usuario);
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        [HttpPost]
        public ActionResult ReestablecerPassword(UsuarioViewModel usuario)
        {
            usuarioService = new UsuarioService();
            //if (adminService.VerAdministrador(usuario.ID) != null) //No podemos usar el IsValid debido a que no contamos con los otros campos.

            if (ModelState.IsValid)
            {
                usuarioService.ReestablecerPassword(usuario);
                return RedirectToAction("Details", "Usuario");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
    }
}
