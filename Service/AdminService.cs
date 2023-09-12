﻿using System;
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


        public List<Usuario> ListarAdministradores(string pBuscar)
        {
            return adminRepository.ListarUsuarios(pBuscar);
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
    }
}