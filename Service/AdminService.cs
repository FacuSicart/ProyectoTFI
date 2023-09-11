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


        public List<Usuario> ListarAdministradores()
        {
            return adminRepository.ListarUsuarios();
        }
        public bool CrearAdministrador(UsuarioViewModel usuario)
        {
            Usuario UsuarioReal = new Usuario(usuario);
            bool Respuesta = adminRepository.CrearAdministrador(UsuarioReal);
            return Respuesta;
        }
    }
}