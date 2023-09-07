using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class DonacionService
    {
        DonacionRepository donacionRepository;

        public DonacionService()
        {
            donacionRepository = new DonacionRepository();
        }        

        public bool RealizarDonacion(DonacionViewModel pDonacion)
        {
            Donacion DonacionReal = new Donacion(pDonacion);
            bool Respuesta = donacionRepository.RealizarDonacion(DonacionReal);
            return Respuesta;
        }
    }
}