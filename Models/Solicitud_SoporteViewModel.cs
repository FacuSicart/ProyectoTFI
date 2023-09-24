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
            Alumno = pSoliSoporte.Alumno;

            this.Solicitud_Respuesta = new HashSet<Solicitud_Respuesta>();
            if (pSoliSoporte.Solicitud_Respuesta.Count>0)
            {
                this.Solicitud_Respuesta.Add(pSoliSoporte.Solicitud_Respuesta.FirstOrDefault());
                FechaRespuesta = Solicitud_Respuesta.FirstOrDefault().Fecha;
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
        public ICollection<Solicitud_Respuesta> Solicitud_Respuesta { get; set; }
        public virtual Alumno Alumno { get; set; }
        [Required]
        [Display(Name = "Descripción de Respuesta")]
        public virtual string DescripcionRespuesta { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Respuesta")]
        public System.DateTime FechaRespuesta { get; set; }

    }
}