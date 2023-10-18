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

        public List<Quiz> ListarQuizesCurso(string pBusqueda, int pCursoID)
        {
            try
            {
                List<Quiz> LQ = new List<Quiz>();
                LQ = context.Quiz
                            .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.Descripcion.ToString().Contains(pBusqueda))
                            .Where(c => c.Clase.Curso.ID == pCursoID)
                            .ToList();

                return LQ;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
             
        public Solicitud_Mensaje VerSolicitud(int pID)
        {
            Solicitud_Mensaje Solicitud = context.Solicitud_Mensaje.Where(u => u.ID == pID).FirstOrDefault();

            return Solicitud;
        }
        public bool AgregarQuiz(Quiz pQuiz)
        {
            context.Quiz.Add(pQuiz);
            return context.SaveChanges() > 0;
        }
    }
}