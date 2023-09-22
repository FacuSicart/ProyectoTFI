using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class ClaseService
    {
        ClaseRepository claseRepository;
        public ClaseService()
        {
            claseRepository = new ClaseRepository();
        }


        public List<Clase> ListarClases(string pBusqueda, string pTipoUsuario, int pCursoID)
        {
            return claseRepository.ListarClases(pBusqueda, pTipoUsuario, pCursoID);
        }

        public bool AgregarClase(ClaseViewModel clase)
        {
            Clase ClaseReal = new Clase(clase);
            bool Respuesta = claseRepository.AgregarClase(ClaseReal);
            return Respuesta;
        }

        public bool BajaClase(int id)
        {
            claseRepository.BajaClase(id);
            return true;
        }

        public ClaseViewModel VerClase(int id)
        {
            Clase clase = claseRepository.VerClase(id);
            ClaseViewModel claseV = new ClaseViewModel(clase);
            return claseV;
        }

        public void EditarClase(ClaseViewModel clase)
        {
            Clase Clase = new Clase(clase);
            claseRepository.EditarClase(Clase);
        }

        public void RehabilitarClase(int pID)
        {
            claseRepository.RehabilitarClase(pID);
        }
    }
}