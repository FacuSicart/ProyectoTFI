//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quiz_Cursada_de_Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quiz_Cursada_de_Alumno()
        {
            this.Quiz_Respuesta = new HashSet<Quiz_Respuesta>();
        }
    
        public int ID { get; set; }
        public Nullable<int> CursadaDeAlumnoID { get; set; }
        public Nullable<int> QuizID { get; set; }
    
        public virtual Cursada_de_Alumno Cursada_de_Alumno { get; set; }
        public virtual Quiz Quiz { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quiz_Respuesta> Quiz_Respuesta { get; set; }
    }
}
