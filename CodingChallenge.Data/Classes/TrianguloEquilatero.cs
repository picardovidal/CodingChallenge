using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {

        private decimal _lado { get; set; }


        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea()
        {
            return  ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return  _lado * 3;
        }

        public string Nombre(int cantidad)
        {
            if (cantidad > 1)
                return Strings.Triangulos;
            else
                return Strings.Triangulo;
        }
    }
}
