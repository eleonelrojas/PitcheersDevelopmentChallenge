using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), FormaGeometrica.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), FormaGeometrica.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica.Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica.Cuadrado(5),
                new FormaGeometrica.Cuadrado(1),
                new FormaGeometrica.Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica.Cuadrado(5),
                new FormaGeometrica.Circulo(3),
                new FormaGeometrica.TrianguloEquilatero(4),
                new FormaGeometrica.Cuadrado(2),
                new FormaGeometrica.TrianguloEquilatero(9),
                new FormaGeometrica.Circulo(2.75m),
                new FormaGeometrica.TrianguloEquilatero(4.2m),
                new FormaGeometrica.Trapecio(5, 3, 4, 4, 3),
                new FormaGeometrica.Rectangulo(6, 4)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>1 Trapezoid | Area 16.5 | Perimeter 16 <br/>1 Rectangle | Area 24 | Perimeter 20 <br/>TOTAL:<br/>9 shapes Perimeter 133.66 Area 132.15",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica.Cuadrado(5),
                new FormaGeometrica.Circulo(3),
                new FormaGeometrica.TrianguloEquilatero(4),
                new FormaGeometrica.Cuadrado(2),
                new FormaGeometrica.TrianguloEquilatero(9),
                new FormaGeometrica.Circulo(2.75m),
                new FormaGeometrica.TrianguloEquilatero(4.2m),
                new FormaGeometrica.Trapecio(5, 3, 4, 4, 3),
                new FormaGeometrica.Rectangulo(6, 4)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto delle forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13.01 | Perimetro 18.06 <br/>3 Triangoli | Area 49.64 | Perimetro 51.6 <br/>1 Trapezio | Area 16.5 | Perimetro 16 <br/>1 Rettangolo | Area 24 | Perimetro 20 <br/>TOTAL:<br/>9 forme Perimeter 133.66 Area 132.15",
                resumen);
        }
    }
}
