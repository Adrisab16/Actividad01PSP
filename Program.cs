using DocumentFormat.OpenXml.Spreadsheet;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Añadimos el cliente EditorGrafico, que establecerá un alto y un acho de 800x600
public class EditorGrafico
{
    public static int Ancho = 800;
    public static int Alto = 600;
}

// Implementamos una interfaz llamada IGrafico, el cual se encargará de las acciones que ofrecerá el EditorGráfico, Mover y Dibujar
public interface IGrafico
{
    public bool Move(int x, int y);
    public string Draw();
}

// Agregamos la clase punto, que se encargará de comprobar que el dibujo no se salga de la pantalla y de dibujar un punto cuandos se pida
public class Punto : IGrafico
{
    public Punto(int x, int y)
    {
        if (y > EditorGrafico.Alto || x > EditorGrafico.Ancho || x < 0 || y < 0)
        {
            throw new IndexOutOfRangeException(); // Si se sale de la pantalla, lanzaremos una excepción informando de ello
        }
        else // Si está dentro de la pantalla, simplemente añadiremos los valores a las variables, para trabajar más tarde con ellas
        {
            this.x = x;
            this.y = y;
        }
    }

    public int x { get; set; } 
    public int y { get; set; }

    public virtual string Draw() // Modificamos la acción de la interfaz "IGrafico", para adaptarlo a las necesidades de la clase punto
    {
        return $"Se ha dibujado un punto en las coordenadas: x:{x} y:{y}";
    }

    public virtual bool Move(int x, int y) // Modificamos la acción de la interfaz "IGrafico", para adaptarlo a las necesidades de la clase punto
    {
        this.x = this.x + x;
        this.y = this.y + y;
        if (this.x > EditorGrafico.Ancho || this.y > EditorGrafico.Alto || this.x < 0 || this.y < 0) // Para mover, tendremos que volver a comprobar que el espacio al que queramos moverlo siga dentro de la pantalla
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

// Implementamos la clase GraficoCompuesto, donde tendremos varios gráficos en lista
public class GraficoCompuesto : IGrafico
{
    List<IGrafico> GraficoList = new List<IGrafico>();

    public bool Move(int x, int y)
    {
        var isTrue = true;
        foreach (var item in GraficoList)
        {
            if (item.Move(x, y) == true)
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
                break;
            }
        }
        return isTrue;
    }

    public string Draw()
    {
        var graphic = "Se ha dibujado un gráfico compuesto";
        foreach (var item in GraficoList)
        {
            graphic += item.Draw() + " / ";
        }
        return graphic;
    }

    public void GraficoAdd(IGrafico grafico)
    {
        GraficoList.Add(grafico);
    }
}

//Derivado de la clase Punto, tenemos la clase circulo, con el que podremos dibujar un circulo:
public class Circulo : Punto
{
    public Circulo(int x, int y, int radio) : base(x, y) // Para dibujar un circulo, es necesario saber su radio, así que declaramos la variable radio
    {
        if (x + radio > EditorGrafico.Ancho || y + radio > EditorGrafico.Alto || y - radio < 0 || x - radio < 0)
        {
            throw new IndexOutOfRangeException(); // Lanzamos excepcion si se sale de la pantalla
        }
        else
        {
            this.radio = radio;
        }
    }

    public int radio { get; set; }

    public override string Draw()
    {
        return $"Se ha dibujado un circulo en las coordenadas: x:{x} y:{y} con radio = {radio}";
    }

    public override bool Move(int x, int y)
    {
        base.x = base.x + x + radio;
        base.y = base.y + y + radio;
        if (base.x > EditorGrafico.Ancho || base.y > EditorGrafico.Alto || base.y < 0 || base.x < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

// 
public class Rectangulo : Punto
{
    public Rectangulo(int x, int y, int Base, int Altura) : base(x, y) // Para un rectangulo, es necesario su base y su altura, además de su posición absoluta
    {
        if (x + Base > EditorGrafico.Ancho || y + Altura > EditorGrafico.Alto || x - Base < 0 || y - Altura < 0)
        {
            throw new IndexOutOfRangeException(); // Lanzamos excepcion si se sale de la pantalla
        }
        else
        {
            this.baseRectangulo = Base;
            this.alturaRectangulo = Altura;
        }
    }

    public int baseRectangulo {get; set;}
    public int alturaRectangulo {get; set;}

    public override string Draw()
    {
        return $"Se ha dibujado un rectangulo en las coordenadas: x:{x} y:{y} de base = {baseRectangulo} y altura = {alturaRectangulo}";
    }

    public override bool Move(int x, int y)
    {
        base.x = base.x + x + baseRectangulo;
        base.y = base.y + y + alturaRectangulo;
        if (base.x > EditorGrafico.Ancho || base.y > EditorGrafico.Alto || base.x < 0 || base.y < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}




// El programa principal, que hace funcionar las clases que hemos puesto hasta ahora, implementamos el main y dibujamos algunas figuras de ejemplo para comprobar el correcto funcionamiento del programa
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Punto puntonum1 = new Punto(400, 300);
            Console.WriteLine(puntonum1.Draw());
            Console.WriteLine(puntonum1.Move(-300, 50));

            Circulo circulonum1 = new Circulo(2, 2, 2);
            Console.WriteLine(circulonum1.Draw());
            Console.WriteLine(circulonum1.Move(70, 200));

            Rectangulo rectangulonum1 = new Rectangulo(50, 50, 26, 70);
            Console.WriteLine(rectangulonum1.Draw());
            Console.WriteLine(rectangulonum1.Move(20, 7));

            Punto puntonum2 = new Punto(120, 100);
            Console.WriteLine(puntonum2.Draw());
            Console.WriteLine(puntonum2.Move(100, 100));

            Punto PuntoGraficoComp = new Punto(10, 30);
            Rectangulo RectanguloGraficoComp = new Rectangulo(3, 400, 69, 96);
            GraficoCompuesto GraficoCompuesto1 = new GraficoCompuesto();
            GraficoCompuesto1.GraficoAdd(RectanguloGraficoComp);
            GraficoCompuesto1.GraficoAdd(PuntoGraficoComp);
            Console.WriteLine(GraficoCompuesto1.Draw());
            Console.WriteLine(GraficoCompuesto1.Move(1, 1));
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("ERROR: Coordenadas invalidas");
        }
    }
}
