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
            Donacion DonacionReal = new Donacion 
            {
                NombreEmpresa = pDonacion.NombreEmpresa,
                Email = pDonacion.Email,
                PrefijoTelefono = pDonacion.PrefijoTelefono,
                Telefono = pDonacion.Telefono,
                Monto = pDonacion.Monto,
                Tarjeta = new Tarjeta 
                {
                    Tipo = pDonacion.TipoTarjeta == "Débito" ? false : true,
                    Numero = pDonacion.Numero,
                    FechaCaducidad = pDonacion.FechaCaducidad,
                    CVV = pDonacion.CVV
                }
            };
            bool Respuesta = donacionRepository.RealizarDonacion(DonacionReal);
            return Respuesta;
        }
    }
}