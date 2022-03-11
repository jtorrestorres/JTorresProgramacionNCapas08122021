using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Grupo = new ML.Grupo();
            alumno.Grupo.Plantel = new ML.Plantel();

            ML.Result result = BL.Plantel.GetAll();

            alumno.Grupo.Plantel.Planteles = result.Objects;//GetAll Planteles


            return View(alumno);
        }

        public JsonResult GetGrupoByIdPlantel(int IdPlantel)
        {
            ML.Result result = BL.Grupo.GetByIdPlantel(IdPlantel);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
    }
}