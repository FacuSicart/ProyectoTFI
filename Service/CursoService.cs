using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTFI.Service
{
    public class CursoService
    {
        CursoRepository cursoRepository;
        public CursoService()
        {
            cursoRepository = new CursoRepository();
        }

        public List<Curso> ListarCursos(string pBusqueda, string pTipoUsuario)
        {
            return cursoRepository.ListarCursos(pBusqueda, pTipoUsuario);
        }
        public List<Curso> ListarCursosUsuario(int id, string pBusqueda, string pTipoUsuario)
        {
            return cursoRepository.ListarCursosUsuario(id, pBusqueda, pTipoUsuario);
        }
        public CursoViewModel VerCurso(int id)
        {
            Curso curso = cursoRepository.VerCurso(id);
            CursoViewModel cursovm = new CursoViewModel(curso);
            return cursovm;
        }
    }
}