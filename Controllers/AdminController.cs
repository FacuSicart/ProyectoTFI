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

        public ActionResult VerAdministradores()
        {
            adminService = new AdminService();
            var listaAdmins = adminService.ListarAdministradores();
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
                    ViewData["ErrorMensaje"] = "El Nombre de Usuario ingresado ya está en uso, intente con otro";
                    return View();
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
            bool Palanca = false; //Si está en false, no permito que modifique. Si está en true sí.
            adminService = new AdminService();
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
                    adminService.EditarAdministrador(usuario);
                    return RedirectToAction("VerAdministradores", "Admin");
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

        // GET: Admin/Delete/5
        public ActionResult BajaAdministrador(int id)
        {
            adminService = new AdminService();
            var usuario = adminService.VerAdministrador(id);
            return View(usuario);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult BajaAdministrador(UsuarioViewModel pUser)
        {
            adminService = new AdminService();

            if (pUser.ID == 1)
            {
                ViewData["ErrorMensaje"] = "No se puede eliminar al Administrador Principal";
                return View();
            }
            else
            {
                bool baja = adminService.BajaAdministrador(pUser.ID);
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
}
