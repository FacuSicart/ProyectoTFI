using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Service
{
    public class DonacionService
    {
        DonacionRepository donacionRepository;

        public DonacionService()
        {
            donacionRepository = new DonacionRepository();
        }        

        public bool RealizarDonacion(Donacion pDonacion)
        {
            bool Respuesta = donacionRepository.RealizarDonacion(pDonacion);
            return Respuesta;
        }
    }
}