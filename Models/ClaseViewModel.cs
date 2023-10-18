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
            Titulo = pClase.Titulo;
            Descripcion = pClase.Descripcion;
            LinkVideo = pClase.LinkVideo;
            Activo = pClase.Activo;
            ClaseAnteriorID = pClase.ClaseAnteriorID;
            if (pClase.Curso != null)
            {
                CursoID = pClase.Curso.ID;
                CursoNombre = pClase.Curso.Nombre;
            }

            if (LinkVideo == null)
            {
                LinkVideo = "";
            }
        }

        public int ID { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "El campo Título es obligatorio.")]
        public string Titulo { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo Descripcón es obligatorio.")]
        public string Descripcion { get; set; }

        [Display(Name = "Enlace del video")]
        public string LinkVideo { get; set; }
        public bool Activo { get; set; }
        public int CursoID { get; set; }
        public string CursoNombre { get; set; }
        public Nullable<int> ClaseAnteriorID { get; set; }
    }
}