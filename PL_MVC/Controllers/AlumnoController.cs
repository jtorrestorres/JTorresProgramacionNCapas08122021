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

        public JsonResult GetGrupoByIdPlantel(int IdPlantel)
        {
            ML.Result result = BL.Grupo.GetByIdPlantel(IdPlantel);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        [HttpGet] //Mostrar el formulario
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            //add
            if(IdAlumno == null)
            {
                View(alumno);
            }
            else
            {

                //GetById

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
            
            alumno.Imagen= ConvertToByteArray(file);
            //string base64    -varchar
            //Arreglo de Bytes -varbinary  //videos
            //BL.Alumno.Add
            BL.Alumno.AddEF(alumno);

            return View(alumno);
        }
    }
}