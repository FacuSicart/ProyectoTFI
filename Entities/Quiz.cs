//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTFI.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quiz()
        {
            this.Quiz_Cursada_de_Alumno = new HashSet<Quiz_Cursada_de_Alumno>();
            this.Quiz_Pregunta = new HashSet<Quiz_Pregunta>();
        }
    
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> PorcAprobacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> ClaseID { get; set; }
    
        public virtual Clase Clase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quiz_Cursada_de_Alumno> Quiz_Cursada_de_Alumno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quiz_Pregunta> Quiz_Pregunta { get; set; }
    }
}