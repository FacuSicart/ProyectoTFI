using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;

namespace ProyectoTFI.Service
{
    public class Quiz_PreguntaService
    {
        Quiz_PreguntaRepository quiz_preguntaRepository;
        public Quiz_PreguntaService()
        {
            quiz_preguntaRepository = new Quiz_PreguntaRepository();
        }

        public Quiz_PreguntaViewModel VerPregunta(int id)
        {
            Quiz_Pregunta qp = quiz_preguntaRepository.VerPregunta(id);
            Quiz_PreguntaViewModel Qpvm = new Quiz_PreguntaViewModel(qp);
            return Qpvm;
        }

        public List<Quiz_Pregunta> ListarPreguntasQuiz(string pBusqueda, int pQuizID)
        {
            return quiz_preguntaRepository.ListarPreguntasQuiz(pBusqueda, pQuizID);
        }

        public void AgregarQuiz(AgregarQuiz_PreguntaViewModel AQPVM)
        {
            Quiz_Pregunta Pregunta = new Quiz_Pregunta
            {
                DescripcionPregunta = AQPVM.DescripcionPregunta,
                QuizID = AQPVM.QuizID
            };

            quiz_preguntaRepository.AgregarPregunta(Pregunta);

            if (AQPVM.DescripcionRespuesta1 != null)
            {

                Quiz_Pregunta_Opcion Opcion = new Quiz_Pregunta_Opcion
                {
                    DescripcionOpcion = AQPVM.DescripcionRespuesta1,
                    Correcta = AQPVM.RespuestaCorrecta == "1" ? true : false,
                    QuizPreguntaID = Pregunta.ID
                };
                quiz_preguntaRepository.AgregarOpcion(Opcion);
            }

            if (AQPVM.DescripcionRespuesta2 != null)
            {
                Quiz_Pregunta_Opcion Opcion = new Quiz_Pregunta_Opcion
                {
                    DescripcionOpcion = AQPVM.DescripcionRespuesta2,
                    Correcta = AQPVM.RespuestaCorrecta == "2" ? true : false,
                    QuizPreguntaID = Pregunta.ID
                };
                quiz_preguntaRepository.AgregarOpcion(Opcion);
            }

            if (AQPVM.DescripcionRespuesta3 != null)
            {
                Quiz_Pregunta_Opcion Opcion = new Quiz_Pregunta_Opcion
                {
                    DescripcionOpcion = AQPVM.DescripcionRespuesta3,
                    Correcta = AQPVM.RespuestaCorrecta == "3" ? true : false,
                    QuizPreguntaID = Pregunta.ID
                };
                quiz_preguntaRepository.AgregarOpcion(Opcion);
            }

            if (AQPVM.DescripcionRespuesta4 != null)
            {
                Quiz_Pregunta_Opcion Opcion = new Quiz_Pregunta_Opcion
                {
                    DescripcionOpcion = AQPVM.DescripcionRespuesta4,
                    Correcta = AQPVM.RespuestaCorrecta == "4" ? true : false,
                    QuizPreguntaID = Pregunta.ID
                };
                quiz_preguntaRepository.AgregarOpcion(Opcion);
            }
        }

        public void EditarPregunta(Quiz_PreguntaViewModel Qpvm)
        {
            Quiz_Pregunta Pregunta = new Quiz_Pregunta
            {
                DescripcionPregunta = Qpvm.DescripcionPregunta
            };

            quiz_preguntaRepository.EditarPregunta(Pregunta);

           int NumeroRB = 1;

            foreach (Quiz_Pregunta_Opcion q in Qpvm.Quiz_Pregunta_Opcion)
            {
                if (q.Quiz_Respuesta != null)
                {

                    Quiz_Pregunta_Opcion Opcion = new Quiz_Pregunta_Opcion
                    {
                        DescripcionOpcion = q.Quiz_Respuesta.ToString(),
                        Correcta = q.Correcta.ToString() == NumeroRB.ToString() ? true : false,
                    };
                    quiz_preguntaRepository.EditarOpcion(Opcion);
                    NumeroRB++;
                }
            }
        }

        public void BorrarPregunta(Quiz_PreguntaViewModel Qpvm)
        {
            quiz_preguntaRepository.BorrarPreguntaYRespuestas(Qpvm.ID);
        }
    }
}