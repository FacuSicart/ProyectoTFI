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
            this.Solicitud_Mensaje = new HashSet<Solicitud_Mensaje>();
        }

        public Solicitud_SoporteViewModel(Solicitud_Soporte pSoliSoporte)
        {
            ID = pSoliSoporte.ID;
            Asunto = pSoliSoporte.Asunto;
            TipoConsulta = pSoliSoporte.TipoConsulta;
            Fecha = pSoliSoporte.Fecha;
            Activo = pSoliSoporte.Activo;
            AlumnoID = pSoliSoporte.AlumnoID;
            Alumno = pSoliSoporte.Alumno;

            this.Solicitud_Mensaje = new HashSet<Solicitud_Mensaje>();
            if (pSoliSoporte.Solicitud_Mensaje.Count>0)
            {
                this.Solicitud_Mensaje.Add(pSoliSoporte.Solicitud_Mensaje.FirstOrDefault());
                //FechaRespuesta = Solicitud_Mensaje.FirstOrDefault().Fecha;
            }
        }


        public int ID { get; set; }
        [Required]
        public string Asunto { get; set; }
        [Required]
        [Display(Name = "Tipo de Consulta")]
        public string TipoConsulta { get; set; }
        [Required]
        [Display(Name = "Descripción del Problema")]
        public string Descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Emisión")]
        public System.DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public int AlumnoID { get; set; }
        public ICollection<Solicitud_Mensaje> Solicitud_Mensaje { get; set; }
        public virtual Alumno Alumno { get; set; }
        [Required]
        [Display(Name = "Descripción de Respuesta")]
        public virtual string DescripcionRespuesta { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Respuesta")]
        public System.DateTime FechaRespuesta { get; set; }

    }
}