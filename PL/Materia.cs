using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        public static void GetAll()
        {

        }

        public static void GetById()
        {

        }
        //PL
        //Usuario
        public static void Add()
        {
            ML.Materia materia = new ML.Materia(); 

            Console.WriteLine("Ingrese el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los créditos de la materia");
            materia.Creditos =  byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());


            ML.Result result=BL.Materia.Add(materia);
            if (result.Correct)
            {
                Console.WriteLine("La materia ha sido insertada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar la materia " + result.ErrorMessage);
            }
        }

        public static void Update()
        {

        }

        public static void Delete()
        {

        }
    }
}
