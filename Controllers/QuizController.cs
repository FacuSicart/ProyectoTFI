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
        public ActionResult VerQuiz(int id)
        {
            quizService = new QuizService();
            QuizViewModel Qvm = quizService.VerQuiz(id);
            return View(Qvm);
        }

        public ActionResult VerQuizesCurso(string pBusqueda, int pCursoID, string pNombreCurso, int? page, string pEstado)
        {
            Session["CursoID"] = pCursoID;
            quizService = new QuizService();
            List<QuizViewModel> listaQuizes = quizService.ListarQuizesCurso(pBusqueda, (int)Session["CursoID"], pEstado);
            ViewBag.CursoID = pCursoID;
            ViewBag.NombreCurso = pNombreCurso;
            Session["NombreCurso"] = pNombreCurso;


            int pageSize = 10;
            int pageNumber = (page ?? 1);

            Usuario current = Session["user"] as Usuario;
            if (current.RolID == 3 || current.RolID == 2)
            {
                return View(listaQuizes.ToPagedList(pageNumber, pageSize));
            }
            else if (current.RolID == 4)
            {
                return View("VerQuizesCursoAlumno", listaQuizes.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View("Error", model: "Usuario sin autorización para entrar");
            }
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
        public ActionResult Editar(int id)
        {
            quizService = new QuizService();
            QuizViewModel Qvm = quizService.VerQuiz(id);
            return View(Qvm);
        }

        [HttpPost]
        public ActionResult Editar(QuizViewModel viewModel)
        {
            try
            {
                quizService = new QuizService();
                if (viewModel.ClaseID == null)
                {
                    QuizViewModel QVMAux = new QuizViewModel();
                    QVMAux = quizService.VerQuiz(viewModel.ID);
                    viewModel.ClaseID = QVMAux.ClaseID;
                }

                quizService.EditarQuiz(viewModel);
                return RedirectToAction("VerQuizesCurso", new { pBusqueda = "", pCursoID = Session["CursoID"], pNombreCurso = Session["NombreCurso"] });

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public ActionResult Baja(int id)
        {
            quizService = new QuizService();
            QuizViewModel Qvm = quizService.VerQuiz(id);
            return View(Qvm);
        }

        // POST: Clase/Delete/5
        [HttpPost]
        public ActionResult Baja(QuizViewModel viewModel)
        {
            try
            {
                quizService = new QuizService();
                quizService.BajaQuiz(viewModel.ID);
                return RedirectToAction("VerQuizesCurso", new { pBusqueda = "", pCursoID = Session["CursoID"], pNombreCurso = Session["NombreCurso"] });
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public ActionResult Rehabilitar(int id)
        {
            quizService = new QuizService();
            var clase = quizService.VerQuiz(id);
            return View(clase);
        }

        [HttpPost]
        public ActionResult Rehabilitar(QuizViewModel viewModel)
        {
            quizService = new QuizService();
            quizService.RehabilitarQuiz(viewModel.ID);
            return RedirectToAction("VerQuizesCurso", new { pBusqueda = "", pCursoID = Session["CursoID"], pNombreCurso = Session["NombreCurso"] });
        }
    }
}
