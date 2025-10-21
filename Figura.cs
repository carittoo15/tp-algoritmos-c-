using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        // Agrego una propiedad Color en la clase base para que cada figura pueda tener su propio color
        public Color Color { get; set; }

        public Figura()
        {
            Color = Color.Black; // valor x defecto
        }

        public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
        }
    }

    public class Rectangulo : Figura
    {
        protected int alto;
        protected int ancho;

        // Constructor
        public Rectangulo(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            Point[] points = new Point[4]
            {
                new Point(x, y),
                new Point(x + ancho, y),
                new Point(x + ancho, y + alto),
                new Point(x, y + alto)
            };
            // DrawPolygon dibuja un polígono dado un conjunto de puntos y un lápiz
            graphics.DrawPolygon(pen, points);
        }
    }

    public class Cuadrado : Rectangulo
    {
        // Constructor. Un cuadrado es un rectnagulo con ancho = alto
        public Cuadrado(int lado) : base(lado, lado)
        {
        }
    }

    public class Circulo : Figura
    {
        private int radio;

        // Constructor
        public Circulo(int radio)
        {
            this.radio = radio;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            graphics.DrawEllipse(pen, x, y, radio, radio);
        }
    }
    // Agrego una clase triangulo isosceles que se dibuja con tres puntos (dos iguales y uno distinto)
    public class TrianguloIsosceles : Figura
    {
        private int baseTriangulo;
        private int altura;

        public TrianguloIsosceles(int baseTriangulo, int altura)
        {
            this.baseTriangulo = baseTriangulo;
            this.altura = altura;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            Point[] puntos = new Point[3]
            {
                new Point(x, y + altura),               // esquina inferior izquierda
                new Point(x + baseTriangulo / 2, y),    // vértice superior
                new Point(x + baseTriangulo, y + altura)// esquina inferior derecha
            };
            graphics.DrawPolygon(pen, puntos);
        }
    }

    // Agrego una clase q se llame triangulo equilatero con lados iguales y uso Math.Sqrt(3)/2*l para calcular la altura
    public class TrianguloEquilatero : Figura
    {
        private int lado;

        public TrianguloEquilatero(int lado)
        {
            this.lado = lado;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            // Calculo la altura del triangulp equilatero
            int altura = (int)(Math.Sqrt(3) / 2 * lado);

            Point[] puntos = new Point[3]
            {
                new Point(x, y + altura),           // esquina inferior izquierda
                new Point(x + lado / 2, y),         // vértice superior
                new Point(x + lado, y + altura)     // esquina inferior derecha
            };
            graphics.DrawPolygon(pen, puntos);
        }
    }

}
