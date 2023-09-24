using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class CursoViewModel
    {
        public CursoViewModel() 
        {
            
        }

        public CursoViewModel(Curso pcurso)
        {
            ID = pcurso.ID;
            Nombre = pcurso.Nombre;
            Descripcion = pcurso.Descripcion;
            Activo = pcurso.Activo;
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}