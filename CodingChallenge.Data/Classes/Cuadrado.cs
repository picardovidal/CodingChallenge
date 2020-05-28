using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
       
        private decimal _lado { get; set;}
        

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public string Nombre(int cantidad)
        {
            if (cantidad > 1)
                return Strings.Cuadrados;
            else
                return Strings.Cuadrado;
        }
    }
}
