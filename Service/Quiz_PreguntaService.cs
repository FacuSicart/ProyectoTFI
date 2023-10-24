using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoTFI.Data;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTFI.Service
{
    public class Quiz_PreguntaService
    {
        Quiz_PreguntaRepository quiz_preguntaRepository;
        public Quiz_PreguntaService()
        {
            quiz_preguntaRepository = new Quiz_PreguntaRepository();
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

        public void GuardarRespuesta(ResponderQuizViewModel rqvm)
        {
            try
            {
                CursoService cs = new CursoService();

                List<Curso> misCursos = cs.ListarCursosAlumnoEntity(rqvm.AlumnoID, "");
                List<Cursada_de_Alumno> cursadas = misCursos.Find(c => c.ID == rqvm.CursoID).Cursada_de_Alumno.ToList();

                var miCursada = cursadas.Find(ca => ca.AlumnoID == rqvm.AlumnoID);

                QuizService qs = new QuizService();
                Quiz quiz = qs.ListarQuizesCurso("", rqvm.CursoID).Find(q => q.ID == rqvm.QuizID);

                Quiz_Cursada_de_Alumno qca = quiz_preguntaRepository.GetQuizCursada(miCursada.ID, quiz.ID);

                Quiz_Respuesta qr = new Quiz_Respuesta
                {
                    QuizPreguntaOpcionID = int.Parse(rqvm.Respuesta),
                    QuizCursadaDeAlumnoID = qca.ID
                };

                quiz_preguntaRepository.GuardarRespuesta(qr);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void GuardarRespuestaFirstTime(ResponderQuizViewModel rqvm)
        {
            try
            {
                CursoService cs = new CursoService();

                List<Curso> misCursos = cs.ListarCursosAlumnoEntity(rqvm.AlumnoID, "");
                List<Cursada_de_Alumno> cursadas = misCursos.Find(c => c.ID == rqvm.CursoID).Cursada_de_Alumno.ToList();

                var miCursada = cursadas.Find(ca => ca.AlumnoID == rqvm.AlumnoID);

                QuizService qs = new QuizService();
                Quiz quiz = qs.ListarQuizesCurso("", rqvm.CursoID).Find(q => q.ID == rqvm.QuizID);

                Quiz_Cursada_de_Alumno qca = new Quiz_Cursada_de_Alumno
                {
                    CursadaDeAlumnoID = miCursada.ID,
                    QuizID = quiz.ID
                };

                //quiz_preguntaRepository.GuardarQuizCursada(qca);

                Quiz_Respuesta qr = new Quiz_Respuesta
                {
                    QuizPreguntaOpcionID = int.Parse(rqvm.Respuesta),
                    Quiz_Cursada_de_Alumno = qca
                };

                quiz_preguntaRepository.GuardarRespuesta(qr);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public Quiz_Cursada_de_Alumno GetQuizCursada(ResponderQuizViewModel rqvm)
        {
            try
            {
                CursoService cs = new CursoService();

                List<Curso> misCursos = cs.ListarCursosAlumnoEntity(rqvm.AlumnoID, "");
                List<Cursada_de_Alumno> cursadas = misCursos.Find(c => c.ID == rqvm.CursoID).Cursada_de_Alumno.ToList();

                var miCursada = cursadas.Find(ca => ca.AlumnoID == rqvm.AlumnoID);

                QuizService qs = new QuizService();
                Quiz quiz = qs.ListarQuizesCurso("", rqvm.CursoID).Find(q => q.ID == rqvm.QuizID);

                Quiz_Cursada_de_Alumno qca = quiz_preguntaRepository.GetQuizCursada(miCursada.ID, quiz.ID);

                return qca;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public QuizConclusionViewModel GetQuizConclusion(ResponderQuizViewModel rqvm)
        {
            try
            {
                Quiz_Cursada_de_Alumno qca = GetQuizCursada(rqvm);

                Quiz_Conclusion conclusion = new Quiz_Conclusion
                {
                    Fecha = DateTime.Today,
                    QuizCursadaDeAlumno = qca.ID,
                    Clasificacion = 0,
                    Aprobado = false
                };

                //qcvm.Conclusion = conclusion;

                List<Quiz_Respuesta> respuestas = qca.Quiz_Respuesta.ToList();

                decimal total = respuestas.Count;
                decimal correctas = 0;
                foreach (Quiz_Respuesta respuesta in respuestas)
                {
                    if (respuesta.Quiz_Pregunta_Opcion.Correcta.Value)
                    {
                        correctas++;
                    }
                }
                decimal calificacion = correctas / total * 10;

                conclusion.Clasificacion = (int)calificacion;

                decimal notaMinima = qca.Quiz.PorcAprobacion.Value / 10;
                conclusion.Aprobado = calificacion >= notaMinima;

                //quiz_preguntaRepository.GuardarConclusion(conclusion);

                QuizConclusionViewModel qcvm = new QuizConclusionViewModel
                {
                    Aprobado = conclusion.Aprobado.Value,
                    Califiacion = conclusion.Clasificacion.Value,
                    RespuestasCorrectas = (int)correctas,
                    TotalPreguntas = (int)total,
                    Preguntas = qca.Quiz.Quiz_Pregunta.ToList(),
                    NombreQuiz = qca.Quiz.Descripcion
                };

                return qcvm;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}