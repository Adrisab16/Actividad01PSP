using DocumentFormat.OpenXml.Spreadsheet;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {

    }
}

internal class EditorGrafico: IGrafico
{
    string IGrafico.dibujar(int x, int y)
    {
        try
        { 
            Console.WriteLine("Introduzca el valor de x: ");
            x = int.Parse(Console.ReadLine()); // Primera coordenada a introducir
            Console.WriteLine("Introduzca el valor de y: ");
            y = int.Parse(Console.ReadLine()); // Segunda coordenada a introducir
            if (x > 800 || y > 600) // Cuando se salga de las coordenadas 800,600 provoco una excepcion
            {
                throw new Exception("Te has salido de la pantalla (800x600)");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("El formato del número no es válido.");
        }
        return "Gráfico dibujado con éxito, coordenadas: " + x.ToString() + y; // Mostramos las coordenadas correctas
    }

    public bool mover(int x, int y)
    {
        try
        {
            Console.WriteLine("Introduzca el nuevo valor de x: ");
            x = int.Parse(Console.ReadLine()); // Primera coordenada a introducir
            Console.WriteLine("Introduzca el nuevo valor de y: ");
            y = int.Parse(Console.ReadLine()); // Segunda coordenada a introducir
            if (x > 800 || y > 600) { return false; }
            else 
            {
                Console.WriteLine("Grafico movido con éxito, coordenadas: " + x.ToString() + y);
                return true; 
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("El formato del número no es válido.");
        }
        return false;
    }
}

interface IGrafico
{
    public bool mover(int x, int y);
    public string dibujar(int x, int y);
} 

internal class Punto{
   private readonly int x;
   private readonly int y;
   public Punto(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}


internal class GraficoCompuesto
{

}

internal class Circulo
{
    private readonly int radio;
    public Circulo(int x, int y, int radio)
    {
        this.radio = radio;
    }
}

internal class Rectangulo
{
    private int ancho;
    private int alto;
    public Rectangulo(int x, int y, int ancho, int alto)
    {
        this.ancho = ancho;
        this.alto = alto;
    }
}