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
    public class AdminController : Controller
    {

        AdminService adminService;
        UsuarioService usuarioService;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult DetalleAdministrador(int id)
        {
            adminService = new AdminService();
            var usuario = adminService.VerAdministrador(id);
            return View(usuario);
        }

        public ActionResult VerAdministradores(string pBuscar)
        {
            adminService = new AdminService();
            var listaAdmins = adminService.ListarAdministradores(pBuscar);
            return View(listaAdmins);
        }

        // GET: Admin/Create
        public ActionResult AgregarAdministrador()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult AgregarAdministrador(UsuarioViewModel usuario)
        {
            adminService = new AdminService();
            usuarioService = new UsuarioService();
            if (ModelState.IsValid)
            {
                //si el resultado es false existe, por lo tanto no se puede usar
                if (usuarioService.VerificarNombreUsuario(usuario) == false)
                {
                    return View("Error", model: "Ya existe ese nombre de usuario");
                }

                var respuesta = adminService.AgregarAdministrador(usuario);
                return RedirectToAction("VerAdministradores", "Admin");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult EditarAdministrador(int id)
        {
            adminService = new AdminService();
            var usuario = adminService.VerAdministrador(id);
            return View(usuario);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditarAdministrador(UsuarioViewModel usuario)
        {
            adminService = new AdminService();
            usuarioService = new UsuarioService();
            if (ModelState.IsValid)
            {
                //si el resultado es false existe, por lo tanto no se puede usar
                if (usuarioService.VerificarNombreUsuario(usuario) == false)
                {
                    return View("Error", model: "Ya existe ese nombre de usuario");
                }

                adminService.EditarAdministrador(usuario);
                return RedirectToAction("VerAdministradores", "Admin");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult BajaAdministrador()
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult BajaAdministrador(int id)
        {
            adminService = new AdminService();
            var baja = adminService.BajaAdministrador(id);
            if (baja == true)
            {
                return RedirectToAction("VerAdministradores", "Admin");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }

        }
    }
}
