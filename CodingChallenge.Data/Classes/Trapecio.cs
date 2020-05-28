using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {

        private decimal _base { get; set; }
        private decimal _altura { get; set; }
        private decimal _lado { get; set; }
        private decimal _Base { get; set; }


        public Trapecio(decimal baser, decimal altura, decimal lado, decimal Base)
        {
            _base = baser;
            _altura = altura;
            _lado = lado;
            _Base = Base;
        }

        public decimal CalcularArea()
        {
            return (_base + _Base ) * _altura / 2;
        }

        public decimal CalcularPerimetro()
        {
            return _base + _Base + 2 * _lado;
        }

        public string Nombre(int cantidad)
        {
            if (cantidad > 1)
                return Strings.Trapecios;
            else
                return Strings.Trapecio;
        }
    }
}
