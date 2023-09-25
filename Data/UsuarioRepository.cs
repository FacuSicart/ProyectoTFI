using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class UsuarioRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public UsuarioRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public Usuario VerificarUsuario(string username, string password)
        {
            Usuario user = context.Usuario.Include("Rol").Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            return user;
        }
        public bool VerificarNombreUsuario(string pUsername) 
        {
            int user = context.Usuario.Count(u => u.Username == pUsername);
            //si el nombre no existe es 0 por lo que se puede usar
            if (user == 0)
            {
                return true;
            }
            else { return false; }
        }

        public string ObtenerUsername(int pID)
        {
            string Username = "";
            Usuario usuario = context.Usuario.First(x => x.ID == pID);

            if (usuario!= null)
            {
                Username = usuario.Username;
            }

            return Username;
        }

        public bool CrearAlumno(Usuario usuario)
        {
            Alumno a = new Alumno { Usuario = usuario };
            usuario.RolID = 4;
            usuario.Activo = true;
            context.Set<Alumno>().Add(a);

            return context.SaveChanges() > 0;
        }

        public List<Usuario> ListarUsuarios()
        {
            return context.Usuario.ToList();
        }

        public Usuario VerPerfil(int id)
        {
            Usuario user = context.Usuario.Where(u => u.ID == id).FirstOrDefault();

            return user;
        }

        public void EditarUsuario(Usuario usuario)
        {
            Usuario user = context.Usuario.Where(u => u.ID == usuario.ID).FirstOrDefault();
            user.Username = usuario.Username;
            user.Email = usuario.Email;
            user.Nombre = usuario.Nombre;
            user.Apellido = usuario.Apellido;
            user.DNI = usuario.DNI;
            user.FechaNacimiento = usuario.FechaNacimiento;
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
