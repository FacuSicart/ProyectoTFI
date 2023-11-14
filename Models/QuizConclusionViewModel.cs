using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class QuizConclusionViewModel
    {
        //public Quiz_Conclusion Conclusion { get; set; }

        public bool Aprobado { get; set; }
        public int TotalPreguntas { get; set; }
        public int RespuestasCorrectas { get; set; }
        public List<Quiz_Pregunta> Preguntas { get; set; }
        public List<Quiz_Respuesta> RespuestasObject { get; set; }
        public decimal Califiacion { get; set; }
        public string NombreQuiz { get; set; }
        public string Alumno { get; set; }
    }
}