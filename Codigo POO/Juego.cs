//implementacion del juego

try
{
    Console.WriteLine("Bienvenido al Torneo de guerreros");
    string nombre = ObtenerNombre();

    Guerrero jugador = SeleccionarClase(nombre);
    Guerrero enemigo = GenerarEnemigo();

    Console.WriteLine($"Te enfrentaras a: {enemigo.Nombre}");

    while (enemigo.Vida > 0 && jugador.Vida > 0)
    {
        MostrarEstado(jugador, enemigo);
        string opcion = ObtenerOpcion();

        switch (opcion)
        {
            case "1":
                jugador.Atacar(enemigo);
                break;

            case "2":
                Console.WriteLine($"{jugador.Nombre} se defiende y el daño se reduce");
                jugador.RecibirDanio(jugador.Ataque / 2);
                break;

            case "3":
                Console.WriteLine("Intentando la Fusion");
                if(new Random().Next(1,100) > 50)
                {
                    jugador = jugador + enemigo;
                    Console.WriteLine($"Tu nuevo nombre es: {jugador.Nombre} | {jugador.Vida} | {jugador.Ataque} ");
                    enemigo.RecibirDanio(enemigo.Vida);
                }
                else
                {
                    Console.WriteLine("La fusion fallo y perdiste vida");
                    jugador.RecibirDanio(jugador.Vida / 5);

                }

                    break;

            default:
                throw new ArgumentException("Opcion Invalida");
        }
        if (enemigo.Vida > 0)
        {
            enemigo.Atacar(jugador);
        }

    }


    Console.WriteLine("Fin del combate");

    Console.WriteLine(jugador.Vida > 0 ? "Ganaste!" : "Te derrotaron");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}


//Apartado de funciones

static string ObtenerNombre()
{
    while(true)
    {
        try
        {
            Console.WriteLine("Ingresa tu nombre de guerrero: ");
            string nombre = Console.ReadLine()??"".Trim();
            if(string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacio ");
            }
            return nombre;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

        }

    }
}

static string ObtenerOpcion()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Que quieres hacer? ");
            string opcion = Console.ReadLine() ?? "".Trim();
            if (opcion != "1" && opcion != "2" && opcion != "3")
            {
                throw new ArgumentException("Opcion invalida, debes ingresar 1, 2, o 3");
            }
            return opcion;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
    static Guerrero GenerarEnemigo()
    {
        string[] nombres = { "Vikingo", "Orco", "Terminator", "Mickey Mouse", "Shrek", "Zeus" };
        string nombre = nombres[new Random().Next(nombres.Length)];
        return new Guerrero(nombre, new Random().Next(150, 200), new Random().Next(30, 50));

    }

    static void MostrarEstado(Guerrero Jugador, Guerrero Enemigo)
    {
        Console.WriteLine($"Tu vida: {Jugador.Vida} | Vida enemigo: {Enemigo.Vida}");
        Console.WriteLine("1- Atacar");
        Console.WriteLine("2- Defender");
        Console.WriteLine("3- Fusionar con el enemigo");

    }


    static Guerrero SeleccionarClase(string nombre)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Escoge tu clase: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("1- Caballero");
                Console.WriteLine("2- Mago");
                Console.WriteLine("3- Arquero");
                Console.WriteLine("4- Guerrero sombra");

                string opcion = Console.ReadLine() ?? "";

                return opcion switch
                {
                    "1" => new Caballero(nombre),
                    "2" => new Mago(nombre),
                    "3" => new Arquero(nombre),
                    "4" => new Sombra(nombre),
                    _ => throw new ArgumentException("opcion invalida")
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }



//Clases
public class Guerrero
{
    //Atributos

    public string Nombre { get; set; }
    public int Vida {  get; set; }
    public int Ataque {  get; set; }

    //Constructor

    public Guerrero (string nombre, int vida, int ataque)
    {
        Nombre = nombre;
        Vida = vida;
        Ataque = ataque;
    }

    //Metodos

    public virtual void Atacar(Guerrero enemigo)
    {
        int danio = Ataque + new Random().Next(-3, 5);
        //Recibir daño
        enemigo.RecibirDanio(danio);
        Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} y le causa {danio} de daño");
    }

    public void RecibirDanio(int cantidad)
    {
        Vida = Math.Max(Vida - cantidad, 0);
    }

    //Sobrecarga del operador +

    public static Guerrero operator +(Guerrero g1, Guerrero g2)
    {
        Console.WriteLine($"{g1.Nombre} + {g2.Nombre} se fusionan en un nuevo guerrero");
        return new Guerrero($"{g1.Nombre}--{g2.Nombre}",(g1.Vida + g1.Vida)/2, (g1.Ataque + g2.Ataque)/2);
    }
}

//Caballero

public class Caballero : Guerrero
{
    //Constructor
    public Caballero(string nombre) : base(nombre, 120, 20) {}

    public override void Atacar(Guerrero enemigo)
    {
        Console.WriteLine($"{Nombre} (caballero) usa golpe critico");
        base.Atacar(enemigo);
    }
}

//Mago

public class Mago : Guerrero
{
    public Mago(string nombre) : base(nombre, 80, 25) { }

    public override void Atacar(Guerrero enemigo)
    {
        Console.WriteLine($"{Nombre} (mago) lanza hechizo de fuego");
        base.Atacar(enemigo);
    }
}

public class Arquero : Guerrero
{
    public Arquero(string nombre) : base(nombre, 90, 15) { }

    public override void Atacar(Guerrero enemigo)
    {
        int proba = new Random().Next(1,100);

        if (proba < 30)
        {
            Console.WriteLine($"{Nombre} (arquero) dispara una flecha y falla");
        }
        else
        {
            Console.WriteLine($"{Nombre} (arquero) lanza una flecha y acierta");
            base.Atacar(enemigo);
        }
    }
}

public class Sombra : Guerrero
{
    public Sombra(string nombre) : base(nombre, 110, 22) { }

    public override void Atacar(Guerrero enemigo)
    {
        int chance = new Random().Next(1, 100);

        if (chance < 20)
        {
            Console.WriteLine($"{Nombre} (guerrero sombra) desaparece");
        }
        else
        {
            Console.WriteLine($"{Nombre} (guerrero sombra) ataca sigilosamente");
            base.Atacar(enemigo);
        }
    }
}

