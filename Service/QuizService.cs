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

        public List<QuizViewModel> ListarQuizesCurso(string pBusqueda, int pCursoID)
        {
            List<QuizViewModel> LQvm = new List<QuizViewModel>();
            foreach (Quiz q in quizRepository.ListarQuizesCurso(pBusqueda, pCursoID))
            {
                bool resuelto = quizRepository.QuizRealizado(q.ID);
                QuizViewModel Qvm = new QuizViewModel(q);
                Qvm.Resuelto = resuelto;
                LQvm.Add(Qvm);
            }
            return LQvm;
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
        public QuizViewModel VerQuiz(int id)
        {
            QuizViewModel Qvm = new QuizViewModel(quizRepository.VerQuiz(id));
            ClaseService claseService = new ClaseService();
            Qvm.ClaseSinQuiz = claseService.ListarClasesSinQuiz(Qvm.Clase.CursoID);
            return Qvm;
        }

        public void EditarQuiz(QuizViewModel AQVM)
        {
            Quiz quiz = new Quiz
            {
                ID = AQVM.ID,
                Descripcion = AQVM.Descripcion,
                PorcAprobacion = AQVM.PorcAprobacion,
                Activo = true,
                ClaseID = AQVM.ClaseID
            };
            quizRepository.EditarQuiz(quiz);
        }
        public void BajaQuiz(int id)
        {
            quizRepository.BajaQuiz(id);
        }
        public void RehabilitarQuiz(int id)
        {
            quizRepository.RehabilitarQuiz(id);
        }
    }
}