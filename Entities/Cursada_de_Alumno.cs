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
