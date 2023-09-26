using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class AdminRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public AdminRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Usuario> ListarUsuarios(string pBusqueda, string pTipoUsuario)
        {
            List<Usuario> LU = new List<Usuario>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pTipoUsuario == "Activo" || pTipoUsuario is null)
                {
                    LU = context.Usuario.Where((u => (u.RolID == 2 && u.Activo == true) && (u.Nombre.Contains(pBusqueda) || u.Username.Contains(pBusqueda) || u.Apellido.Contains(pBusqueda)))).ToList();
                }
                else
                {
                    LU = context.Usuario.Where((u => (u.RolID == 2 && u.Activo == false) && (u.Nombre.Contains(pBusqueda) || u.Username.Contains(pBusqueda) || u.Apellido.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pTipoUsuario == "Activo" || pTipoUsuario is null)
                {
                    LU = context.Usuario.Where(u => u.RolID == 2 && u.Activo == true).ToList();
                }
                else
                {
                    LU = context.Usuario.Where(u => u.RolID == 2 && u.Activo == false).ToList();
                }
            }
            return LU;
            //return context.Usuario.Where(u => u.RolID == 2 && (u.Nombre.Contains(pBusqueda) || u.Apellido.Contains(pBusqueda) || u.Username.Contains(pBusqueda)) || pBusqueda == null).ToList();
        }

        public bool AgregarAdministrador(Usuario usuario)
        {
            Administrador a = new Administrador { Usuario = usuario };
            usuario.RolID = 2;
            usuario.Activo = true;
            context.Set<Administrador>().Add(a);

            return context.SaveChanges() > 0;
        }
        public void BajaAdministrador(int id)
        {
            Usuario user = context.Usuario.Where(u => u.ID == id).FirstOrDefault();
            user.Activo = false;
            context.SaveChanges();
        }

        public Usuario VerAdministrador(int id)
        {
            Usuario user = context.Usuario.Where(u => u.ID == id).FirstOrDefault();

            return user;
        }

        public void EditarAdministrador(Usuario usuario)
        {
            Usuario user = context.Usuario.Include("Rol").Where(u => u.ID == usuario.ID).FirstOrDefault();
            user.Username = usuario.Username;
            user.Email = usuario.Email;
            user.Nombre = usuario.Nombre;
            user.Apellido = usuario.Apellido;
            user.DNI = usuario.DNI;
            user.FechaNacimiento = usuario.FechaNacimiento;
            context.SaveChanges();
        }

        public void RehabilitarAdministrador(int id)
        {
            Usuario user = context.Usuario.Where(u => u.ID == id).FirstOrDefault();
            user.Activo = true;
            context.SaveChanges();
        }

        public void ReestablecerPassword(Usuario usuario)
        {
            Usuario user = context.Usuario.Include("Rol").Where(u => u.ID == usuario.ID).FirstOrDefault();
            user.Password = usuario.Password;
            context.SaveChanges();
        }
    }
}