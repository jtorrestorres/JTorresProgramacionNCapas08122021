using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {


        //public static ML.Result ReadFile(HttpPostedFileBase file)
        //{

        //    StreamReader Textfile = new StreamReader(file.InputStream);
        //    string line;
        //    bool isFirstLine = true;

        //    ML.Result resultErrores = new ML.Result();
        //    resultErrores.Objects = new List<object>();

        //    while ((line = Textfile.ReadLine()) != null)
        //    {
        //        if (isFirstLine)
        //        {
        //            isFirstLine = false;
        //            line = Textfile.ReadLine();
        //        }

        //        //log errores

        //        Console.WriteLine(line);
        //        string[] datos = line.Split('|');

        //        ML.Materia materia = new ML.Materia();
        //        materia.Nombre = datos[0];
        //        materia.Creditos = byte.Parse(datos[1]);
        //        materia.Costo = decimal.Parse(datos[2]);
        //        materia.Semestre = new ML.Semestre();
        //        materia.Semestre.IdSemestre = int.Parse(datos[3]);

        //        ML.Result result = BL.Materia.Add(materia);

        //        if (!result.Correct) //si el usuario se insertó correctamente
        //        {
        //            resultErrores.Objects.Add(
        //                "No se insertó la materia con nombre:" + materia.Nombre + "Creditos:" + materia.Creditos +
        //                "Error: " + result.ErrorMessage
        //            );
        //        }
        //    }





        //    return resultErrores;




        //}

        // GET: Materia
        [HttpGet] // Mostrar views
        public ActionResult GetAll() //Mostrar una tabla con la información de las materias
        { //El método se debe de llamar igual que la vista

            ML.Materia materia = new ML.Materia();


            ML.Result resultMaterias = BL.Materia.GetAll(new ML.Materia());
            ML.Result resultSemestres = BL.Semestre.GetAll();

            if (resultMaterias.Correct)
            {
                materia.Materias = new List<object>();
                materia.Materias = resultMaterias.Objects;
                if (resultSemestres.Correct)
                {
                    materia.Semestre = new ML.Semestre();
                    materia.Semestre.Semestres = new List<object>();
                    materia.Semestre.Semestres = resultSemestres.Objects;

                    return View(materia);
                }
                else
                {
                    ViewBag.Message = resultSemestres.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Message = resultMaterias.ErrorMessage;
                return PartialView("Modal");
            }


        }


        [HttpPost]
        public ActionResult GetAll(ML.Materia materia) //Mostrar una tabla con la información de las materias
        {

            ML.Result resultMaterias = BL.Materia.GetAll(materia);
            ML.Result resultSemestres = BL.Semestre.GetAll();

            if (resultMaterias.Correct)
            {
                materia.Materias = new List<object>();
                materia.Materias = resultMaterias.Objects;
                if (resultSemestres.Correct)
                {
                    materia.Semestre = new ML.Semestre();
                    materia.Semestre.Semestres = new List<object>();
                    materia.Semestre.Semestres = resultSemestres.Objects;

                    return View(materia);
                }
                else
                {
                    ViewBag.Message = resultSemestres.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Message = resultMaterias.ErrorMessage;
                return PartialView("Modal");
            }


            //HttpPostedFileBase file = Request.Files["archivoTXT"];

            ////result= ReadFile(file);


            //if (!result.Correct) //Errores 
            //{
            //    pathArchivo = Server.MapPath("/ErroresCargaMasiva/ListaErroresCargaMasiva.txt");
            //    TextWriter tw = new StreamWriter(pathArchivo);

            //    foreach (string error in result.Objects)
            //    {
            //        tw.WriteLine(error);
            //    }

            //    tw.Close();
            //}


            //Session["RutaDeDescarga"] = pathArchivo;
            //return View(materia);
        }


        //public ContentResult DescargarArchivo()
        //{
        //    //StreamReader Textfile = new StreamReader(Session["RutaDeDescarga"].ToString());

        //    //string content = new StreamReader(Textfile, Encoding.Unicode).ReadToEnd();
        //    return Content(Session["RutaDeDescarga"].ToString(), "text/plain");
        //}

        public FileResult DescargarArchivo()
        {
            return File(Session["RutaDeDescarga"].ToString(), MediaTypeNames.Application.Octet, "document.txt");
        }


        public FileResult Descargar(int IdMateria)
        {

            ML.Result result = BL.Materia.GetById(IdMateria);

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(result.Object.GetType());

            x.Serialize(Console.Out, result.Object);

            return File(Session["RutaDeDescarga"].ToString(), MediaTypeNames.Application.Octet, "document.txt");


        }


        [HttpGet]
        public ActionResult Form(string Clave)  //null //agregar y actualizar
        {
            ML.Materia materia = new ML.Materia();

            ML.Result resultSemestre = BL.Semestre.GetAll();
            if (resultSemestre.Correct)
            {
                materia.Semestre = new ML.Semestre();
                materia.Semestre.Semestres = resultSemestre.Objects;

                if (Clave == null)//add
                {
                    materia.Action = "Add";
                    return View(materia);
                }
                else  //update
                {
                    //GetById 
                    ML.Result resultMateria = BL.Materia.GetById(1);

                    if (resultMateria.Correct)
                    {
                        materia.IdMateria = ((ML.Materia)resultMateria.Object).IdMateria;
                        materia.Nombre = ((ML.Materia)resultMateria.Object).Nombre;
                        materia.Creditos = ((ML.Materia)resultMateria.Object).Creditos;
                        materia.Costo = ((ML.Materia)resultMateria.Object).Costo;
                        materia.Action = "Update";
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
            if (ModelState.IsValid)
            {
                if (materia.Action == "Add")
                {
                    //Add
                    BL.Materia.Add(materia);
                }
                else
               if (materia.Action == "Update")
                {//update
                    BL.Materia.Update(materia);
                }
                else
                {
                    ViewBag.Message = "Acción del formulario no reconocida";
                    return PartialView("PartialPV");
                }
            }


            ML.Result resultSemestre = BL.Semestre.GetAll();

            materia.Semestre = new ML.Semestre();
            materia.Semestre.Semestres = resultSemestre.Objects;

            return View(materia);
        }
    }
}