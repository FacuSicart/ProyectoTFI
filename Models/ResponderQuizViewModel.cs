using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class ResponderQuizViewModel
    {
        public ResponderQuizViewModel()
        {
            //PreguntaRta = new Dictionary<int, string>();
        }
        public int CursoID { get; set; }
        public int QuizID { get; set; }
        public int PreguntaID { get; set; }
        public Quiz_Pregunta Pregunta { get; set; }
        public string Respuesta { get; set; }
        public int AlumnoID { get; set; }
        //public Dictionary<int, string> PreguntaRta { get; set; }
    }
}