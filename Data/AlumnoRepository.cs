using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;

namespace ProyectoTFI.Data
{
    public class AlumnoRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public AlumnoRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public int ObtenterIdAlumno(int id)
        {
            Alumno alumnoId = context.Alumno.Where(a => a.UsuarioID == id).FirstOrDefault();
            return alumnoId.ID;
        }
    }
}