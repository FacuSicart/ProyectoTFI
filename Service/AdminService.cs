using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class AdminService
    {
        AdminRepository adminRepository;
        public AdminService()
        {
            adminRepository = new AdminRepository();
        }


        public List<Usuario> ListarAdministradores(string pBusqueda, string pTipoUsuario)
        {
            return adminRepository.ListarUsuarios(pBusqueda, pTipoUsuario);
        }

        public bool AgregarAdministrador(UsuarioViewModel usuario)
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
            bool Respuesta = adminRepository.AgregarAdministrador(u);
            return Respuesta;
        }

        public bool BajaAdministrador(int id)
        {
            adminRepository.BajaAdministrador(id);
            return true;
        }

        public UsuarioViewModel VerAdministrador(int id)
        {
            Usuario user = adminRepository.VerAdministrador(id);
            UsuarioViewModel usuario = new UsuarioViewModel(user);
            return usuario;
        }

        public void EditarAdministrador(UsuarioViewModel usuario)
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
            adminRepository.EditarAdministrador(u);
        }

        public void RehabilitarAdministrador(int pID)
        {
            adminRepository.RehabilitarAdministrador(pID);
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
            adminRepository.ReestablecerPassword(u);
        }
    }
}