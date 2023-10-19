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
            ID = pQuiz.ID;
            Descripcion = pQuiz.Descripcion;
            PorcAprobacion = pQuiz.PorcAprobacion;
            Activo = pQuiz.Activo;
            ClaseID = pQuiz.ClaseID;

            Clase = pQuiz.Clase;
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
        public bool Resuelto { get; set; }
        public Clase Clase { get; set; }
        public IEnumerable<Clase> ClaseSinQuiz { get; set; }
    }
}