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
}
