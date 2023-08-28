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
        TFIContext context;
        public UsuarioRepository()
        {
            context = new TFIContext();
        }

        public Usuario VerificarUsuario(string username, string password)
        {
            Usuario user = context.Usuario.Include("Rol").Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            return user;
        }
        public bool VerificarNombreUsuario(Usuario usuario) 
        {
            int user = context.Usuario.Where(u => u.Username == usuario.Username).Count();
            //si el nombre no existe es 0 por lo que se puede usar
            if (user == 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool CrearAlumno(Usuario usuario)
        {
            usuario.RolID = 4;
            usuario.Activo = true;
            context.Set<Usuario>().Add(usuario);
            context.SaveChanges();
            Alumno a = new Alumno();
            a.UsuarioID = usuario.ID;
            context.Set<Alumno>().Add(a);
            context.SaveChanges();
            
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else { return false; }
        }

        
    }
}