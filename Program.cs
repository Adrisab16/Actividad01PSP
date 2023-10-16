using System.Runtime.InteropServices;

internal class EditorGrafico: IGrafico
{
    string IGrafico.dibujar(int x, int y)
    {
        if (x > 800 || y > 600){
            throw new Exception("Te has salido de la pantalla (800x600)");
        }

        Console.Write(x.ToString(),y);

        throw new NotImplementedException();
    }

    public bool mover(int x, int y)
    {
        if (x > 800 || y > 600)
        {
            return false;
        }
        throw new NotImplementedException();
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
