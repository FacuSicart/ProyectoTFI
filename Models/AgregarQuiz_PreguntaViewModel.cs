using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class AgregarQuiz_PreguntaViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Pregunta")]
        [Required]
        public string DescripcionPregunta { get; set; }

        [Display(Name = "Opción 1")]
        [Required]
        public string DescripcionRespuesta1 { get; set; }
        [Display(Name = "Opción 2")]
        [Required]
        public string DescripcionRespuesta2 { get; set; }
        [Display(Name = "Opción 3")]
        public string DescripcionRespuesta3 { get; set; }
        [Display(Name = "Opción 4")]
        public string DescripcionRespuesta4 { get; set; }
        public string RespuestaCorrecta { get; set; }
        public int CursoID { get; set; }
        public string NombreCurso { get; set; }
        public int QuizID { get; set; }
        public string NombreQuiz { get; set; }
    }
}