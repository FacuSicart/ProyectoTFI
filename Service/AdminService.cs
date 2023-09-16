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
            Usuario UsuarioReal = new Usuario(usuario);
            bool Respuesta = adminRepository.AgregarAdministrador(UsuarioReal);
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
            Usuario u = new Usuario(usuario);
            adminRepository.EditarAdministrador(u);
        }

        public void RehabilitarAdministrador(int pID)
        {
            adminRepository.RehabilitarAdministrador(pID);
        }

        public void ReestablecerPassword(UsuarioViewModel usuario)
        {
            Usuario u = new Usuario(usuario);
            adminRepository.ReestablecerPassword(u);
        }
    }
}