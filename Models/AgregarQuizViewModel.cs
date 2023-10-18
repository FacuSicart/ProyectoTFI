using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class AgregarQuizViewModel
    {
        public IEnumerable<Clase> ClaseSinQuiz{ get; set; }

        public CursoViewModel Curso { get; set; }
        public int ID { get; set; }
        [Display(Name = "Título")]
        [Required]
        public string Descripcion { get; set; }
        [Display(Name = "Porcentaje de Aprobación")]
        [Required]
        [RegularExpression(@"^[1-9][0-9]?$|^100$", ErrorMessage = "El formato de Porcentaje no es válido. Debe ser numérico (Entre 1 y 100)")]
        public Nullable<int> PorcAprobacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> ClaseID { get; set; }
        public int CursoID { get; set; }
        public string CursoNombre { get; set; }
    }
}