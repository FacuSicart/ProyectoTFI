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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarUsuario(string username, string password)
        {
            usuarioService = new UsuarioService();
            Usuario user = usuarioService.VerificarUsuario(username, password);

            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("MenuPrincipal", "Home");
            }
            else
            {
                return View("Error", model:"El nombre o contraseña es incorrecto");
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
    }
}