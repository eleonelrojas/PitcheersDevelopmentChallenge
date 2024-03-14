using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string ObtenerNombre(int cantidad, int idioma);

        public class Cuadrado : FormaGeometrica
        {
            private readonly decimal _lado;

            public Cuadrado(decimal lado)
            {
                _lado = lado;
            }

            public override decimal CalcularArea()
            {
                return _lado * _lado;
            }

            public override decimal CalcularPerimetro()
            {
                return _lado * 4;
            }

            public override string ObtenerNombre(int cantidad, int idioma)
            {
                if (idioma == FormaGeometrica.Castellano)
                    return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                else if (idioma == FormaGeometrica.Ingles)
                    return cantidad == 1 ? "Square" : "Squares";
                else
                    return cantidad == 1 ? "Quadrato" : "Quadrati";
            }
        }

        public class Circulo : FormaGeometrica
        {
            private readonly decimal _radio;

            public Circulo(decimal radio)
            {
                _radio = radio;
            }

            public override decimal CalcularArea()
            {
                return (decimal)Math.PI * (_radio * _radio);
            }

            public override decimal CalcularPerimetro()
            {
                return (decimal)Math.PI * (_radio * 2);
            }

            public override string ObtenerNombre(int cantidad, int idioma)
            {
                if (idioma == FormaGeometrica.Castellano)
                    return cantidad == 1 ? "Círculo" : "Círculos";
                else if (idioma == FormaGeometrica.Ingles)
                    return cantidad == 1 ? "Circle" : "Circles";
                else
                    return cantidad == 1 ? "Cerchio" : "Cerchi";
            }
        }

        public class TrianguloEquilatero : FormaGeometrica
        {
            private readonly decimal _lado;

            public TrianguloEquilatero(decimal lado)
            {
                _lado = lado;
            }

            public override decimal CalcularArea()
            {
                return ((_lado * _lado) * (decimal)Math.Sqrt(3)) / 4;
            }

            public override decimal CalcularPerimetro()
            {
                return _lado * 3;
            }

            public override string ObtenerNombre(int cantidad, int idioma)
            {
                if (idioma == FormaGeometrica.Castellano)
                    return cantidad == 1 ? "Triángulo" : "Triángulos";
                else if (idioma == FormaGeometrica.Ingles)
                    return cantidad == 1 ? "Triangle" : "Triangles";
                else
                    return cantidad == 1 ? "Triangolo" : "Triangoli";
            }
        }

        public class Trapecio : FormaGeometrica
        {
            private readonly decimal _baseMayor;
            private readonly decimal _baseMenor;
            private readonly decimal _lado1;
            private readonly decimal _lado2;
            private readonly decimal _altura;

            public Trapecio(decimal baseMayor, decimal baseMenor, decimal lado1, decimal lado2, decimal altura)
            {
                _baseMayor = baseMayor;
                _baseMenor = baseMenor;
                _lado1 = lado1;
                _lado2 = lado2;
                _altura = altura;
            }

            public override decimal CalcularArea()
            {
                return ((_baseMayor + _baseMenor) * _altura) / 2;
            }

            public override decimal CalcularPerimetro()
            {
                return _baseMayor + _baseMenor + _lado1 + _lado2;
            }

            public override string ObtenerNombre(int cantidad, int idioma)
            {
                if (idioma == FormaGeometrica.Castellano)
                    return cantidad == 1 ? "Trapecio" : "Trapecios";
                else if (idioma == FormaGeometrica.Ingles)
                    return cantidad == 1 ? "Trapezoid" : "Trapezoids";
                else
                    return cantidad == 1 ? "Trapezio" : "Trapezi";
            }
        }

        public class Rectangulo : FormaGeometrica
        {
            private readonly decimal _base;
            private readonly decimal _altura;

            public Rectangulo(decimal baseRectangulo, decimal alturaRectangulo)
            {
                _base = baseRectangulo;
                _altura = alturaRectangulo;
            }

            public override decimal CalcularArea()
            {
                return _base * _altura;
            }

            public override decimal CalcularPerimetro()
            {
                return 2 * (_base + _altura);
            }

            public override string ObtenerNombre(int cantidad, int idioma)
            {
                if (idioma == FormaGeometrica.Castellano)
                    return cantidad == 1 ? "Rectángulo" : "Rectángulos";
                else if (idioma == FormaGeometrica.Ingles)
                    return cantidad == 1 ? "Rectangle" : "Rectangles";
                else
                    return cantidad == 1 ? "Rettangolo" : "Rettangoli";
            }
        }

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        #endregion

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else if (idioma == Ingles)
                    sb.Append("<h1>Empty list of shapes!</h1>");
                else if (idioma == Italiano)
                    sb.Append("<h1>Elenco vuoto di forme!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else if (idioma == Ingles)
                    sb.Append("<h1>Shapes report</h1>");
                else if (idioma == Italiano)
                    sb.Append("<h1>Rapporto delle forme</h1>");

                decimal totalArea = 0m;
                decimal totalPerimetro = 0m;

                foreach (var forma in formas)
                {
                    totalArea += forma.CalcularArea();
                    totalPerimetro += forma.CalcularPerimetro();
                    sb.Append($"{forma.ObtenerNombre(1, idioma)} | Area {forma.CalcularArea():#.##} | Perimetro {forma.CalcularPerimetro():#.##} <br/>");
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append($"{formas.Count} {(idioma == Castellano ? "formas" : (idioma == Ingles ? "shapes" : "forme"))} ");
                sb.Append($"Perimetro {totalPerimetro.ToString("#.##")} ");
                sb.Append($"Area {totalArea.ToString("#.##")}");
            }

            return sb.ToString();
        }

    }
}
