using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required] //decoradores
        public string Nombre { get; set; }

        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public ML.Direccion Direccion { get; set; }

    }

    struct Operaciones
    {
        public int x;

        public double Sumar(int a, int b)
        {
            return a + b;
        }
    };
}
