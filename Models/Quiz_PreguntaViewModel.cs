using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class Quiz_PreguntaViewModel
    {
        public Quiz_PreguntaViewModel()
        {

        }
        public Quiz_PreguntaViewModel(Quiz_Pregunta qp)
        {
            ID = qp.ID;
            DescripcionPregunta = qp.DescripcionPregunta;
            ComentarioAdicional = qp.ComentarioAdicional;
            QuizID = qp.QuizID;
            Quiz_Pregunta_Opcion = qp.Quiz_Pregunta_Opcion;

            Quiz = qp.Quiz;
        }
        public int ID { get; set; }
        [Display(Name = "Pregunta")]
        [Required]
        public string DescripcionPregunta { get; set; }
        public Nullable<int> QuizID { get; set; }

        public virtual Quiz Quiz { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quiz_Pregunta_Opcion> Quiz_Pregunta_Opcion { get; set; }
        public string ComentarioAdicional { get; set; }
    }
}