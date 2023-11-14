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
            docenteRepository.EditarDocente(u);
        }

        public void RehabilitarDocente(int pID)
        {
            docenteRepository.RehabilitarDocente(pID);
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
            docenteRepository.ReestablecerPassword(u);
        }

        public List<Usuario> GetDocentesByIds(List<string> docentesId)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                List<int> docentesIdInt = new List<int>();
                if (docentesId != null)
                {
                    foreach (string s in docentesId)
                    {
                        docentesIdInt.Add(int.Parse(s));
                    }
                }

                usuarios = docenteRepository.GetDocentesByIds(docentesIdInt);
                return usuarios;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}