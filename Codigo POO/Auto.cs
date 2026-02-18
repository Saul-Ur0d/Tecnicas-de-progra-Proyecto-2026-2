//Programa principal con instrucciones de nivel superior

Auto auto1 = new Auto();
auto1.Marca = "Honda";
auto1.Modelo = "Civic";
auto1.VelocidadActual = 20.5f
Console.WriteLine($"La marca del auto es: {auto1.Marca}");
auto1.Acelerar(10.0f);
Console.WriteLine($"La velocidad es: {auto1.VelocidadActual}");
auto1.Frenar(10.0f);
Console.WriteLine($"La velocidad es: {auto1.VelocidadActual}");

Vehiculo vehiculo = new Vehiculo("Algo", "Otracosa");
AutoH autoH = new AutoH("Ford", "Mustang");
autoH.Marca = autoH.Marca;

Motocicleta moto = new Motocicleta("Yamaha", "MT07");

autoH.Acelerar(50f);
moto.Acelerar(60f);

moto.Frenar(70.0f);

if (autoH > moto)
{
    Console.WriteLine($"Auto mas rapido: {autoH.VelocidadActual}"
}
else if
{
    Console.WriteLine($"Moto mas rapida: {moto.VelocidadActual}");
}
else if (autoH == moto)
{
    Console.WriteLine("Van a la misma velocidad");
}

//Clase padre
public class Vehiculo
{
    //Atributos
    protected string marca;
    protected string modelo;
    protected float velocidadActual;

    //Atributos publicos con control

    public virtual string Marca
    {
        get { return marca; }
        set { marca = value; }
    }
    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public float VelocidadActual
    {
        get { return velocidadActual; }
        set
        {
            if (value < 0)
            {
                velocidadActual = 0;
            }
            else
            {
                velocidadActual = value;
            }
        }

    }

    //Constructor

    public Vehiculo(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.velocidadActual = 0.0f;
    }

    //Metodos

    public void Acelerar(float incremento)
    {
        VelocidadActual += incremento;
    }
    public void Frenar(float decremento)
    {
        VelocidadActual -= decremento;
    }

    //Sobrecarga de operadores
    public static bool operator > (Vehiculo v1,  Vehiculo v2)
    {
        return v1.VelocidadActual > v2.VelocidadActual;
    }
    public static bool operator < (Vehiculo v1, Vehiculo v2)
    {
        return v1.VelocidadActual < v2.VelocidadActual;
    }
    public static bool operator  == (Vehiculo v1, Vehiculo v2)
    {
        return v1.VelocidadActual == v2.VelocidadActual;
    }
    public static bool operator !=(Vehiculo v1, Vehiculo v2)
    {
        return v1.VelocidadActual != v2.VelocidadActual;
    }

}
public class AutoH : Vehiculo
{
    //Constructor
    public AutoH(string marca, string modelo) : base(marca, modelo) { }

    // Atributos publicos con control
    public override string Marca
    {
        get 
        {
            Console.WriteLine($"La marca del auto es: {marca}");
            return marca; 
        }
        set { Marca = value; }
    }

}
public class Motocicleta : Vehiculo
{
    //Constructor
    public Motocicleta(string marca, string modelo) : base(marca, modelo) { }


}

public class Auto
{
    //Atributos
    private string marca;
    private string modelo;
    private float velocidadActual;

    //Atributos publicos con control

    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }
    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public float VelocidadActual
    {
        get { return velocidadActual; }
        set { 
            if (value  < 0)
                {
                    velocidadActual = 0;
                }
            else
                {
                velocidadActual = value;
                }
            }
    }

    //Constructor


    //Metodos

    public void Acelerar(float incremento)
    {
        VelocidadActual += incremento;
    }
    public void Frenar(float decremento)
    {
        VelocidadActual -= decremento;
    }

}