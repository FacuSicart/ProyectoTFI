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
    
    public partial class Clase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clase()
        {
            this.Quiz = new HashSet<Quiz>();
        }
    
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> CursoID { get; set; }
    
        public virtual Curso Curso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quiz> Quiz { get; set; }
    }
}
