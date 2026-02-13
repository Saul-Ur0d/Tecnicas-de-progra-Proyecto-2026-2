using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hola Mundo");
public class Rectangulo
{
    public int Base { get; set; }
    public int Altura { get; set; }

    public Rectangulo(int bse, int alt)
    {
        Base = bse;
        Altura = alt;

    }
    public void Calcular_Perimetro()
    {
         int Perimetro = Base * 2 + Altura * 2;
        Console.WriteLine($"El rectangulo tiene un perimetro de: {Perimetro}");
    }
    public void Calcular_Area()
    {
     int Area = Base * Altura;
    Console.WriteLine($"El rectangulo tiene un area de: {Area}");

    }
}