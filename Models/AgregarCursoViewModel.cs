using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Models
{
    public class AgregarCursoViewModel
    {
        public IEnumerable<Usuario> Docentes { get; set; }
        public IEnumerable<Usuario> SelectedDocentes { get; set; }

        public CursoViewModel Curso { get; set; }
    }
}