
public class Suministro
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public int Prioridad { get; set; }

    public Suministro(string nombre, int cantidad, int prioridad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Prioridad = prioridad;
    }

    //
    public Suministro(string nombre)
    {
        Nombre = nombre;
        Cantidad = 1;
        Prioridad = 2;
    }


    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre del suministro: {Nombre}");
        Console.WriteLine($"Cantidad del suministro: {Cantidad}");
        if (Prioridad == 1)
        {
            Console.WriteLine("Prioridad del suministro: Alta");
        }
        else if (Prioridad == 2)
        {
            Console.WriteLine("Prioridad del suministro: Media");
        }
        else
        {
            Console.WriteLine("Prioridad del suministro: Baja");
        }
    }

}

public class Inventario
{
    //Atributos
    private Suministro[] suministros;
        
    //Constructor

    public Inventario ()
    {
        suministros = new Suministro[]
        {
            new Suministro("Oxigeno", 15, 1),
            new Suministro("Gasolina"),
            new Suministro("Comida", 30, 1),
            new Suministro("Almohada", 15, 3),
            new Suministro("Botiquin", 4, 1),
            new Suministro("Herramientas")
        };
    }

    public void Mostrar_Suministros()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Inventario de suministros: ");
        foreach(Suministro suministro in suministros)
        {
            suministro.MostrarInfo();
        }

    }
}



