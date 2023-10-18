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

        public ActionResult VerPreguntasQuiz(string pBusqueda, int pQuizID, int pCursoID, string pNombreCurso, string pNombreQuiz, int? page)
        {
            quiz_preguntaService = new Quiz_PreguntaService();
            List<Quiz_Pregunta> listaPreguntasQuizes = quiz_preguntaService.ListarPreguntasQuiz(pBusqueda, pQuizID);
            ViewBag.QuizID = pQuizID;
            ViewBag.NombreCurso = pNombreCurso;
            ViewBag.NombreQuiz = pNombreQuiz;
            ViewBag.CursoID = pCursoID;

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
                    quiz_preguntaService = new Quiz_PreguntaService();
                    quiz_preguntaService.AgregarQuiz(viewModel);
                    return RedirectToAction("VerPreguntasQuiz", new { pBusqueda = "", pCursoID = viewModel.CursoID, pQuizID = viewModel.QuizID, pNombreCurso = Request.Cookies["NombreCurso"]?.Value, pNombreQuiz = Request.Cookies["NombreQuiz"]?.Value });
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


    }
}
