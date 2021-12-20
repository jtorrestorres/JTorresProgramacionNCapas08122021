using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll() //Mostrar una tabla con la información de las materias
        { //El método se debe de llamar igual que la vista

            ML.Result result = BL.Materia.GetAll();

            ML.Materia materia = new ML.Materia();
            if(result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {
                //error
            }
            
            return View(materia);
        }
    }
}