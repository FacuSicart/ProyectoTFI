using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class DocenteService
    {
        DocenteRepository docenteRepository;
        public DocenteService()
        {
            docenteRepository = new DocenteRepository();
        }

        public List<Usuario> ListarDocentes(string pBusqueda, string pTipoUsuario)
        {
            return docenteRepository.ListarDocentes(pBusqueda, pTipoUsuario);
        }

        public bool AgregarDocente(UsuarioViewModel usuario)
        {
            Usuario UsuarioReal = new Usuario(usuario);
            bool Respuesta = docenteRepository.AgregarDocente(UsuarioReal);
            return Respuesta;
        }

        public bool BajaDocente(int id)
        {
            docenteRepository.BajaDocente(id);
            return true;
        }

        public UsuarioViewModel VerDocente(int id)
        {
            Usuario user = docenteRepository.VerDocente(id);
            UsuarioViewModel usuario = new UsuarioViewModel(user);
            return usuario;
        }

        public void EditarDocente(UsuarioViewModel usuario)
        {
            Usuario u = new Usuario(usuario);
            docenteRepository.EditarDocente(u);
        }

        public void RehabilitarDocente(int pID)
        {
            docenteRepository.RehabilitarDocente(pID);
        }

        public void ReestablecerPassword(UsuarioViewModel usuario)
        {
            Usuario u = new Usuario(usuario);
            docenteRepository.ReestablecerPassword(u);
        }
    }
}