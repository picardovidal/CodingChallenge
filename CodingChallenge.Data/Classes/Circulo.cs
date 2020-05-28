using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {

        private decimal _diametro { get; set; }


        public Circulo(decimal diametro)
        {
            _diametro = diametro;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }

        public string Nombre(int cantidad)
        {
            if (cantidad > 1)
                return Strings.Circulos;
            else
                return Strings.Circulo;
        }
    }
}
