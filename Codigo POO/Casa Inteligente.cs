
List <IDispositivoInteligente> IOT = new List<IDispositivoInteligente>();

Lampara lampara = new Lampara();
Ventilador venti = new Ventilador();
Altavoz bocina = new Altavoz();

IOT.Add(lampara);
IOT.Add(venti);
IOT.Add(bocina);

foreach (IDispositivoInteligente aparato in IOT)
{
    aparato.Encenderse();
}

foreach (IDispositivoInteligente aparato in IOT)
{
    Console.ForegroundColor = ConsoleColor.Green;
    aparato.Mostrar_Estado();
    Console.ForegroundColor = ConsoleColor.White;
}

lampara.Ajustar_Brillo(14);
venti.Ajustar_Velocidad(22);
bocina.Reproducir_Musica();

foreach (IDispositivoInteligente aparato in IOT)
{
    Console.ForegroundColor = ConsoleColor.Green;
    aparato.Mostrar_Estado();
    Console.ForegroundColor = ConsoleColor.White;
}

foreach (IDispositivoInteligente aparato in IOT)
{
    aparato.Apagarse();
}

foreach (IDispositivoInteligente aparato in IOT)
{
    Console.ForegroundColor = ConsoleColor.Green;
    aparato.Mostrar_Estado();
    Console.ForegroundColor = ConsoleColor.White;
}




public interface IDispositivoInteligente
{    
    void Encenderse();
    void Apagarse();
    void Mostrar_Estado();
}

public class Lampara : IDispositivoInteligente
{
    public bool Estado {  get; set; }
    public int Brillo { get; set; }

    public Lampara ()
    {
        Estado = false;
        Brillo = 10;
    }

    public void Encenderse()
    {
        Console.WriteLine("Lampara se ha encendido");
        Estado = true;
    }
    public void Apagarse()
    {
        Console.WriteLine("Lampara se ha apagado");
        Estado = false;
    }
    public void Mostrar_Estado()
    {
        if (Estado)
        {
            Console.WriteLine($"Lampara se encuentra encendida y con un brillo de {Brillo}");
        }
        else
        {
            Console.WriteLine("Lampara se encuentra apagada");
        }

    }
    public void Ajustar_Brillo(int ajuste)
    {
        Brillo = Math.Abs(ajuste);
        Console.WriteLine($"Se ha ajustado el brillo a: {Brillo}");
    }
}


public class Ventilador : IDispositivoInteligente
{
    public bool Estado { get; set; }
    public int Velocidad { get; set; }

    public Ventilador()
    {
        Estado = false;
        Velocidad = 10;
    }

    public void Encenderse()
    {
        Console.WriteLine("Ventilador se ha encendido");
        Estado = true;
    }
    public void Apagarse()
    {
        Console.WriteLine("Ventilador se ha apagado");
        Estado = false;
    }
    public void Mostrar_Estado()
    {
        if (Estado)
        {
            Console.WriteLine($"Ventilador se encuentra encendido soplando con velocidad de {Velocidad}");
        }
        else
        {
            Console.WriteLine("Ventilador se encuentra apagado");
        }

    }
    public void Ajustar_Velocidad(int ajuste)
    {
        Velocidad = Math.Abs(ajuste);
        Console.WriteLine($"Se ha ajustado la velocidad a {Velocidad}");
    }
}
public class Altavoz : IDispositivoInteligente
{
    public bool Estado { get; set; }
    public bool Musica { get; set; }
    public Altavoz()
    {
        Estado = false;
        Musica = false;
    }

    public void Encenderse()
    {
        Console.WriteLine("Altavoz se ha encendido");
        Estado = true;
    }
    public void Apagarse()
    {
        Console.WriteLine("Altavoz se ha apagado");
        Estado = false;
    }
    public void Mostrar_Estado()
    {
        if (Estado && Musica)
        {
            Console.WriteLine("Altavoz se encuentra encendido y reproduciendo musica");
        }
        else if(Estado)
        {
            Console.WriteLine("Altavoz se encuentra encendido");
        }
        else
        {
            Console.WriteLine("Altavoz se encuentra apagado");
        }

    }
    public void Reproducir_Musica()
    {
        Console.WriteLine("Se inicio a reproducir musica");
        Musica = true;
    }
}