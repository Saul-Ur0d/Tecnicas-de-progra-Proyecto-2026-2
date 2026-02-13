public class Persona
{
    //Atributos
    public string Nombre { get; set; } //Encapsulamiento
    public int Edad {  get; set; }

    //Atributo static

    public static string Pais { get; set; } = "España";


    //Constructor
    public Persona(string nombre, int edad, string pais)
    {
        Nombre = nombre;
        Edad = edad;
        Pais = pais;
    }
    //Metodos

    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre objeto: {Nombre}");
        Console.WriteLine($"Edad objeto: {Edad}");
        
    }

    public static void MostrarPais()
    {
        Console.WriteLine($"Pais objeto: {Pais}");
    }
}
