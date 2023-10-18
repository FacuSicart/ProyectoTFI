using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class QuizViewModel
    {
        public QuizViewModel()
        {

        }

        public QuizViewModel(Quiz pQuiz)
        {

        }

        public int ID { get; set; }
        [Display(Name = "Título")]
        [Required]
        public string Descripcion { get; set; }
        [Display(Name = "Porcentaje de Aprobación")]
        [Required]
        public Nullable<int> PorcAprobacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> ClaseID { get; set; }
    }
}