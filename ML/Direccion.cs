using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public int NumeroInterior { get; set; }
        public int NumeroExterior { get; set; }
        public ML.Colonia Colonia { get; set; }
    }
}
