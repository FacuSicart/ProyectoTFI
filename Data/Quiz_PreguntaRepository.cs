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
             
        public Quiz_Pregunta VerPregunta(int id)
        {
            Quiz_Pregunta QP = context.Quiz_Pregunta.Where(c => c.ID == id).FirstOrDefault();
            return QP;
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

        public bool EditarPregunta(Quiz_Pregunta pQuiz_Pregunta)
        {
            Quiz_Pregunta QP = context.Quiz_Pregunta.Where(c => c.ID == pQuiz_Pregunta.ID).FirstOrDefault();
            QP.DescripcionPregunta = pQuiz_Pregunta.DescripcionPregunta;
            return context.SaveChanges() > 0;
        }

        public bool EditarOpcion(Quiz_Pregunta_Opcion pQuiz_Opcion)
        {
            Quiz_Pregunta_Opcion QP = context.Quiz_Pregunta_Opcion.Where(c => c.ID == pQuiz_Opcion.ID).FirstOrDefault();
            QP.DescripcionOpcion = pQuiz_Opcion.DescripcionOpcion;
            QP.Correcta = pQuiz_Opcion.Correcta;
            return context.SaveChanges() > 0;
        }

        public void BorrarPreguntaYRespuestas(int id)
        {
            Quiz_Pregunta elementosAEliminar = context.Quiz_Pregunta.Where(e => e.ID == id).FirstOrDefault();
            List<Quiz_Pregunta_Opcion> element = context.Quiz_Pregunta_Opcion.Where((e) => e.QuizPreguntaID == id).ToList();
            foreach(var elemento in element)
            {
                context.Quiz_Pregunta_Opcion.Remove(elemento);
            }
            context.Quiz_Pregunta.Remove(elementosAEliminar);
            context.SaveChanges();
        }
    }
}