using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class DocenteRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public DocenteRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Usuario> ListarDocentes(string pBusqueda, string pTipoUsuario)
        {
            List<Usuario> LU = new List<Usuario>();
            if (!String.IsNullOrEmpty(pBusqueda))
            {
                if (pTipoUsuario == "Activo" || pTipoUsuario is null)
                {
                    LU = context.Usuario.Include("Docente").Where((u => (u.RolID == 3 && u.Activo == true) && (u.Nombre.Contains(pBusqueda) || u.Username.Contains(pBusqueda) || u.Apellido.Contains(pBusqueda)))).ToList();
                }
                else
                {
                    LU = context.Usuario.Include("Docente").Where((u => (u.RolID == 3 && u.Activo == false) && (u.Nombre.Contains(pBusqueda) || u.Username.Contains(pBusqueda) || u.Apellido.Contains(pBusqueda)))).ToList();
                }
            }
            else
            {
                if (pTipoUsuario == "Activo" || pTipoUsuario is null)
                {
                    LU = context.Usuario.Include("Docente").Where(u => u.RolID == 3 && u.Activo == true).ToList();
                }
                else
                {
                    LU = context.Usuario.Include("Docente").Where(u => u.RolID == 3 && u.Activo == false).ToList();
                }
            }
            return LU;
        }

        public bool AgregarDocente(Usuario usuario)
        {
            Docente Docente = new Docente { Usuario = usuario };
            usuario.RolID = 3;
            usuario.Activo = true;
            context.Set<Docente>().Add(Docente);

            return context.SaveChanges() > 0;
        }
        public void BajaDocente(int id)
        {
            Usuario user = context.Usuario.Where(u => u.ID == id).FirstOrDefault();
            user.Activo = false;
            context.SaveChanges();
        }

        public Usuario VerDocente(int id)
        {
            Usuario user = context.Usuario.Where(u => u.ID == id).FirstOrDefault();

            return user;
        }

        public void EditarDocente(Usuario usuario)
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

        public void RehabilitarDocente(int id)
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

        public List<Usuario> GetDocentesByIds(List<int> docentesId)
        {
            try
            {
                using (var contexto = new ProyectoTFI.Entities.ProyectoTFI())
                {
                    List<Usuario> results = new List<Usuario>();

                    results = contexto.Usuario.Include("Docente").Where(u => u.RolID == 3 && u.Activo == true && docentesId.Contains(u.ID)).ToList();

                    return results;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}