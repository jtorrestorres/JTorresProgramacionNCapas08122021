using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ML
{
    public class Materia//Usuarios
    {
        //dato primitivo  //objeto complejo
        public int IdMateria { get; set; } //2,000,000,000
        public string  Clave { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        [EmailAddress] //Regular expressions
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        [Range(1, 255, ErrorMessage = "El valor debe estar entre 1 y 255")]
        public byte Creditos { get; set; } //{0..255}        
        public decimal Costo { get; set; } 
        public ML.Direccion Direccion { get; set; }
        public List<object> Materias { get; set; }
        public ML.Semestre Semestre { get; set; }
        public string Action { get; set; }
    }
}


//Add, update, delete, GetAll, GetById -> SP | 