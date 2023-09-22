using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class Solicitud_SoporteViewModel
    {
        public Solicitud_SoporteViewModel()
        {
            this.Solicitud_Respuesta = new HashSet<Solicitud_Respuesta>();
        }

        public Solicitud_SoporteViewModel(Solicitud_Soporte pSoliSoporte)
        {
            ID = pSoliSoporte.ID;
            Asunto = pSoliSoporte.Asunto;
            TipoConsulta = pSoliSoporte.TipoConsulta;
            Descripcion = pSoliSoporte.Descripcion;
            Fecha = pSoliSoporte.Fecha;
            Activo = pSoliSoporte.Activo;
            AlumnoID = pSoliSoporte.AlumnoID;

            this.Solicitud_Respuesta = new HashSet<Solicitud_Respuesta>();
        }


        public int ID { get; set; }
        public string Asunto { get; set; }
        public string TipoConsulta { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public int AlumnoID { get; set; }
        public virtual ICollection<Solicitud_Respuesta> Solicitud_Respuesta { get; set; }

    }
}