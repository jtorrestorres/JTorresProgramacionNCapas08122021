using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC2.Controllers
{
    public class SemestreController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Result result = BL.Semestre.GetAll();
            ML.Semestre semestre = new ML.Semestre();
            if (result.Correct)
            {
                semestre.Semestres = new List<object>();
                semestre.Semestres = result.Objects;
            }
            return View(semestre);
        }

        [HttpGet]
        public ActionResult Form()
        {
            ML.Semestre semestre = new ML.Semestre();

            return View(semestre);
        }

        [HttpPost]
        public ActionResult Form(ML.Semestre semestre)
        {

            return View(semestre);
        }
    }
    }