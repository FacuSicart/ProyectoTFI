using PagedList;
using ProyectoTFI.Entities;
using ProyectoTFI.Models;
using ProyectoTFI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTFI.Controllers
{
    public class Quiz_PreguntaController : Controller
    {

        Quiz_PreguntaService quiz_preguntaService;
        public ActionResult Index()
        {
            return View();
        }

        // GET: Solicitud_Respuesta/Details/5
        public ActionResult Detalle(int id)
        {
            return View();
        }
        public ActionResult Ver(int id)
        {
            quiz_preguntaService = new Quiz_PreguntaService();
            Quiz_PreguntaViewModel PreguntaQuizes = quiz_preguntaService.VerPregunta(id);
            return View(PreguntaQuizes);
        }
        public ActionResult VerPreguntasQuiz(string pBusqueda, int pQuizID, int pCursoID, string pNombreCurso, string pNombreQuiz, int? page)
        {
            quiz_preguntaService = new Quiz_PreguntaService();
            List<Quiz_Pregunta> listaPreguntasQuizes = quiz_preguntaService.ListarPreguntasQuiz(pBusqueda, pQuizID);
            ViewBag.QuizID = pQuizID;
            Session["QuizID"] = pQuizID;
            ViewBag.NombreCurso = pNombreCurso;
            Session["NombreCurso"] = pNombreCurso;
            ViewBag.NombreQuiz = pNombreQuiz;
            Session["NombreQuiz"] = pNombreQuiz;
            ViewBag.CursoID = pCursoID;
            Session["CursoID"] = pCursoID;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaPreguntasQuizes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Solicitud_Respuesta/Create
        public ActionResult Agregar(int pQuizID, string QuizNombre, int CursoID, string CursoNombre)
        {
            AgregarQuiz_PreguntaViewModel AQPVM = new AgregarQuiz_PreguntaViewModel();
            ViewBag.QuizID = pQuizID;
            ViewBag.NombreQuiz = QuizNombre;
            AQPVM.QuizID = pQuizID;
            AQPVM.NombreQuiz = QuizNombre;
            AQPVM.CursoID = CursoID;
            AQPVM.NombreCurso = CursoNombre;
            Response.Cookies.Add(new HttpCookie("NombreCurso", CursoNombre));
            Response.Cookies.Add(new HttpCookie("NombreQuiz", QuizNombre));
            return View(AQPVM);
        }

        [HttpPost]
        public ActionResult Agregar(AgregarQuiz_PreguntaViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Validaciones para evitar incoherencias
                    if ((viewModel.DescripcionRespuesta3 == "" || viewModel.DescripcionRespuesta3 == null) && (viewModel.RespuestaCorrecta == "3"))
                    {
                        ViewData["ErrorQuiz"] = "No puede seleccionar como correcta a una descripción de respuesta vacía";
                        return View(viewModel);
                    }

                    if ((viewModel.DescripcionRespuesta4 == "" || viewModel.DescripcionRespuesta4 == null) && (viewModel.RespuestaCorrecta == "4"))
                    {
                        ViewData["ErrorQuiz"] = "No puede seleccionar como correcta a una descripción de respuesta vacía";
                        return View(viewModel);
                    }

                    quiz_preguntaService = new Quiz_PreguntaService();
                    quiz_preguntaService.AgregarQuiz(viewModel);
                    ViewData["ErrorQuiz"] = null;
                    return RedirectToAction("VerPreguntasQuiz", new { pBusqueda = "", pCursoID = viewModel.CursoID, pQuizID = viewModel.QuizID, pNombreCurso = Request.Cookies["NombreCurso"]?.Value, pNombreQuiz = Request.Cookies["NombreQuiz"]?.Value });
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public ActionResult Editar(int id)
        {
            quiz_preguntaService = new Quiz_PreguntaService();
            Quiz_PreguntaViewModel PreguntaQuizes = quiz_preguntaService.VerPregunta(id);
            return View(PreguntaQuizes);
        }

        [HttpPost]
        public ActionResult Editar(Quiz_PreguntaViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    quiz_preguntaService = new Quiz_PreguntaService();
                    quiz_preguntaService.EditarPregunta(viewModel);
                    return RedirectToAction("VerPreguntasQuiz", new { pBusqueda = "", pCursoID = Session["CursoID"], pQuizID = Session["QuizID"], pNombreCurso = Request.Cookies["NombreCurso"]?.Value, pNombreQuiz = Request.Cookies["NombreQuiz"]?.Value });
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public ActionResult Borrar(int id)
        {
            quiz_preguntaService = new Quiz_PreguntaService();
            Quiz_PreguntaViewModel PreguntaQuizes = quiz_preguntaService.VerPregunta(id);
            TempData["NombreQuiz"] = PreguntaQuizes.Quiz.Descripcion;
            TempData["NombreCurso"] = PreguntaQuizes.Quiz.Clase.Curso.Nombre;

            return View(PreguntaQuizes);
        }
        [HttpPost]
        public ActionResult Borrar(Quiz_PreguntaViewModel viewModel)
        {
            quiz_preguntaService = new Quiz_PreguntaService();
            quiz_preguntaService.BorrarPregunta(viewModel);
            return RedirectToAction("VerPreguntasQuiz", new { pBusqueda = "", pCursoID = Session["CursoID"], pQuizID = Session["QuizID"], pNombreCurso = Request.Cookies["NombreCurso"]?.Value, pNombreQuiz = Request.Cookies["NombreQuiz"]?.Value });
        }


    }
}
