using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Data
{
    public class DonacionRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public DonacionRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public bool RealizarDonacion(Donacion pDonacion)
        {
            context.Donacion.Add(pDonacion);

            return context.SaveChanges() > 0;
        }
    }
}