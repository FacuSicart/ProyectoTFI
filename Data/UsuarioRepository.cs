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
    }
}