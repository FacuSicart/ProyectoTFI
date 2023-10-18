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
    public class QuizController : Controller
    {

        QuizService quizService;
        ClaseService claseService;
        public ActionResult Index()
        {
            return View();
        }

        // GET: Solicitud_Respuesta/Details/5
        public ActionResult Detalle(int id)
        {
            return View();
        }

        public ActionResult VerQuizesCurso(string pBusqueda, int pCursoID, string pNombreCurso, int? page)
        {
            quizService = new QuizService();
            List<Quiz> listaQuizes = quizService.ListarQuizesCurso(pBusqueda, pCursoID);
            ViewBag.CursoID = pCursoID;
            ViewBag.NombreCurso = pNombreCurso;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(listaQuizes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Solicitud_Respuesta/Create
        public ActionResult Agregar(int ID, string NombreCurso)
        {
            AgregarQuizViewModel AQVM = new AgregarQuizViewModel();
            ViewBag.CursoID = ID;
            ViewBag.NombreCurso = NombreCurso;
            AQVM.CursoID = ID;
            AQVM.CursoNombre = NombreCurso;
            AQVM.ClaseSinQuiz = VerClasesSinQuiz(ID);
            return View(AQVM);
        }

        [HttpPost]
        public ActionResult Agregar(AgregarQuizViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    quizService = new QuizService();
                    quizService.AgregarQuiz(viewModel);

                    return RedirectToAction("VerQuizesCurso", new { pBusqueda = "", pCursoID = viewModel.CursoID, pNombreCurso = viewModel.CursoNombre });
                }
                else
                {
                    viewModel.ClaseSinQuiz = VerClasesSinQuiz(viewModel.CursoID);
                    return View(viewModel);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public List<Clase> VerClasesSinQuiz(int ID)
        {
            claseService = new ClaseService();
            var LC = claseService.ListarClasesSinQuiz(ID);
            return LC;
        }

        //// POST: Solicitud_Respuesta/Create
        //[HttpPost]
        //public ActionResult Agregar(Solicitud_MensajeViewModel solicitud)
        //{
        //    solicitud_mensajeService = new Solicitud_MensajeService();
        //    solicitud.FechaEmision = DateTime.Now;
        //    solicitud_mensajeService.AgregarMensaje(solicitud);
        //    //return RedirectToAction("Ver", "Solicitud_Mensaje");
        //    return RedirectToAction("Ver", new { pBusqueda = "", pTipoUsuario = "", solicitudId = solicitud.SolicitudID });
        //}


    }
}
