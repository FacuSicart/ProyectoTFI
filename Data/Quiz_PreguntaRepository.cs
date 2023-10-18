using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Service;
using ProyectoTFI.Entities;
using ProyectoTFI.Tools;

namespace ProyectoTFI.Data
{
    public class Quiz_PreguntaRepository
    {
        ProyectoTFI.Entities.ProyectoTFI context;
        public Quiz_PreguntaRepository()
        {
            context = new ProyectoTFI.Entities.ProyectoTFI();
        }

        public List<Quiz_Pregunta> ListarPreguntasQuiz(string pBusqueda, int pQuizID)
        {
            try
            {
                List<Quiz_Pregunta> LQP = new List<Quiz_Pregunta>();
                LQP = context.Quiz_Pregunta
                            .WhereIf(!String.IsNullOrEmpty(pBusqueda), c => c.DescripcionPregunta.ToString().Contains(pBusqueda))
                            .Where(c => c.QuizID == pQuizID)
                            .ToList();

                return LQP;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
             
        public bool AgregarPregunta(Quiz_Pregunta pQuiz_Pregunta)
        {
            context.Quiz_Pregunta.Add(pQuiz_Pregunta);
            return context.SaveChanges() > 0;
        }

        public bool AgregarOpcion(Quiz_Pregunta_Opcion pQuiz_Opcion)
        {
            context.Quiz_Pregunta_Opcion.Add(pQuiz_Opcion);
            return context.SaveChanges() > 0;
        }
    }
}