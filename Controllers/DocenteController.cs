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
    public class DocenteController : Controller
    {

        DocenteService docenteService;
        UsuarioService usuarioService;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Detalle(int id)
        {
            docenteService = new DocenteService();
            var usuario = docenteService.VerDocente(id);
            return View(usuario);
        }

        public ActionResult Ver(string pBusqueda, string pTipoUsuario, int? page)
        {
            docenteService = new DocenteService();
            var listaAdmins = docenteService.ListarDocentes(pBusqueda, pTipoUsuario);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaAdmins.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/Create
        public ActionResult Agregar()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Agregar(UsuarioViewModel usuario)
        {
            docenteService = new DocenteService();
            usuarioService = new UsuarioService();
            if (ModelState.IsValid)
            {
                //si el resultado es false existe, por lo tanto no se puede usar
                if (usuarioService.VerificarNombreUsuario(usuario) == false)
                {
                    ViewData["ErrorMensaje"] = "El Nombre de Usuario ingresado ya está en uso, intente con otro";
                    return View();
                }

                var respuesta = docenteService.AgregarDocente(usuario);
                return RedirectToAction("Ver", "Docente");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Editar(int id)
        {
            docenteService = new DocenteService();
            var usuario = docenteService.VerDocente(id);
            return View(usuario);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Editar(UsuarioViewModel usuario)
        {
            bool Palanca = false; //Si está en false, no permito que modifique. Si está en true sí.
            docenteService = new DocenteService();
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
                    docenteService.EditarDocente(usuario);
                    return RedirectToAction("Ver", "Docente");
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
        public ActionResult Baja(int id)
        {
            docenteService = new DocenteService();
            var usuario = docenteService.VerDocente(id);
            return View(usuario);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Baja(UsuarioViewModel pUser)
        {
            docenteService = new DocenteService();

            if (pUser.ID == 1)
            {
                ViewData["ErrorMensaje"] = "No se puede eliminar al Administrador Principal";
                return View();
            }
            else
            {
                bool baja = docenteService.BajaDocente(pUser.ID);
                if (baja == true)
                {
                    return RedirectToAction("Ver", "Docente");
                }
                else
                {
                    return View("Error", model: "No se encuentra logueado");
                }
            }
        }

        public ActionResult Rehabilitar(int id)
        {
            docenteService = new DocenteService();
            var usuario = docenteService.VerDocente(id);
            return View(usuario);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Rehabilitar(UsuarioViewModel pUser)
        {
            docenteService = new DocenteService();
            docenteService.RehabilitarDocente(pUser.ID);
            return RedirectToAction("Ver", "Docente");
        }

        // GET: Admin/Edit/5
        public ActionResult ReestablecerPassword(int id)
        {
            docenteService = new DocenteService();
            var usuario = docenteService.VerDocente(id);
            return View(usuario);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult ReestablecerPassword(UsuarioViewModel usuario)
        {
            docenteService = new DocenteService();
            usuarioService = new UsuarioService();

            if (ModelState.IsValid)
            {
                docenteService.ReestablecerPassword(usuario);
                return RedirectToAction("Ver", "Docente");
            }
            else
            {
                return View("Error", model: "No se encuentra logueado");
            }
        }
    }
}
