using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {

        private decimal _base { get; set; }
        private decimal _altura { get; set; }


        public Rectangulo(decimal baser, decimal altura)
        {
            _base = baser;
            _altura = altura;
        }

        public decimal CalcularArea()
        {
            return _base * _altura;
        }

        public decimal CalcularPerimetro()
        {
            return _base * 2 + _altura * 2;
        }

        public string Nombre(int cantidad)
        {
            if (cantidad > 1)
                return Strings.Rectangulos;
            else
                return Strings.Rectangulo;
        }
    }
}
