using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapas08122021Entities context = new DL_EF.JTorresProgramacionNCapas08122021Entities())
                {
                    var resultQuery = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Imagen);
                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el alumno";
                    }
                }
            }
            //catch (DivideByZeroException ex)
            //{
            //    result.ErrorMessage = "No se puede dividir entre 0";
            //}
            //catch (NullReferenceException ex)
            //{
            //    result.ErrorMessage = "Existe un parámetro en null";
            //}
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JTorresProgramacionNCapas08122021Entities context = new DL_EF.JTorresProgramacionNCapas08122021Entities())
                {
                    var resultQuery = context.AlumnoGetAll().ToList();
                    if (resultQuery.Count>0)
                    {
                        result.Objects = new List<object>();
                        foreach (var objAlumno in resultQuery) //
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = objAlumno.IdAlumno;
                            alumno.Nombre = objAlumno.Nombre;
                            alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                            alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;
                            alumno.Imagen = objAlumno.Imagen;

                            result.Objects.Add(alumno);

                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el alumno";
                    }
                }
            }           
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
