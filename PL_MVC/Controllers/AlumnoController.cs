using System;
using System.Collections.Generic;
using System.IO;
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

            ML.Result resultAlumno = BL.Alumno.GetAll();

            alumno.Alumnos = resultAlumno.Objects;

            return View(alumno);
        }
        f
        public JsonResult GetGrupoByIdPlantel(int IdPlantel)
        {
            ML.Result result = BL.Grupo.GetByIdPlantel(IdPlantel);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        [HttpGet] //Mostrar el formulario
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            
            if(IdAlumno != null) //Update
            {
                ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno.Value);
                //GetById

                if (resultAlumno.Correct)
                {
                    //boxing //unboxing
                    alumno = new ML.Alumno();
                    // 1)
                    alumno = (ML.Alumno)resultAlumno.Object;//unboxing

                    // 2)
                    alumno.IdAlumno = ((ML.Alumno)resultAlumno.Object).IdAlumno;
                    alumno.Nombre = ((ML.Alumno)resultAlumno.Object).Nombre;
                    alumno.ApellidoPaterno = ((ML.Alumno)resultAlumno.Object).ApellidoPaterno;
                    alumno.ApellidoMaterno = ((ML.Alumno)resultAlumno.Object).ApellidoMaterno;
                    alumno.Imagen = ((ML.Alumno)resultAlumno.Object).Imagen;

                }

            }

            //update
            return View(alumno);
        }

        //fronEnd ->HTML ,CSS JS
        //backEnd -> C#

        public static byte[] ConvertToByteArray(HttpPostedFileBase fileImagen)
        {
            MemoryStream target = new MemoryStream();
            fileImagen.InputStream.CopyTo(target);
            return target.ToArray();
        }


        [HttpPost] //Mostrar el formulario
        public ActionResult Form(ML.Alumno alumno)
        {
            HttpPostedFileBase file = Request.Files["fuImagenName"];
            
            if(file.ContentLength>0)
            {
                alumno.Imagen = ConvertToByteArray(file);
            }
            
            //string base64    -varchar
            //Arreglo de Bytes -varbinary  //videos
            //BL.Alumno.Add
            if(alumno.IdAlumno==0)
            {
                BL.Alumno.AddEF(alumno);
            }
            else
            {
               // BL.Alumno.AddEF(alumno); //update
            }


            return View(alumno);
        }
    }
}