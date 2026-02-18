//Programa principal

Lampara lampara = new Lampara("Lamparita", 80, 40);
Ventilador ventilador = new Ventilador("Aire", 500, 50);

//Encender ambos

lampara.Encender();
ventilador.Encender();

//Mostrar informacion

Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());

//Ajustar consumo
lampara.AjustarConsumo();
ventilador.AjustarConsumo(150);

//Mostrar informacion

Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());

//Comparacion

if(lampara > ventilador)
{
    Console.WriteLine("Lampara consume mas");
}
else if (lampara < ventilador)
{
    Console.WriteLine("Ventilador consume mas");
}
else
{
    Console.WriteLine("Ambos consumen la misma energia");
}

public class Dispositivo
{
    //Atributos
    private string nombre;
    private bool encendido;
    private int consumo;
    
    public string Nombre
    {
        get {  return nombre; }
        set { nombre = value; }
    }
    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }
    public int Consumo
    {
        get { return encendido ? consumo : 0; } //solo consume si esta encendido
        set 
        {
            if (value < 0)
            {
                consumo = 0;
            }
            else
            {
                consumo = value;
            }
        }
    }


    //Constructor 
    public Dispositivo(string nombre, int consumo)
    {
        this.nombre = nombre;
        this.consumo = consumo;
        this.encendido = false;
    }

    //Metodos

    public void Encender()
    {
        Encendido = true;
    }
    public void Apagar()
    {
        Encendido = false;
    }
    //sobrecarga

    public void AjustarConsumo()
    {
        Consumo = 100;
    }
    public void AjustarConsumo(int nuevoConsumo)
    {
        Consumo = nuevoConsumo;
    }

    public virtual string MostrarInfo()
    {
        return $"Dispositivo: {Nombre}, Encendido: {Encendido}, Consumo: {Consumo}";
    }

    //Sobrecarga de operadores

    public static bool operator > (Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo > d2.Consumo;
    }
    public static bool operator < (Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo < d2.Consumo;
    }

    public static bool operator == (Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo == d2.Consumo;
    }
    public static bool operator != (Dispositivo d1, Dispositivo d2)
    {
        return d1.Consumo != d2.Consumo;
    }

}

public class Lampara : Dispositivo
{
    //Atributos

    private int intensidad; //Nivel de brillo

    //Constructor

    public Lampara(string nombre, int consumo, int intensidad) : base(nombre, consumo)
    {
        this.intensidad = intensidad;
    }

    //Metodos
    public override string MostrarInfo()
    {
        return $"Lampara: {base.MostrarInfo()}, Intensidad: {intensidad}";
    }
}

public class Ventilador : Dispositivo
{
    //Atributo privado

    private int velocidad; 

    //Constructor

    public Ventilador(string nombre, int consumo, int velocidad) : base(nombre, consumo)
    {
        this.velocidad = velocidad;
    }

    //Sobrecarga de metodo
    public override string MostrarInfo()
    {
        return $"Ventilador: { base.MostrarInfo()}, Velocidad: {velocidad}";
    }
}