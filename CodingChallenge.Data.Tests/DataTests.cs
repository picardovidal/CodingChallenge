using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                InformeDeFormaGeometrica.Imprimir(new List<FormaGeometrica>()));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                InformeDeFormaGeometrica.Imprimir(new List<FormaGeometrica>(), "en-US"));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new Cuadrado (5)};
            var resumen = InformeDeFormaGeometrica.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado ( 5),
                new Cuadrado ( 1),
                new Cuadrado ( 3)
            };

            var resumen = InformeDeFormaGeometrica.Imprimir(cuadrados, "en-US");

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado( 5),
                new Circulo( 3),
                new TrianguloEquilatero( 4),
                new Cuadrado( 2),
                new TrianguloEquilatero( 9),
                new Circulo( 2.75m),
                new TrianguloEquilatero( 4.2m)
            };

            var resumen = InformeDeFormaGeometrica.Imprimir(formas, "en-US");

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado( 5),
                new Circulo( 3),
                new TrianguloEquilatero( 4),
                new Cuadrado( 2),
                new TrianguloEquilatero( 9),
                new Circulo( 2.75m),
                new TrianguloEquilatero( 4.2m)
            };

            var resumen = InformeDeFormaGeometrica.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var rectangulos = new List<FormaGeometrica> { new Rectangulo(5,6) };
            var resumen = InformeDeFormaGeometrica.Imprimir(rectangulos);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectángulo | Area 30 | Perimetro 22 <br/>TOTAL:<br/>1 formas Perimetro 22 Area 30", resumen);
        }


        [TestCase]
        public void TestResumenListaConDosTrapeciosItalianos()
        {
            var trapecios = new List<FormaGeometrica> {
                new Trapecio(6, 3, 3.3m, 3),
                new Trapecio(5, 2, 2.2m, 2)
            };
            var resumen = InformeDeFormaGeometrica.Imprimir(trapecios,"it-IT");

            Assert.AreEqual("<h1>Rapporto modulo</h1>2 Trapezi | Zona 20,5 | Perimetro 27 <br/>TOTALE:<br/>2 forme Perimetro 27 Zona 20,5", resumen);
        }


        [TestCase]
        public void TestResumenCapturaDeExcepcionItaliano()
        {
            List<FormaGeometrica> trapecios = null;
            var resumen = InformeDeFormaGeometrica.Imprimir(trapecios, "it-IT");

            Assert.AreEqual("Si è verificata un'eccezione durante il tentativo di stampare il rapporto", resumen);
        }

        [TestCase]
        public void TestResumenCapturaDeExcepcionAlSetearIdioma()
        {
            List<FormaGeometrica> trapecios = null;
            var resumen = InformeDeFormaGeometrica.Imprimir(trapecios, "it*IT");

            Assert.AreEqual("Se produjo una excepción al intentar setear el idioma.", resumen);
        }


        [TestCase]
        public void TestCirculoCalcularPerimetro()
        {
            var circulo = new Circulo(10);

            Assert.AreEqual(31.42, Math.Round(circulo.CalcularPerimetro(),2));
        }

        [TestCase]
        public void TestCirculoCalcularArea()
        {
            var circulo = new Circulo(10);

            Assert.AreEqual(78.54, Math.Round(circulo.CalcularArea(), 2));
        }

    }
}
