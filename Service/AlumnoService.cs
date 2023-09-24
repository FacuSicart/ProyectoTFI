using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTFI.Service
{
    public class AlumnoService
    {
        AlumnoRepository alumnoRepository;
        public AlumnoService()
        {
            alumnoRepository = new AlumnoRepository();
        }

        public int ObtenterIdAlumno(int id)
        {
            int alumnoId = alumnoRepository.ObtenterIdAlumno(id);
            return alumnoId;
        }
    }
}