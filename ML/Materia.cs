using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; } //2,000,000,000
        public string Nombre { get; set; }
        public byte Creditos { get; set; } //{0..255}
        public decimal Costo { get; set; }    
    }
}
