using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        Figura[] figuras;

public Form1()
{
    InitializeComponent();

    Random random = new Random(); // Generador de colores aleatorios

    figuras = new Figura[3]
    {
        // Hago que cada figura tenga un tamaño mayor que la anterior para que se vean crecientes de izquierda a derecha
        new Circulo(40),
        new Rectangulo(60, 80),
        new Cuadrado(100),
    };

    // Uso la clase Random y Color.FromArgb para asignarle un color aleatorio a cada figura
    foreach (var figura in figuras)
    {
        // Restringo los valores RGB para evitar colores muy claros y que las figuras se vean bien sobre fondo blanco
        figura.Color = Color.FromArgb(random.Next(0, 180), random.Next(0, 180), random.Next(0, 180));
    }
}

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();

            for (int i = 0; i < figuras.Length; i++)
            {
                // Uso el color de cada figura para crear el Pen antes de dibujarla
                using (Pen pen = new Pen(figuras[i].Color))
                {
                    figuras[i].Dibujar(pen, gr, i * 100, 50);
                }
            }
        }
    }
}
