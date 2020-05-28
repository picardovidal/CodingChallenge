using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class InformeDeFormaGeometrica
    {
        public static string Imprimir(List<FormaGeometrica> formas, String idioma = "es-ES")
        {
            try
            {

                //El idioma también prodría haber sido implementado con un strategy creando una interface idioma y e implementandola por cada idioma que necesitemos.
                //decidí no hacerlo así, porque esas clases solo definirían mensajes y no comportamiento.
                //y porque a través de las clases de recursos podemos lograr el mismo resultado.


                try
                {
                    //seteo el idioma con el que voy a imprimir el reporte, el idioma por defecto es español
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma); //"en-US"
                }
                catch (Exception e)
                {
                    return "Se produjo una excepción al intentar setear el idioma.";
                }

                var sb = new StringBuilder();

                if (!formas.Any())
                    sb.Append(Strings.ListaVacia);
                else
                {
                    // Hay por lo menos una forma
                    // HEADER
                    sb.Append(Strings.Header);

                    //vamos a trabajar agrupando por tipo para poder generalizar el código
                    Dictionary<Type, List<FormaGeometrica>> formasAgrupadas = formas.GroupBy(u => u.GetType())
                                          .ToDictionary(grp => grp.Key, grp => grp.ToList());

               
                    var numeroTotal = formas.Count();
                    var areaTotal = 0m;
                    var perimetroTotal = 0m;

                    foreach (KeyValuePair<Type, List < FormaGeometrica>> grupo in formasAgrupadas)
                    {
                        var numero = 0;
                        var area = 0m;
                        var perimetro = 0m;
                        foreach (FormaGeometrica form in grupo.Value)
                        {
                            numero++;
                            area += form.CalcularArea();
                            perimetro += form.CalcularPerimetro();
                            areaTotal += form.CalcularArea();
                            perimetroTotal += form.CalcularPerimetro();
                        }
                        var nombre = grupo.Value.First().Nombre(numero);

                        sb.Append(ObtenerLinea(numero, area, perimetro, nombre));
                    }

                    // FOOTER
                    sb.Append(Strings.Total);
                    sb.Append(string.Format("{0} {1} ", numeroTotal, Strings.Formas));
                    sb.Append(string.Format("{0} {1} ", Strings.Perimetro, perimetroTotal.ToString("#.##")));
                    sb.Append(string.Format("{0} {1}",Strings.Area , areaTotal.ToString("#.##")));
                }

                return sb.ToString();
            }
            catch(Exception e)
            {
                return Strings.SeProdujoExcepcion;
            }
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string nombre)
        {
            if (cantidad > 0)
                return $"{cantidad} {nombre} | {Strings.Area} {area:#.##} | {Strings.Perimetro} {perimetro:#.##} <br/>";

            return string.Empty;
        }

    }
}
