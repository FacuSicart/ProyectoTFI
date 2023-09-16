using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Controllers
{
    public class HomeController : Controller
    {
        UsuarioService usuarioService;

        public HomeController()
        {
            usuarioService = new UsuarioService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        //public ActionResult Donaciones()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarUsuario(string username, string password)
        {
            Usuario user = usuarioService.VerificarUsuario(username, password);

            if (user != null)
            {
                if (user.Activo == false)
                {
                    Session["Mensaje"] = "El Usuario se encuentra deshabilitado";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    Session["user"] = user;
                    Session["Mensaje"] = null; //Limpiamos la variable de Sesion de Mensaje de Error si se logea correctamente
                    return RedirectToAction("MenuPrincipal", "Home");
                }

            }
            else
            {
                Session["Mensaje"] = "Usuario y/o Contraseña incorrecto/s";
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult MenuPrincipal()
        {
            if (Session["user"] == null)
            {
                return View("Error", model: "No se encuentra logueado");
            }
            return View(Session["user"]);
        }

        public ActionResult CerrarSesion()
        {
            Session["user"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult VolverAInicio()
        {
            return RedirectToAction("Index", "Home");
        }

        public string ListarUsuarios()
        {
            var rta = usuarioService.ListarUsuarios();

            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(rta);
            return jsonResult;
        }

    }
}