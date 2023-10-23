using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;
using ProyectoTFI.Tools;

namespace ProyectoTFI.Data
{
    public class QuizRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public QuizRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Quiz> ListarQuizesCurso(string pBusqueda, int pCursoID, string pEstado)
        {
            try
            {
                List<Quiz> LQ = new List<Quiz>();

                if (pEstado == "Activo" || pEstado is null)
                {
                    LQ = new List<Quiz>();
                    LQ = context.Quiz
                                .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Descripcion.ToString().Contains(pBusqueda))
                                .Where(c => c.Clase.Curso.ID == pCursoID && c.Activo == true)
                                .ToList();
                }
                else
                {
                    LQ = new List<Quiz>();
                    LQ = context.Quiz
                                .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Descripcion.ToString().Contains(pBusqueda))
                                .Where(c => c.Clase.Curso.ID == pCursoID && c.Activo == false)
                                .ToList();
                }

                return LQ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool AgregarQuiz(Quiz pQuiz)
        {
            context.Quiz.Add(pQuiz);
            return context.SaveChanges() > 0;
        }

        public bool QuizRealizado(int id)
        {
            Quiz_Respuesta resultado = context.Quiz_Respuesta.Where(c => c.ID == id).FirstOrDefault();
            if(resultado == null)
            {
                return false;
            }
            else { return true; }
        }

        public Quiz VerQuiz(int id)
        {
            Quiz Q = context.Quiz.Where(c => c.ID == id).FirstOrDefault();
            return Q;
        }

        public void EditarQuiz(Quiz quiz)
        {
            Quiz Q = context.Quiz.Where(u => u.ID == quiz.ID).FirstOrDefault();
            Q.Descripcion = quiz.Descripcion;
            Q.PorcAprobacion = quiz.PorcAprobacion;
            Q.ClaseID = quiz.ClaseID;
            context.SaveChanges();
        }

        public void BajaQuiz(int id)
        {
            Quiz Quiz = context.Quiz.Where(u => u.ID == id).FirstOrDefault();
            Quiz.Activo = false;
            context.SaveChanges();
        }

        public void RehabilitarQuiz(int id)
        {
            Quiz Quiz = context.Quiz.Where(u => u.ID == id).FirstOrDefault();
            Quiz.Activo = true;
            context.SaveChanges();
        }
    }
}