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
    
    public partial class Cursada_de_Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cursada_de_Alumno()
        {
            this.Quiz_Cursada_de_Alumno = new HashSet<Quiz_Cursada_de_Alumno>();
        }
    
        public int ID { get; set; }
        public Nullable<int> AlumnoID { get; set; }
        public Nullable<int> CursoID { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Curso Curso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quiz_Cursada_de_Alumno> Quiz_Cursada_de_Alumno { get; set; }
    }
}
