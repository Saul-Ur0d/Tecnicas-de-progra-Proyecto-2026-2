
List <IDispositivoInteligente> IOT = new List<IDispositivoInteligente>();

Lampara lampara = new Lampara();
Ventilador venti = new Ventilador();
Altavoz bocina = new Altavoz();

IOT.Add(lampara);
IOT.Add(bocina);
IOT.Add(venti);

bool continuar = true;
do
{
    Console.WriteLine("Que deseas hacer? ");
    Console.WriteLine("1- Encender todo ");
    Console.WriteLine("2- Apagar todo ");
    Console.WriteLine("3- Ajustar brillo de la lampara ");
    Console.WriteLine("4- Ajustar velocidad del ventilador ");
    Console.WriteLine("5- Poner musica ");
    Console.WriteLine("6- Quitar musica ");
    Console.WriteLine("7- Terminar programa ");

    string decision = Console.ReadLine() ?? "";
    if(int.TryParse(decision, out int Des))
    {
        switch (Des)
        {
            case 1:
                foreach(IDispositivoInteligente aparato in IOT)
                {
                    aparato.Encenderse()
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                continuar = false;
                break;
            default:
                Console.WriteLine("Ingresa un numero valido");
                break;
        }
    }




} while (continuar);












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
        Estado = true;
    }
    public void Apagarse()
    {
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
        Estado = true;
    }
    public void Apagarse()
    {
        Estado = false;
    }
    public void Mostrar_Estado()
    {
        if (Estado)
        {
            Console.WriteLine("Ventilador se encuentra encendido");
        }
        else
        {
            Console.WriteLine("Ventilador se encuentra apagado");
        }

    }
    public void Ajustar_Velocidad(int ajuste)
    {
        Velocidad = Math.Abs(ajuste);
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
        Estado = true;
    }
    public void Apagarse()
    {
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
        Musica = true;
    }
}