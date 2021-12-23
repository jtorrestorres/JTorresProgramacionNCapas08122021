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
        [HttpGet]
        public ActionResult GetAll() //Mostrar una tabla con la información de las materias
        { //El método se debe de llamar igual que la vista

            ML.Result result = BL.Materia.GetAll();

            ML.Materia materia = new ML.Materia();
            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {
                //error
            }//backend

            return View(materia);
        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)  //null //agregar y actualizar
        {
            ML.Materia materia = new ML.Materia();

            ML.Result resultSemestre = BL.Semestre.GetAll();
            if (resultSemestre.Correct)
            {
                materia.Semestre = new ML.Semestre();
                materia.Semestre.Semestres = resultSemestre.Objects;

                if (IdMateria == null)//add
                {
                    return View(materia);
                }
                else  //update
                {
                    //GetById 
                    ML.Result resultMateria = BL.Materia.GetById(IdMateria.Value);

                    if (resultMateria.Correct)
                    {
                        materia.IdMateria = ((ML.Materia)resultMateria.Object).IdMateria;
                        materia.Nombre = ((ML.Materia)resultMateria.Object).Nombre;
                        materia.Creditos = ((ML.Materia)resultMateria.Object).Creditos;
                        materia.Costo = ((ML.Materia)resultMateria.Object).Costo;

                        return View(materia);
                    }

                }
            }
            else
            {
                //error
            }
            

            

            return View(materia);
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)  //null //agregar y actualizar
        {
            if (materia.IdMateria == 0)
            {
                //Add
                BL.Materia.Add(materia);
            }
            else
            {
                //update
                BL.Materia.Update(materia);
            }

            return View();
        }
    }
}