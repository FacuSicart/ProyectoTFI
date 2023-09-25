using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

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

        public bool VerificarNombreUsuario(UsuarioViewModel usuario)
        {
            bool existe = usuarioRepository.VerificarNombreUsuario(usuario.Username);

            return existe;
        }

        public string ObtenerUsername(int pID)
        {
            return usuarioRepository.ObtenerUsername(pID);
        }

        public bool CrearAlumno(UsuarioViewModel usuario)
        {
            Usuario UsuarioReal = new Usuario
            {
                ID = usuario.ID,
                Username = usuario.Username,
                Password = usuario.Password,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                DNI = usuario.DNI,
                FechaNacimiento = usuario.FechaNacimiento,
                Email = usuario.Email,
                Activo = usuario.Activo
            };
            bool Respuesta = usuarioRepository.CrearAlumno(UsuarioReal);
            return Respuesta;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = null;

            usuarios = usuarioRepository.ListarUsuarios();

            return usuarios;
        }

        public UsuarioViewModel VerPerfil(int id)
        {
            Usuario user = usuarioRepository.VerPerfil(id);
            UsuarioViewModel usuario = new UsuarioViewModel(user);
            return usuario;
        }

        public void EditarUsuario(UsuarioViewModel usuario)
        {
            Usuario u = new Usuario
            {
                ID = usuario.ID,
                Username = usuario.Username,
                Password = usuario.Password,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                DNI = usuario.DNI,
                FechaNacimiento = usuario.FechaNacimiento,
                Email = usuario.Email,
                Activo = usuario.Activo
            };
            usuarioRepository.EditarUsuario(u);
        }

        public void ReestablecerPassword(UsuarioViewModel usuario)
        {
            Usuario u = new Usuario
            {
                ID = usuario.ID,
                Username = usuario.Username,
                Password = usuario.Password,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                DNI = usuario.DNI,
                FechaNacimiento = usuario.FechaNacimiento,
                Email = usuario.Email,
                Activo = usuario.Activo
            };
            usuarioRepository.ReestablecerPassword(u);
        }
    }
}
