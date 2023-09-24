using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class ClaseViewModel
    {
        public ClaseViewModel()
        {

        }

        public ClaseViewModel(Clase pClase)
        {
            ID = pClase.ID;
            Descripcion = pClase.Descripcion;
            LinkVideo = pClase.LinkVideo;
            Activo = pClase.Activo;
            
            if (pClase.Curso != null)
            {
                CursoID = pClase.Curso.ID;
            }
        }

        public int ID { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Enlace del video")]
        public string LinkVideo { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> CursoID { get; set; }
    }
}