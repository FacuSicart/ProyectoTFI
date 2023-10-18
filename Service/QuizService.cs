using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class QuizService
    {
        QuizRepository quizRepository;
        public QuizService()
        {
            quizRepository = new QuizRepository();
        }

        public List<Quiz> ListarQuizesCurso(string pBusqueda, int pCursoID)
        {
            return quizRepository.ListarQuizesCurso(pBusqueda, pCursoID);
        }

        public void AgregarQuiz(AgregarQuizViewModel AQVM)
        {
            Quiz quiz = new Quiz
            {
                ID = AQVM.ID,
                Descripcion = AQVM.Descripcion,
                PorcAprobacion = AQVM.PorcAprobacion,
                Activo = true,
                ClaseID = AQVM.ClaseID
            };
            quizRepository.AgregarQuiz(quiz);
        }
    }
}