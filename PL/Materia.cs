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
            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("IdMateria: " + materia.IdMateria);
                    Console.WriteLine("Nombre: " + materia.Nombre);
                    Console.WriteLine("Costo: " + materia.Costo);
                    Console.WriteLine("Creditos: " + materia.Creditos);

                    Console.WriteLine("--------");
                }
                Console.WriteLine(result.Objects);
            }
            else
            {
                Console.WriteLine("Ocurrió un error al traer la información del usuario: " + result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese el Id de la materia");
            materia.IdMateria = int.Parse(Console.ReadLine());

            ML.Result result = BL.Materia.GetById(materia.IdMateria);

            if (result.Correct)
            {
                Console.WriteLine("IdMateria: " + ((ML.Materia)result.Object).IdMateria); //unboxing
                Console.WriteLine("Nombre: " + ((ML.Materia)result.Object).Nombre); //unboxing
                Console.WriteLine("Costo: " + ((ML.Materia)result.Object).Costo); //unboxing
                Console.WriteLine("Creditos: " + ((ML.Materia)result.Object).Creditos); //unboxing
            }
            else
            {

            }
        }
        //PL
        //Usuario
        public static void Add()
        {
            string Nombre;
            bool respuesta;
            
            respuesta = false;
            Nombre = "Jesús";

            ML.Materia materia = new ML.Materia();
            Console.WriteLine("Ingrese el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los créditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre de la calle");

            materia.Direccion = new ML.Direccion();
            materia.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Ingresa el Numero Interior de la calle");
            materia.Direccion.NumeroInterior = int.Parse(Console.ReadLine());


            Console.WriteLine("Ingresa el nombre Numero Exterior calle");
            materia.Direccion.NumeroExterior = int.Parse(Console.ReadLine());


            ML.Result resultDireccion = BL.Direccion.Add(materia.Direccion);

            if (resultDireccion.Correct)
            {
                materia.Direccion.IdDireccion = ((int)resultDireccion.Object);

                ML.Result result = BL.Materia.Add(materia);
                if (result.Correct)
                {
                    Console.WriteLine("La materia ha sido insertada correctamente");
                }
                else
                {
                    Console.WriteLine("Ocurrió un error al insertar la materia " + result.ErrorMessage);
                }
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
