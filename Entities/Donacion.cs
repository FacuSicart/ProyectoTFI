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
    
    public partial class Donacion
    {
        public int ID { get; set; }
        public string NombreEmpresa { get; set; }
        public string Email { get; set; }
        public int PrefijoTelefono { get; set; }
        public int Telefono { get; set; }
        public int Monto { get; set; }
        public int TarjetaID { get; set; }
    
        public virtual Tarjeta Tarjeta { get; set; }
    }
}
