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

        public int ID { get; set; }
        [Display(Name = "Pregunta")]
        [Required]
        public string DescripcionPregunta { get; set; }
        public Nullable<int> QuizID { get; set; }

        public virtual Quiz Quiz { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quiz_Pregunta_Opcion> Quiz_Pregunta_Opcion { get; set; }
    }
}