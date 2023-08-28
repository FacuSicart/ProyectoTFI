using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Service
{
    public class UsuarioService
    {
        UsuarioRepository usuarioRepository;

        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public Usuario VerificarUsuario(string username, string password)
        {
            Usuario user = usuarioRepository.VerificarUsuario(username, password);

            return user;
        }

        public bool VerificarNombreUsuario(Usuario usuario)
        {
            bool existe = usuarioRepository.VerificarNombreUsuario(usuario);

            return existe;
        }

        public bool CrearAlumno(Usuario usuario)
        {
            bool Respuesta = usuarioRepository.CrearAlumno(usuario);
            return Respuesta;
        }
    }
}