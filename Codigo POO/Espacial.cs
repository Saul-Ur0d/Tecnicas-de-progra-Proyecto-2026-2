
try
{
    Inventario inventario = new Inventario();
    bool Funcionando = true;
    Console.WriteLine("Bienvenido");
    inventario.Mostrar_Suministros();
    while (Funcionando)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("¿Que desea realizar");
        Console.WriteLine("1- Agregar un suministro");
        Console.WriteLine("2- Buscar un suministro");
        Console.WriteLine("3- Eliminar un suministro");
        Console.WriteLine("4- Ordenar los suministros");
        Console.WriteLine("5- Revertir el orden");
        Console.WriteLine("6- Vaciar el inventario");
        Console.WriteLine("7- Mostrar inventario"); //El try-catch del inventario vacio lo puse hasta el metodo Mostrar_Suiministros()
        Console.WriteLine("8- Terminar el programa");


        int Decision = int.Parse(Console.ReadLine() ?? "");

        switch (Decision)
        {
            case 1:
                try
                {
                    Console.WriteLine("Que deseas agregar?");
                    string nuevo = Console.ReadLine() ?? "";

                    /* 
                    Recorde que en la pagina de learn c# in y minutes
                    habia visto un comando booleano para ver si se lograba convertir a entero, investigue
                    un poco mas y decidi incluir el tryparse al codigo, se ve un poco sobrecargado de ifs
                    pero funciona :D
                    */

                    Console.WriteLine("Cuantos deseas agregar?");
                    string Can = Console.ReadLine() ?? "";
                    int cant;
                    if (int.TryParse(Can, out cant))
                    {
                        Console.WriteLine("Que prioridad tiene? ");
                        string pri = Console.ReadLine() ?? "";
                        int prio;
                        if (int.TryParse(pri, out prio))
                        {
                            if (nuevo != "")
                            /* 
                            Este ultimo if deberia ser el que contenga todos los demas
                            pero es el que ya tenia hecho antes de meter los if de throw,
                            y sigue funcionando bien, entonces no lo movi
                            */
                            {
                                if (cant > 0 || (prio >= 0 && prio <= 3))
                                {
                                    inventario.AgregarSuministro(nuevo, cant, prio);
                                }
                                else
                                {
                                    inventario.AgregarSuministro(nuevo);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Elemento invalido, no se agrego nada");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            throw new Exception("Prioridad invalida, no se agrego el elemento");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        throw new Exception("Cantidad invalida, no se agrego el elemento");
                    }
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message); 
                }
                    break;
            case 2:
                Console.WriteLine("Ingresa el nombre del suministro a buscar: ");
                string busqueda = Console.ReadLine() ?? "";
                inventario.BuscarSuministro(busqueda);
                break;
            case 3:
                Console.WriteLine("Que deseas eliminar?");
                string seVa = Console.ReadLine() ?? "";
                inventario.EliminarSuministro(seVa);
                break;
            case 4:
                inventario.OrdenarPorNombre();
                break;
            case 5:
                inventario.InvertirOrden();
                break;
            case 6:
                inventario.VaciarInventario();
                break;
            case 7:
                inventario.Mostrar_Suministros();
                break;
            case 8:
                Funcionando = false;
                break;
            default:
                Console.WriteLine("Ingrese un numero de los indicados en las opciones");
                break;
        }

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


finally
{
    Console.WriteLine("Finalizando el programa");
}

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
        try 
        {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Inventario de suministros: ");
                    if (suministros[0] != null)
                    {
                        foreach (Suministro suministro in suministros)
                        {
                            suministro.MostrarInfo();
                        }
                    }
                    else
                    {
                Console.ForegroundColor = ConsoleColor.White;
                throw new Exception("El inventario esta vacio");
                    }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void BuscarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() ==nombre.ToLower());
        if(indice >= 0)
        {
            Console.WriteLine($"{nombre} se encontro en la posicion {indice}");
        }
        else
        {
            Console.WriteLine("No se encontro en el inventario");
        }

    }

    public void OrdenarPorNombre()
    {
        Array.Sort(suministros,(x,y) => x.Nombre.CompareTo(y.Nombre));
        Console.WriteLine("Suministros ordenados por nombre");
    }

    public void InvertirOrden()
    {
        Array.Reverse(suministros);
        Console.WriteLine("Orden inventario");
    }

    public void VaciarInventario()
    {
        Array.Clear(suministros,0,suministros.Length);
        Console.WriteLine($"Inventario Borrado: {suministros.Length}");
        Array.Resize(ref suministros, suministros.Length);
    }

    //agregar suministro

    public void AgregarSuministro(string nombre, int cantidad, int prioridad)
    {
        int indiceNull = Array.FindIndex(suministros, s => s == null);
        if(indiceNull >= 0)
        {
            suministros[indiceNull] = new Suministro(nombre, cantidad, prioridad);
        }
        else
        {
            Array.Resize(ref suministros, suministros.Length + 1);
            suministros[suministros.Length - 1] = new Suministro(nombre, cantidad, prioridad);
        }

        Console.WriteLine($"{nombre} agregado al inventario");
    }

    public void AgregarSuministro(string nombre)
    {
        AgregarSuministro(nombre, 1, 2);
    }

    //Eliminar del inventario
    public void EliminarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower());
        if (indice >= 0)
        {
            for(int i = indice; i < suministros.Length-1; i++)
            {
                suministros[i] = suministros[i+1];
            }
            Array.Resize(ref suministros, suministros.Length - 1);
            Console.WriteLine($"{nombre} ha sido eliminado del inventario");
        }
        else
        {
            Console.WriteLine($"{nombre} no se ha encontrado");
        }
    }

}



